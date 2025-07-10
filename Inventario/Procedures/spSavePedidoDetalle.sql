IF OBJECT_ID( 'spSavePedidoDetalle' ) IS NULL
	EXEC ('CREATE PROCEDURE spSavePedidoDetalle AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE spSavePedidoDetalle (
@iIdPedido INT, 
@iIdProveedor INT, 
@iIdArticulo INT, 
@smCantidad SMALLINT, 
@mPrecioUnitario MONEY 
) 
AS 
BEGIN 

DECLARE @vchError VARCHAR(200) = '',
@iIdPedidoDetalle INT;

DECLARE @Result AS TABLE (
	bResult BIT DEFAULT(1),
	vchMessage VARCHAR(500) DEFAULT(''),
	iIdPedidoDetalle INT DEFAULT( -1 ) 
	);

SET NOCOUNT ON
SET XACT_ABORT ON;

BEGIN TRY

BEGIN TRANSACTION



	INSERT INTO dbo.PedidoDetalle
	 ( 

		iIdPedido, 			iIdArticulo, 			smCantidad, 	
		mPrecioUnitario 	
	)
	VALUES 
	(
		@iIdPedido,		@iIdArticulo,		@smCantidad,
		@mPrecioUnitario
	)
		 SET @iIdPedidoDetalle = @@IDENTITY


	IF EXISTS (SELECT 1 FROM Articulo WHERE iIdArticulo =@iIdArticulo AND mPrecioCompra != @mPrecioUnitario )
	BEGIN
		UPDATE  dbo.Articulo WITH(ROWLOCK) SET
		 mPrecioCompra = @mPrecioUnitario 
	 WHERE  iIdArticulo  = @iIdArticulo;

	END


	IF NOT EXISTS (SELECT 1 FROM Inventario WHERE iIdArticulo = @iIdArticulo)
	BEGIN

	INSERT INTO dbo.Inventario
	 ( 

		iIdArticulo, 			smCantidad 	
	)
	VALUES 
	(
		@iIdArticulo,		@smCantidad
	)
	END
	ELSE
	BEGIN

		UPDATE  dbo.Inventario WITH(ROWLOCK) SET
		 smCantidad = smCantidad + @smCantidad 
		 WHERE  iIdArticulo = @iIdArticulo;

	END


		COMMIT TRANSACTION ;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION ;

		SELECT @vchError = CONCAT( 'spSavePedidoDetalle: ', ERROR_MESSAGE( ), ' ', ERROR_PROCEDURE( ), ' ', ERROR_LINE( ) );
		PRINT @vchError;
	END CATCH

	IF LEN( @vchError ) > 0
	BEGIN
		INSERT INTO @Result
		(
			bResult,vchMessage
		)
		VALUES
		(
			0,@vchError
		);
	END
	ELSE
	BEGIN
		INSERT INTO @Result
		(
			bResult,vchMessage,iIdPedidoDetalle
		)
		VALUES
		(
			1,'',@iIdPedidoDetalle
		);
	END;

	SELECT *
	FROM
		@Result;
	SET NOCOUNT OFF;
END;
GO 


