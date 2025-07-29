IF OBJECT_ID( 'spGetPedido' ) IS NULL
	EXEC ('CREATE PROCEDURE spGetPedido AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE dbo.spGetPedido
AS
BEGIN
    SET NOCOUNT ON;

    -- Tabla temporal para el resultado
    CREATE TABLE #Result (
        bResult BIT             DEFAULT(1),
        vchMessage VARCHAR(500) DEFAULT(''),
        iIdPedido INT           DEFAULT(-1),
        iIdProveedor INT        DEFAULT(-1),
        dtFecha DATETIME        DEFAULT('1900-01-01'),
        nvchDescripcion NVARCHAR(4000) DEFAULT(N''),  -- tipo y tamaño real de Pedido
        mEnvio MONEY           DEFAULT(0),
        nvchNombre VARCHAR(200) DEFAULT('')
    );

    BEGIN TRY
        -- Insertar datos de Pedido con join a Proveedor (nvchNombre)
        INSERT INTO #Result
        (
            iIdPedido,
            iIdProveedor,
            dtFecha,
            nvchDescripcion,
            mEnvio,
            nvchNombre
        )
        SELECT
            P.iIdPedido,
            P.iIdProveedor,
            P.dtFecha,
            P.nvchDescripcion,
            P.mEnvio,
            PR.nvchNombre
        FROM
            dbo.Pedido P WITH(NOLOCK)
            INNER JOIN dbo.Proveedor PR ON P.iIdProveedor = PR.iIdProveedor;

        -- Si no se insertó ningún registro, mostrar mensaje
        IF NOT EXISTS (SELECT 1 FROM #Result WHERE bResult = 1)
        BEGIN
            INSERT INTO #Result (bResult, vchMessage)
            VALUES (0, 'No register found.');
        END
    END TRY
    BEGIN CATCH
        -- Captura y muestra error
        INSERT INTO #Result (bResult, vchMessage)
        SELECT 0, CONCAT(ERROR_PROCEDURE(), ' : ', ERROR_MESSAGE(), ' - ', ERROR_LINE());
        PRINT CONCAT(ERROR_PROCEDURE(), ' : ', ERROR_MESSAGE(), ' - ', ERROR_LINE());
    END CATCH;

    -- Devuelve todos los resultados
    SELECT
        bResult,
        vchMessage,
        iIdPedido,
        iIdProveedor,
        dtFecha,
        nvchDescripcion,
        mEnvio,
        nvchNombre
    FROM #Result;

    DROP TABLE #Result;
END
GO
exec spGetPedido