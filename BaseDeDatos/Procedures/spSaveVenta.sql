IF OBJECT_ID( 'spSaveVenta' ) IS NULL
	EXEC ('CREATE PROCEDURE spSaveVenta AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE spSaveVenta (
@iIdArticulo INT, 
@iCantidad INT, 
@mPrecioFinal MONEY, 
@dtFechaVenta DATETIME, 
@vchReferenciaVenta VARCHAR (100)  
) 
AS 
BEGIN 

DECLARE @vchError VARCHAR(200) = '',
@iIdVenta INT
;

DECLARE @Result AS TABLE (
	bResult BIT DEFAULT(1),
	vchMessage VARCHAR(500) DEFAULT(''),
	iIdVenta INT DEFAULT( -1 ) 
	);

SET NOCOUNT ON
SET XACT_ABORT ON;

BEGIN TRY

BEGIN TRANSACTION


	INSERT INTO dbo.Venta
	 ( 

		iIdArticulo, 			iCantidad, 			mPrecioFinal, 	
		dtFechaVenta, 			vchReferenciaVenta 	
	)
	VALUES 
	(
		@iIdArticulo,		@iCantidad,		@mPrecioFinal,
		GETDATE(),		@vchReferenciaVenta
	)
		 SET @iIdVenta = @@IDENTITY


		 
        UPDATE dbo.Inventario
        SET smCantidad = smCantidad - @iCantidad
        WHERE iIdArticulo = @iIdArticulo;



		COMMIT TRANSACTION ;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION ;

		SELECT @vchError = CONCAT( 'spSaveVenta: ', ERROR_MESSAGE( ), ' ', ERROR_PROCEDURE( ), ' ', ERROR_LINE( ) );
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
			bResult,vchMessage,iIdVenta
		)
		VALUES
		(
			1,'',@iIdVenta
		);
	END;

	SELECT *
	FROM
		@Result;
	SET NOCOUNT OFF;
END;
GO 


