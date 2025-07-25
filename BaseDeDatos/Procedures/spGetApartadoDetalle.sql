IF OBJECT_ID( 'spGetApartadoDetalle' ) IS NULL
	EXEC ('CREATE PROCEDURE spGetApartadoDetalle AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE spGetApartadoDetalle (
@iIdApartado INT 
) 
AS 
BEGIN 


CREATE TABLE #Result (
	bResult BIT DEFAULT (1),
	vchMessage VARCHAR(500) DEFAULT(''),
	 iIdApartadoDetalle INT DEFAULT( -1 ),
	 iIdApartado INT DEFAULT( -1 ),
	 iIdArticulo INT DEFAULT( -1 ),
	 nvchNombreArticulo NVARCHAR (200)  DEFAULT ( '' ),
		vchCodigo VARCHAR (50)  DEFAULT ( '' ),
		nvchDescripcion VARCHAR (1000)  DEFAULT ( '' ),
		mPrecioCompra MONEY DEFAULT ( 0 ),
		mPrecioVenta MONEY DEFAULT ( 0 ),
	 iCantidad INT DEFAULT( -1 ),
	 mPrecioFinal MONEY DEFAULT( 0 ),
);

SET NOCOUNT ON

	BEGIN TRY

	INSERT INTO  #Result
	 ( 

		iIdApartadoDetalle, 			iIdApartado, 			
		iCantidad, 			mPrecioFinal 		,
	iIdArticulo, nvchNombreArticulo, 			vchCodigo, 	nvchDescripcion,		mPrecioCompra, 	
		mPrecioVenta		
		)
		SELECT 
		 AD.iIdApartadoDetalle, 			 AD.iIdApartado, 			  	
				 AD.iCantidad, 			 AD.mPrecioFinal 	,
				 AR.iIdArticulo, AR.nvchNombre, 			AR.vchCodigo, 	AR.nvchDescripcion,		AR.mPrecioCompra, 	
		AR.mPrecioVenta
		FROM
		 dbo.ApartadoDetalle AD  WITH(NOLOCK)  
		 INNER JOIN Articulo AR ON AR.iIdArticulo = AD.iIdArticulo

		 WHERE AD.iIdApartado = @iIdApartado


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
EXEC spGetApartadoDetalle 1