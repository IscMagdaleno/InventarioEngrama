IF OBJECT_ID( 'spGetArticulo' ) IS NULL
	EXEC ('CREATE PROCEDURE spGetArticulo AS SET NOCOUNT ON;') 
GO 
ALTER PROCEDURE dbo.spGetArticulo
AS
BEGIN
    SET NOCOUNT ON;

    -- Tabla temporal para el resultado
    CREATE TABLE #Result (
        bResult           BIT           DEFAULT(1),
        vchMessage        VARCHAR(500)  DEFAULT(''),
        iIdArticulo       INT           DEFAULT(-1),
        iIdProveedor      INT           DEFAULT(-1),
        nvchNombre        NVARCHAR(200) DEFAULT(''),
        vchCodigo         VARCHAR(50)   DEFAULT(''),
        nvchDescripcion   NVARCHAR(1000)DEFAULT(''),
        mPrecioCompra     MONEY         DEFAULT(0),
        mPrecioVenta      MONEY         DEFAULT(0),
        smCantidad        SMALLINT      DEFAULT(0)   -- Nueva columna cantidad total artículo
    );

    BEGIN TRY
        INSERT INTO #Result (
            iIdProveedor,
            iIdArticulo,
            nvchNombre,
            vchCodigo,
            nvchDescripcion,
            mPrecioCompra,
            mPrecioVenta,
            smCantidad
        )
        SELECT 
            A.iIdProveedor,
            A.iIdArticulo,
            A.nvchNombre,
            A.vchCodigo,
            A.nvchDescripcion,
            A.mPrecioCompra,
            A.mPrecioVenta,
            ISNULL((I.smCantidad), 0) AS smCantidad  -- Cantidad total en inventario
        FROM 
            dbo.Articulo AS A WITH(NOLOCK)
        LEFT JOIN 
            dbo.Inventario AS I WITH(NOLOCK)  ON I.iIdArticulo = A.iIdArticulo
      

        -- Si no hay registros insertados, agrega mensaje
        IF NOT EXISTS (SELECT 1 FROM #Result)
        BEGIN
            INSERT INTO #Result (bResult, vchMessage)
            VALUES (0, 'No register found.');
        END
    END TRY
    BEGIN CATCH
        INSERT INTO #Result (bResult, vchMessage)
        SELECT 0, CONCAT(ERROR_PROCEDURE(), ' : ', ERROR_MESSAGE(), ' - ', ERROR_LINE());

        -- Opcional: solo para depuración en test, si es producción omitir
        PRINT CONCAT(ERROR_PROCEDURE(), ' : ', ERROR_MESSAGE(), ' - ', ERROR_LINE());
    END CATCH

    SELECT * FROM #Result;

    DROP TABLE #Result;
END
GO
exec spGetArticulo