IF OBJECT_ID( 'spGetInventario' ) IS NULL
	EXEC ('CREATE PROCEDURE spGetInventario AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE spGetInventario 
AS 
BEGIN 

CREATE TABLE #Result (
	bResult BIT DEFAULT (1),
	vchMessage VARCHAR(500) DEFAULT(''),
	 iIdInventario INT DEFAULT( -1 ),
	 iIdArticulo INT DEFAULT( -1 ),
	 smCantidad SMALLINT DEFAULT( -1 ),
		nvchNombreArticulo NVARCHAR (200)  DEFAULT ( '' ),
		vchCodigo VARCHAR (50)  DEFAULT ( '' ),
		nvchDescripcion VARCHAR (1000)  DEFAULT ( '' ),
		mPrecioCompra MONEY DEFAULT ( 0 ),
		mPrecioVenta MONEY DEFAULT ( 0 ),
		iIdProveedor INT DEFAULT ( -1 ),
		nvchNombreProveedor NVARCHAR (200)  DEFAULT ( '' ),
		vchTelefono VARCHAR (20)  DEFAULT ( '' ),
		nvchDireccion NVARCHAR (400)  DEFAULT ( '' )
);

SET NOCOUNT ON

	BEGIN TRY

	INSERT INTO  #Result
	 ( 
		iIdInventario, 			 			smCantidad 	,
		iIdArticulo, nvchNombreArticulo, 			vchCodigo, 	nvchDescripcion,		mPrecioCompra, 	
		mPrecioVenta, 			iIdProveedor 	,
		nvchNombreProveedor, 			vchTelefono, 			nvchDireccion 	
		)
		SELECT 
		 I.iIdInventario, 						 I.smCantidad 	,
		 	AR.iIdArticulo, AR.nvchNombre, 			AR.vchCodigo, 	AR.nvchDescripcion,		AR.mPrecioCompra, 	
		AR.mPrecioVenta, 			P.iIdProveedor 	,
		P.nvchNombre, 			P.vchTelefono, 			P.nvchDireccion 	
		FROM
		 dbo.Inventario I  WITH(NOLOCK)  
		 INNER JOIN Articulo AR ON AR.iIdArticulo = I.iIdArticulo
		 INNER JOIN dbo.Proveedor P ON P.iIdProveedor = AR.iIdProveedor


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
	SELECT * FROM #Result ORDER BY nvchNombreArticulo, mPrecioVenta DESC;
	DROP TABLE #Result;
	END
GO
exec spGetInventario
