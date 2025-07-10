IF OBJECT_ID( 'spGetPedido' ) IS NULL
	EXEC ('CREATE PROCEDURE spGetPedido AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE spGetPedido 
AS 
BEGIN 


CREATE TABLE #Result (
	bResult BIT DEFAULT (1),
	vchMessage VARCHAR(500) DEFAULT(''),
	 iIdPedido INT DEFAULT( -1 ),
	 iIdProveedor INT DEFAULT( -1 ),
	 dtFecha DATETIME DEFAULT( '1900-01-01' ),

	 nvchNombre VARCHAR(200) DEFAULT(''),

);

SET NOCOUNT ON

	BEGIN TRY

	INSERT INTO  #Result
	 ( 

		iIdPedido, 			iIdProveedor, 			dtFecha 	,nvchNombre 
		)
		SELECT 
		 P.iIdPedido, 			 P.iIdProveedor, 			 P.dtFecha 	,PR.nvchNombre 
		FROM
		 dbo.Pedido P  WITH(NOLOCK) 
		 INNER JOIN dbo.Proveedor PR On P.iIdProveedor = PR.iIdProveedor


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

exec spGetPedido