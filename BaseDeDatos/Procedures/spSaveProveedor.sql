IF OBJECT_ID( 'spSaveProveedor' ) IS NULL
	EXEC ('CREATE PROCEDURE spSaveProveedor AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE spSaveProveedor (
@iIdProveedor INT, 
@nvchNombre NVARCHAR (200) , 
@vchTelefono VARCHAR (20) , 
@nvchDireccion NVARCHAR (400)  
) 
AS 
BEGIN 

DECLARE @vchError VARCHAR(200) = '';

DECLARE @Result AS TABLE (
	bResult BIT DEFAULT(1),
	vchMessage VARCHAR(500) DEFAULT(''),
	iIdProveedor INT DEFAULT( -1 ) 
	);

SET NOCOUNT ON
SET XACT_ABORT ON;

BEGIN TRY

BEGIN TRANSACTION

IF  ( @iIdProveedor <= 0) 
BEGIN 
	INSERT INTO dbo.Proveedor
	 ( 

		nvchNombre, 			vchTelefono, 			nvchDireccion 	

	)
	VALUES 
	(
		@nvchNombre,		@vchTelefono,		@nvchDireccion

	)
		 SET @iIdProveedor = @@IDENTITY
END
ELSE
BEGIN
	UPDATE  dbo.Proveedor WITH(ROWLOCK) SET
		 nvchNombre = @nvchNombre, 
		 vchTelefono = @vchTelefono, 
		 nvchDireccion = @nvchDireccion 

	 WHERE  iIdProveedor  = @iIdProveedor;

END
		COMMIT TRANSACTION ;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION ;

		SELECT @vchError = CONCAT( 'spSaveProveedor: ', ERROR_MESSAGE( ), ' ', ERROR_PROCEDURE( ), ' ', ERROR_LINE( ) );
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
			bResult,vchMessage,iIdProveedor
		)
		VALUES
		(
			1,'',@iIdProveedor
		);
	END;

	SELECT *
	FROM
		@Result;
	SET NOCOUNT OFF;
END;
GO 


