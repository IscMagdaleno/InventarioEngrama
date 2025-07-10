IF OBJECT_ID( 'spSaveArticulo' ) IS NULL
	EXEC ('CREATE PROCEDURE spSaveArticulo AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE spSaveArticulo (
@iIdArticulo INT, 
@iIdProveedor INT, 
@nvchNombre NVARCHAR (200) , 
@vchCodigo VARCHAR (50) , 
@nvchDescripcion VARCHAR (1000) , 
@mPrecioCompra MONEY, 
@mPrecioVenta MONEY 
) 
AS 
BEGIN 

DECLARE @vchError VARCHAR(200) = '';

DECLARE @Result AS TABLE (
	bResult BIT DEFAULT(1),
	vchMessage VARCHAR(500) DEFAULT(''),
	iIdArticulo INT DEFAULT( -1 ) 
	);

SET NOCOUNT ON
SET XACT_ABORT ON;

BEGIN TRY

BEGIN TRANSACTION

IF  ( @iIdArticulo <= 0) 
BEGIN 
	INSERT INTO dbo.Articulo
	 ( 

		nvchNombre, 			vchCodigo, 			mPrecioCompra, 	
		mPrecioVenta 	,iIdProveedor, nvchDescripcion
	)
	VALUES 
	(
		@nvchNombre,		@vchCodigo,		@mPrecioCompra,
		@mPrecioVenta ,@iIdProveedor,@nvchDescripcion
	)
		 SET @iIdArticulo = @@IDENTITY
END
ELSE
BEGIN
	UPDATE  dbo.Articulo WITH(ROWLOCK) SET
		 nvchNombre = @nvchNombre, 
		 vchCodigo = @vchCodigo, 
		 mPrecioCompra = @mPrecioCompra, 
		 mPrecioVenta = @mPrecioVenta ,
		 iIdProveedor = @iIdProveedor,
		 nvchDescripcion =@nvchDescripcion

	 WHERE  iIdArticulo  = @iIdArticulo;

END
		COMMIT TRANSACTION ;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION ;

		SELECT @vchError = CONCAT( 'spSaveArticulo: ', ERROR_MESSAGE( ), ' ', ERROR_PROCEDURE( ), ' ', ERROR_LINE( ) );
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
			bResult,vchMessage,iIdArticulo
		)
		VALUES
		(
			1,'',@iIdArticulo
		);
	END;

	SELECT *
	FROM
		@Result;
	SET NOCOUNT OFF;
END;
GO 


