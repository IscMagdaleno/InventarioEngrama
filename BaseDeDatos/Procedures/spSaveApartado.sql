IF OBJECT_ID('dbo.spSaveApartado', 'P') IS NOT NULL
    DROP PROCEDURE dbo.spSaveApartado;
GO

CREATE PROCEDURE dbo.spSaveApartado
    @nvchNombreCliente NVARCHAR(400), 
    @mTotal            MONEY, 
    @bPagado           BIT, 
    @nvchComentario    NVARCHAR(2000),
    @Detalles          dbo.DTApartadoDetalle READONLY -- Nuevo parámetro de tipo tabla
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @vchError VARCHAR(200) = '',
    @iIdApartado INT;

    DECLARE @Result AS TABLE (
        bResult     BIT            DEFAULT (1),
        vchMessage  VARCHAR(500)   DEFAULT (''),
        iIdApartado INT           DEFAULT (-1)
    );

    BEGIN TRY
        BEGIN TRANSACTION;


            INSERT INTO dbo.Apartado (
                nvchNombreCliente,
                dtFechaApartado,
                mTotal,
                bPagado,
                nvchComentario
            )
            VALUES (
                @nvchNombreCliente,
                GETDATE(),
                @mTotal,
                @bPagado,
                @nvchComentario
            );

            SET @iIdApartado = SCOPE_IDENTITY();
    
        -- Insertar detalles en la tabla ApartadoDetalle, forzando la relación al Apartado
        INSERT INTO dbo.ApartadoDetalle (
            iIdApartado,
            iIdArticulo,
            iCantidad,
            mPrecioFinal
        )
        SELECT
            @iIdApartado,           -- Relacionar al Apartado 'padre'
            d.iIdArticulo,
            d.iCantidad,
            d.mPrecioFinal
        FROM @Detalles d;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        SET @vchError = CONCAT('spSaveApartado: ', ERROR_MESSAGE(), ' ', ERROR_PROCEDURE(), ' ', ERROR_LINE());
    END CATCH

    -- Resultados según éxito o error
    IF LEN(@vchError) > 0
    BEGIN
        INSERT INTO @Result (bResult, vchMessage)
        VALUES (0, @vchError);
    END
    ELSE
    BEGIN
        INSERT INTO @Result (bResult, vchMessage, iIdApartado)
        VALUES (1, '', @iIdApartado);
    END

    SELECT *
    FROM @Result;

    SET NOCOUNT OFF;
END
GO