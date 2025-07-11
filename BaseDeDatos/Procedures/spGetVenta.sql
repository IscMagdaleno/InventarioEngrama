IF OBJECT_ID( 'spGetVenta' ) IS NULL
	EXEC ('CREATE PROCEDURE spGetVenta AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE spGetVenta 
AS 
BEGIN 


CREATE TABLE #Result (
	bResult BIT DEFAULT (1),
	vchMessage VARCHAR(500) DEFAULT(''),
	 iIdVenta INT DEFAULT( -1 ),
	 iIdArticulo INT DEFAULT( -1 ),
	 iCantidad INT DEFAULT( -1 ),
	 mPrecioFinal MONEY DEFAULT( 0 ),
	 dtFechaVenta DATETIME DEFAULT( '1900-01-01' ),
	 vchReferenciaVenta VARCHAR (100)  DEFAULT( '' ),

	  --Articulos data
		iIdProveedor INT DEFAULT( -1 ),
		nvchNombre NVARCHAR (200)  DEFAULT ( '' ),
		vchCodigo VARCHAR (50)  DEFAULT ( '' ),
		nvchDescripcion VARCHAR (1000)  DEFAULT ( '' ),
		mPrecioCompra MONEY DEFAULT ( 0 ),
		mPrecioVenta MONEY DEFAULT ( 0 )
);

SET NOCOUNT ON

	BEGIN TRY

	INSERT INTO  #Result
	 ( 

		iIdVenta, 			iIdArticulo, 			iCantidad, 	
		mPrecioFinal, 			dtFechaVenta, 			vchReferenciaVenta 	,
		nvchNombre, 			vchCodigo, 			mPrecioCompra, 	
		mPrecioVenta, 			iIdProveedor, 			nvchDescripcion 	
		)
		SELECT
    v.iIdVenta,  v.iIdArticulo, v.iCantidad,  
         v.mPrecioFinal,   v.dtFechaVenta, v.vchReferenciaVenta,
		 a.nvchNombre   ,a.vchCodigo  , a.mPrecioCompra ,
  
    a.mPrecioVenta ,  a.iIdProveedor,  ISNULL(a.nvchDescripcion, '')
FROM
    dbo.Venta     v
    INNER JOIN dbo.Articulo a ON v.iIdArticulo = a.iIdArticulo;


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


EXEC spGetVenta