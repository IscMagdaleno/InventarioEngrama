IF OBJECT_ID( 'spGetAbonoApartado' ) IS NULL
	EXEC ('CREATE PROCEDURE spGetAbonoApartado AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE spGetAbonoApartado (
@iIdApartado INT )
AS 
BEGIN 


CREATE TABLE #Result (
	bResult BIT DEFAULT (1),
	vchMessage VARCHAR(500) DEFAULT(''),
	 iIdAbonoApartado INT DEFAULT( -1 ),
	 iIdApartado INT DEFAULT( -1 ),
	 mAbono MONEY DEFAULT( 0 ),
	 dtFechaAbono DATETIME DEFAULT( '1900-01-01' ),
);

SET NOCOUNT ON

	BEGIN TRY

	INSERT INTO  #Result
	 ( 

		iIdAbonoApartado, 			iIdApartado, 			mAbono, 	
		dtFechaAbono 			)
		SELECT 
		 AA.iIdAbonoApartado, 			 AA.iIdApartado, 			 AA.mAbono, 	
				 AA.dtFechaAbono 	FROM
		 dbo.AbonoApartado AA  WITH(NOLOCK)  
		 WHERE AA.iIdApartado = @iIdApartado


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
exec spGetAbonoApartado 4
