IF OBJECT_ID( 'spGetProveedor' ) IS NULL
	EXEC ('CREATE PROCEDURE spGetProveedor AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE spGetProveedor 
AS 
BEGIN 


CREATE TABLE #Result (
	bResult BIT DEFAULT (1),
	vchMessage VARCHAR(500) DEFAULT(''),
	 iIdProveedor INT DEFAULT( -1 ),
	 nvchNombre NVARCHAR (200)  DEFAULT( '' ),
	 vchTelefono VARCHAR (20)  DEFAULT( '' ),
	 nvchDireccion NVARCHAR (400)  DEFAULT( '' ),
);

SET NOCOUNT ON

	BEGIN TRY

	INSERT INTO  #Result
	 ( 

		iIdProveedor, 			nvchNombre, 			vchTelefono, 	
		nvchDireccion 			)
		SELECT 
		 P.iIdProveedor, 			 P.nvchNombre, 			 P.vchTelefono, 	
				 P.nvchDireccion 	FROM
		 dbo.Proveedor P  WITH(NOLOCK)  


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
