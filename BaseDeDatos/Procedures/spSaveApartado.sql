IF OBJECT_ID( 'spSaveApartado' ) IS NULL
	EXEC ('CREATE PROCEDURE spSaveApartado AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE dbo.spSaveApartado
    @nvchNombreCliente NVARCHAR(400), 
    @mTotal            MONEY, 
    @bPagado           BIT, 
    @nvchComentario    NVARCHAR(2000),
    @Detalles          dbo.DTApartadoDetalle READONLY -- Tabla de detalles recibida
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @vchError    VARCHAR(200) = '';
    DECLARE @iIdApartado INT;

    DECLARE @Result AS TABLE (
        bResult     BIT            DEFAULT (1),
        vchMessage  VARCHAR(500)   DEFAULT (''), -- Resultado operativo o error
        iIdApartado INT            DEFAULT (-1)
    );

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Insertar registro en Apartado
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

        -- Insertar detalles en ApartadoDetalle, referenciando el Id del nuevo Apartado
        INSERT INTO dbo.ApartadoDetalle (
            iIdApartado,
            iIdArticulo,
            iCantidad,
            mPrecioFinal
        )
        SELECT
            @iIdApartado,
            d.iIdArticulo,
            d.iCantidad,
            d.mPrecioFinal
        FROM @Detalles d;

        /*
            Actualizar Inventario:
            - Restar iCantidad de smCantidad
            - Sumar iCantidad a smApartados
        */
        UPDATE inv
        SET 
            inv.smCantidad   = inv.smCantidad  - det.iCantidad,
            inv.smApartados  = inv.smApartados + det.iCantidad
        FROM 
            dbo.Inventario inv
            INNER JOIN @Detalles det ON inv.iIdArticulo = det.iIdArticulo
        WHERE 
            -- Solo actualizar si hay suficiente cantidad
            inv.smCantidad >= det.iCantidad;

        /*
            Opcional: Puedes manejar faltante/inventario insuficiente aquí.
            Ejemplo: si alguna fila no se actualizó por cantidad insuficiente, lanzar error.
        */
        

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @vchError = CONCAT('spSaveApartado: ', ERROR_MESSAGE(), ' en ', ERROR_PROCEDURE(), ' línea ', ERROR_LINE());
    END CATCH

    -- Indicar resultado final
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