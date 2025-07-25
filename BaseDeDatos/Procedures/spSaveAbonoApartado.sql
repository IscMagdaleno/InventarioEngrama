IF OBJECT_ID( 'spSaveAbonoApartado' ) IS NULL
	EXEC ('CREATE PROCEDURE spSaveAbonoApartado AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE spSaveAbonoApartado (
@iIdAbonoApartado INT, 
@iIdApartado INT, 
@mAbono MONEY
) 
AS 
BEGIN 

DECLARE @vchError VARCHAR(200) = '';

DECLARE @Result AS TABLE (
	bResult BIT DEFAULT(1),
	vchMessage VARCHAR(500) DEFAULT(''),
	iIdAbonoApartado INT DEFAULT( -1 ) 
	);

SET NOCOUNT ON
SET XACT_ABORT ON;

BEGIN TRY

BEGIN TRANSACTION


	INSERT INTO dbo.AbonoApartado
	 ( 

		iIdApartado, 			mAbono, 			dtFechaAbono 	

	)
	VALUES 
	(
		@iIdApartado,		@mAbono,		GETDATE()

	)
		 SET @iIdAbonoApartado = @@IDENTITY



		COMMIT TRANSACTION ;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION ;

		SELECT @vchError = CONCAT( 'spSaveAbonoApartado: ', ERROR_MESSAGE( ), ' ', ERROR_PROCEDURE( ), ' ', ERROR_LINE( ) );
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
			bResult,vchMessage,iIdAbonoApartado
		)
		VALUES
		(
			1,'',@iIdAbonoApartado
		);
	END;

	SELECT *
	FROM
		@Result;
	SET NOCOUNT OFF;
END;
GO 


