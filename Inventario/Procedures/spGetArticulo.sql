IF OBJECT_ID( 'spGetArticulo' ) IS NULL
	EXEC ('CREATE PROCEDURE spGetArticulo AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE spGetArticulo 
AS 
BEGIN 


CREATE TABLE #Result (
	bResult BIT DEFAULT (1),
	vchMessage VARCHAR(500) DEFAULT(''),
	 iIdArticulo INT DEFAULT( -1 ),
	 iIdProveedor INT DEFAULT( -1 ),
	 nvchNombre NVARCHAR (200)  DEFAULT( '' ),
	 vchCodigo VARCHAR (50)  DEFAULT( '' ),
	 nvchDescripcion VARCHAR (1000)  DEFAULT( '' ),
	 mPrecioCompra MONEY DEFAULT( 0 ),
	 mPrecioVenta MONEY DEFAULT( 0 ),
);

SET NOCOUNT ON

	BEGIN TRY

	INSERT INTO  #Result
	 ( 

		iIdProveedor, iIdArticulo, 			nvchNombre, 			vchCodigo, 	nvchDescripcion,
		mPrecioCompra, 			mPrecioVenta 			)
		SELECT 
		 A.iIdProveedor, A.iIdArticulo, 			 A.nvchNombre, 			 A.vchCodigo, 	A.nvchDescripcion, 	
				 A.mPrecioCompra, 			 A.mPrecioVenta 	FROM
		 dbo.Articulo A  WITH(NOLOCK)  


		IF NOT EXISTS (SELECT 1 FROM #Result)
			BEGIN
				INSERT INTO #Result (bResult, vchMessage)
				SELECT 0, 'No register found.';
			END
	END TRY
	BEGIN CATCH
		INSERT INTO #Result (bResult, vchMessage)
		SELECT 0, CONCAT(ERROR_PROCEDURE(), ' : ', ERROR_MESSAGE(), ' - ', ERROR_LINE());
		PRINT CONCAT(ERROR_PROCEDURE(), ' : ', ERROR_MESSAGE(), ' - ', ERROR_LINE());
	END CATCH
	SELECT * FROM #Result;
	DROP TABLE #Result;
	END
GO
