IF OBJECT_ID( 'spSaveAbonoApartado' ) IS NULL
	EXEC ('CREATE PROCEDURE spSaveAbonoApartado AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE dbo.spSaveAbonoApartado
(
    @iIdAbonoApartado INT = NULL OUTPUT,
    @iIdApartado      INT,
    @mAbono           MONEY
)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @vchError          VARCHAR(200)  = '';
    DECLARE @mTotalPagar       MONEY;
    DECLARE @mTotalAbonado     MONEY;
    DECLARE @dtFechaVenta      DATETIME      = GETDATE();
    DECLARE @vchReferenciaVenta VARCHAR(100);

    -- Tabla de resultado estructurado
    DECLARE @Result TABLE (
        bResult            BIT            DEFAULT (1),
        vchMessage         VARCHAR(500)   DEFAULT (''),
        iIdAbonoApartado   INT            DEFAULT (-1)
    );

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Insertar el nuevo abono
        INSERT INTO dbo.AbonoApartado (iIdApartado, mAbono, dtFechaAbono)
        VALUES (@iIdApartado, @mAbono, @dtFechaVenta);

        SET @iIdAbonoApartado = SCOPE_IDENTITY();

        -- Obtener el total a pagar y el total abonado
        SELECT @mTotalPagar = mTotal
        FROM dbo.Apartado
        WHERE iIdApartado = @iIdApartado;

        SELECT @mTotalAbonado = SUM(mAbono)
        FROM dbo.AbonoApartado
        WHERE iIdApartado = @iIdApartado;

        SET @vchReferenciaVenta = CONCAT('Apartado #', @iIdApartado);

        -- Si se liquidó el apartado...
        IF (@mTotalAbonado >= @mTotalPagar)
        BEGIN
            -- Marcar apartado como pagado
            UPDATE dbo.Apartado
            SET bPagado = 1
            WHERE iIdApartado = @iIdApartado;

            -- Insertar los artículos en la tabla Venta
            INSERT INTO dbo.Venta (
                iIdArticulo,
                iCantidad,
                mPrecioFinal,
                dtFechaVenta,
                vchReferenciaVenta
            )
            SELECT
                ad.iIdArticulo,
                ad.iCantidad,
                ad.mPrecioFinal,
                @dtFechaVenta,
                @vchReferenciaVenta
            FROM dbo.ApartadoDetalle ad
            WHERE ad.iIdApartado = @iIdApartado;

            -- Actualizar Inventario (quitar de smApartados la cantidad vendida)
            UPDATE inv
            SET inv.smApartados = 
                CASE 
                    WHEN inv.smApartados >= ad.iCantidad THEN inv.smApartados - ad.iCantidad
                    ELSE 0
                END
            FROM dbo.Inventario inv
            INNER JOIN dbo.ApartadoDetalle ad
                ON inv.iIdArticulo = ad.iIdArticulo
            WHERE ad.iIdApartado = @iIdApartado;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        SET @vchError = CONCAT(
            'spSaveAbonoApartado: ',
            ERROR_MESSAGE(),
            ' ',
            ERROR_PROCEDURE(),
            ' ',
            ERROR_LINE()
        );
        PRINT @vchError;
    END CATCH;

    -- Registrar resultado final
    IF LEN(@vchError) > 0
    BEGIN
        INSERT INTO @Result (bResult, vchMessage)
        VALUES (0, @vchError);
    END
    ELSE
    BEGIN
        INSERT INTO @Result (bResult, vchMessage, iIdAbonoApartado)
        VALUES (1, '', @iIdAbonoApartado);
    END

    SELECT *
    FROM @Result;

    SET NOCOUNT OFF;
END
GO