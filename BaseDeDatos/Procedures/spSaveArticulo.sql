IF OBJECT_ID( 'spSaveArticulo' ) IS NULL
	EXEC ('CREATE PROCEDURE spSaveArticulo AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE dbo.spSaveArticulo
    @iIdArticulo    INT,
    @iIdProveedor   INT,
    @nvchNombre     NVARCHAR(200),
    @vchCodigo      VARCHAR(50),
    @nvchDescripcion NVARCHAR(1000),
    @mPrecioCompra  MONEY,
    @mPrecioVenta   MONEY,
    @smCantidad     SMALLINT           -- Nuevo campo para cantidad
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON; -- Finaliza transacción automáticamente en caso de error

    DECLARE @vchError VARCHAR(500) = '';

    DECLARE @Result AS TABLE
    (
        bResult     BIT           DEFAULT (1),
        vchMessage  VARCHAR(500)  DEFAULT (''),
        iIdArticulo INT           DEFAULT (-1)
    );

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Insertar nuevo Articulo
        IF @iIdArticulo <= 0
        BEGIN
            INSERT INTO dbo.Articulo
            (
                nvchNombre,
                vchCodigo,
                mPrecioCompra,
                mPrecioVenta,
                iIdProveedor,
                nvchDescripcion
            )
            VALUES
            (
                @nvchNombre,
                @vchCodigo,
                @mPrecioCompra,
                @mPrecioVenta,
                @iIdProveedor,
                @nvchDescripcion
            );

            SET @iIdArticulo = CAST(SCOPE_IDENTITY() AS INT); -- Obtener nuevo ID
        END
        ELSE
        BEGIN
            -- Actualizar Articulo existente
            UPDATE dbo.Articulo WITH(ROWLOCK)
            SET
                nvchNombre      = @nvchNombre,
                vchCodigo       = @vchCodigo,
                mPrecioCompra   = @mPrecioCompra,
                mPrecioVenta    = @mPrecioVenta,
                iIdProveedor    = @iIdProveedor,
                nvchDescripcion = @nvchDescripcion
            WHERE iIdArticulo = @iIdArticulo;
        END

        -- Manejo del Inventario: Insertar o actualizar según corresponda
        IF NOT EXISTS (SELECT 1 FROM dbo.Inventario WHERE iIdArticulo = @iIdArticulo)
        BEGIN
            -- Nuevo inventario para el artículo
            INSERT INTO dbo.Inventario (iIdArticulo, smCantidad, smApartados)
            VALUES (@iIdArticulo, @smCantidad, 0);
        END
        ELSE
        BEGIN
            -- Actualizar cantidad del inventario existente
            UPDATE dbo.Inventario
            SET smCantidad = @smCantidad
            WHERE iIdArticulo = @iIdArticulo;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        SET @vchError = CONCAT(
            'spSaveArticulo: ', ERROR_MESSAGE(), 
            ' [', ERROR_PROCEDURE(), ' - Line ', ERROR_LINE(), ']'
        );
        PRINT @vchError;
    END CATCH

    -- Resultado
    IF LEN(@vchError) > 0
    BEGIN
        INSERT INTO @Result (bResult, vchMessage)
        VALUES (0, @vchError);
    END
    ELSE
    BEGIN
        INSERT INTO @Result (bResult, vchMessage, iIdArticulo)
        VALUES (1, '', @iIdArticulo);
    END

    SELECT * FROM @Result;

    SET NOCOUNT OFF;
END

GO 


