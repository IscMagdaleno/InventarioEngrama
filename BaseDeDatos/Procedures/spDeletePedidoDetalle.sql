
IF OBJECT_ID( 'spDeletePedidoDetalle' ) IS NULL
	EXEC ('CREATE PROCEDURE spDeletePedidoDetalle AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE spDeletePedidoDetalle (
@iIdPedidoDetalle INT
) 
AS 
BEGIN 

DECLARE @vchError VARCHAR(200) = '';

DECLARE @Result AS TABLE (
	bResult BIT DEFAULT(1),
	vchMessage VARCHAR(500) DEFAULT('')
	);

SET NOCOUNT ON
SET XACT_ABORT ON;

BEGIN TRY

BEGIN TRANSACTION


    -- Variables para trabajar
    DECLARE @iIdArticulo INT;
    DECLARE @smCantidad SMALLINT;


        -- Obtiene los datos necesarios del detalle pedido
        SELECT 
            @iIdArticulo = iIdArticulo,
            @smCantidad = smCantidad
        FROM dbo.PedidoDetalle
        WHERE iIdPedidoDetalle = @iIdPedidoDetalle;

        -- Validaciones básicas
        IF @iIdArticulo IS NULL
        BEGIN
            RAISERROR('El PedidoDetalle especificado no existe.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Elimina el detalle del pedido
        DELETE FROM dbo.PedidoDetalle
        WHERE iIdPedidoDetalle = @iIdPedidoDetalle;

        -- Actualiza el inventario, restando la cantidad
        UPDATE dbo.Inventario
        SET smCantidad = smCantidad - @smCantidad
        WHERE iIdArticulo = @iIdArticulo;



		COMMIT TRANSACTION ;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION ;

		SELECT @vchError = CONCAT( 'spDeletePedidoDetalle: ', ERROR_MESSAGE( ), ' ', ERROR_PROCEDURE( ), ' ', ERROR_LINE( ) );
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
			bResult,vchMessage
		)
		VALUES
		(
			1,''
		);
	END;

	SELECT *
	FROM
		@Result;
	SET NOCOUNT OFF;
END

GO 


