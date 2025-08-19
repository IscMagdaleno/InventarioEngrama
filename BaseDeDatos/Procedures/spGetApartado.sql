IF OBJECT_ID('dbo.spGetApartado', 'P') IS NOT NULL
    DROP PROCEDURE dbo.spGetApartado;
GO
-- ============================================
-- spGetApartado: Devuelve datos de Apartado y ApartadoDetalle,
-- ajustando mTotal restando el total de abonos registrados.
-- ============================================
CREATE PROCEDURE dbo.spGetApartado
AS
BEGIN
    SET NOCOUNT ON;

    -- Tabla temporal para resultado enriquecido
    CREATE TABLE #Result (
        bResult BIT                 DEFAULT (1),
        vchMessage VARCHAR(500)     DEFAULT (''),
        iIdApartado INT             DEFAULT (-1),
        nvchNombreCliente NVARCHAR(400) DEFAULT(''),
        dtFechaApartado DATETIME    DEFAULT ('1900-01-01'),
        mTotal MONEY                DEFAULT (0),
        mSubTotal MONEY                DEFAULT (0),
        bPagado BIT                 DEFAULT (0),
        nvchComentario NVARCHAR(2000) DEFAULT(''),
        iIdApartadoDetalle INT      DEFAULT(-1),
        iIdArticulo INT             DEFAULT(-1),
        iCantidad INT               DEFAULT(-1),
        mPrecioFinal MONEY          DEFAULT(0)
    );

    BEGIN TRY
        -- Insertar Apartado + ApartadoDetalle,
        -- ajustando mTotal restando los abonos de AbonoApartado
        INSERT INTO #Result (
            iIdApartado,
            nvchNombreCliente,
            dtFechaApartado,
            mTotal,
            mSubTotal,
            bPagado,
            nvchComentario,
            iIdApartadoDetalle,
            iIdArticulo,
            iCantidad,
            mPrecioFinal
        )
        SELECT
            A.iIdApartado,
            A.nvchNombreCliente,
            A.dtFechaApartado,
            A.mTotal- ISNULL(AB.SumAbono, 0) AS mTotal,
            A.mTotal ,
            A.bPagado,
            A.nvchComentario,
            AD.iIdApartadoDetalle,
            AD.iIdArticulo,
            AD.iCantidad,
            AD.mPrecioFinal
        FROM dbo.Apartado AS A WITH (NOLOCK)
        INNER JOIN dbo.ApartadoDetalle AS AD WITH (NOLOCK)
            ON AD.iIdApartado = A.iIdApartado
        LEFT JOIN (
            -- Sumar todos los abonos por Apartado
            SELECT 
                iIdApartado, 
                SUM(mAbono) AS SumAbono
            FROM dbo.AbonoApartado WITH (NOLOCK)
            GROUP BY iIdApartado
        ) AS AB
            ON AB.iIdApartado = A.iIdApartado;

        -- Si no se insertó ningún registro, avisar
        IF NOT EXISTS (SELECT 1 FROM #Result)
        BEGIN
            INSERT INTO #Result (bResult, vchMessage)
            VALUES (0, 'No records found.');
        END
    END TRY
    BEGIN CATCH
        -- Manejo de error, concatenando detalles útiles
        INSERT INTO #Result (bResult, vchMessage)
        VALUES (0, CONCAT(ERROR_PROCEDURE(), ' : ', ERROR_MESSAGE(), ' - ', ERROR_LINE()));
        PRINT CONCAT(ERROR_PROCEDURE(), ' : ', ERROR_MESSAGE(), ' - ', ERROR_LINE());
    END CATCH

    -- Resultado final
    SELECT * FROM #Result WHERE bPagado = 0;

    DROP TABLE #Result;
END
GO
EXEC spGetApartado