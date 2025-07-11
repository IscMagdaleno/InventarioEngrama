IF OBJECT_ID( 'spGetPedidoDetalle' ) IS NULL
	EXEC ('CREATE PROCEDURE spGetPedidoDetalle AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE spGetPedidoDetalle (
@iIdPedido INT 
) 
AS 
BEGIN 


CREATE TABLE #Result (
	bResult BIT DEFAULT (1),
	vchMessage VARCHAR(500) DEFAULT(''),
	 iIdPedidoDetalle INT DEFAULT( -1 ),
	 iIdPedido INT DEFAULT( -1 ),
	 iIdArticulo INT DEFAULT( -1 ),
	 smCantidad SMALLINT DEFAULT( -1 ),
	 mPrecioUnitario MONEY DEFAULT( 0 ),

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

		iIdPedidoDetalle, 			iIdPedido, 			iIdArticulo, 	
		smCantidad, 			mPrecioUnitario 	,
		iIdProveedor, nvchNombre, 			vchCodigo, 		nvchDescripcion,	mPrecioCompra, 	
		mPrecioVenta )
		SELECT 
		 PD.iIdPedidoDetalle, 			 PD.iIdPedido, 			 PD.iIdArticulo, 	
				 PD.smCantidad, 			 PD.mPrecioUnitario ,
					A.iIdProveedor, A.nvchNombre, 	A.vchCodigo, A.nvchDescripcion, 
	A.mPrecioCompra, 	A.mPrecioVenta
		FROM
				 dbo.PedidoDetalle PD  WITH(NOLOCK)  
				 INNER JOIN Articulo A ON A.iIdArticulo = PD.iIdArticulo
		 WHERE iIdPedido = @iIdPedido



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

exec spGetPedidoDetalle 1