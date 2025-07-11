IF OBJECT_ID( 'spSavePedido' ) IS NULL
	EXEC ('CREATE PROCEDURE spSavePedido AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE spSavePedido (
@iIdPedido INT, 
@iIdProveedor INT, 
@nvchDescripcion NVARCHAR(3000) , 
@mEnvio MONEY 
) 
AS 
BEGIN 

DECLARE @vchError VARCHAR(200) = '';

DECLARE @Result AS TABLE (
	bResult BIT DEFAULT(1),
	vchMessage VARCHAR(500) DEFAULT(''),
	iIdPedido INT DEFAULT( -1 ) 
	);

SET NOCOUNT ON
SET XACT_ABORT ON;

BEGIN TRY

BEGIN TRANSACTION

IF  ( @iIdPedido <= 0) 
BEGIN 
	INSERT INTO dbo.Pedido
	 ( 

		iIdProveedor, 			dtFecha, 			nvchDescripcion, 	
		mEnvio 	
	)
	VALUES 
	(
		@iIdProveedor,		GETDATE(),		@nvchDescripcion,
		@mEnvio
	)
		 SET @iIdPedido = @@IDENTITY
END
ELSE
BEGIN
	UPDATE  dbo.Pedido WITH(ROWLOCK) SET
		 iIdProveedor = @iIdProveedor, 
		 nvchDescripcion = @nvchDescripcion, 
		 mEnvio = @mEnvio 

	 WHERE  iIdPedido  = @iIdPedido;

END
		COMMIT TRANSACTION ;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION ;

		SELECT @vchError = CONCAT( 'spSavePedido: ', ERROR_MESSAGE( ), ' ', ERROR_PROCEDURE( ), ' ', ERROR_LINE( ) );
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
			bResult,vchMessage,iIdPedido
		)
		VALUES
		(
			1,'',@iIdPedido
		);
	END;

	SELECT *
	FROM
		@Result;
	SET NOCOUNT OFF;
END;
GO 


