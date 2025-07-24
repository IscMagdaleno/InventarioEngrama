IF OBJECT_ID('dbo.spGetApartado', 'P') IS NOT NULL
    DROP PROCEDURE dbo.spGetApartado;
GO

CREATE PROCEDURE dbo.spGetApartado
AS
BEGIN
    SET NOCOUNT ON;

    -- Tabla temporal para el resultado, incluye campos de Apartado y ApartadoDetalle
    CREATE TABLE #Result (
        bResult BIT                DEFAULT (1),
        vchMessage VARCHAR(500)    DEFAULT (''),
        iIdApartado INT            DEFAULT (-1),
        nvchNombreCliente NVARCHAR(400) DEFAULT(''),
        dtFechaApartado DATETIME   DEFAULT ('1900-01-01'),
        mTotal MONEY               DEFAULT (0),
        bPagado BIT                DEFAULT (0),
        nvchComentario NVARCHAR(2000) DEFAULT(''),
        iIdApartadoDetalle INT     DEFAULT(-1),
        iIdArticulo INT            DEFAULT(-1),
        iCantidad INT              DEFAULT(-1),
        mPrecioFinal MONEY         DEFAULT(0)
    );

    BEGIN TRY
        -- Insertar datos combinados de Apartado y ApartadoDetalle
        INSERT INTO #Result (
            iIdApartado,
            nvchNombreCliente,
            dtFechaApartado,
            mTotal,
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
            A.mTotal,
            A.bPagado,
            A.nvchComentario,
            AD.iIdApartadoDetalle,
            AD.iIdArticulo,
            AD.iCantidad,
            AD.mPrecioFinal
        FROM
            dbo.Apartado AS A WITH (NOLOCK)
            INNER JOIN dbo.ApartadoDetalle AS AD WITH (NOLOCK)
                ON AD.iIdApartado = A.iIdApartado;

        -- Si no se insertó ningún registro, indicamos que no hay resultados
        IF NOT EXISTS (SELECT 1 FROM #Result)
        BEGIN
            INSERT INTO #Result (bResult, vchMessage)
            VALUES (0, 'No records found.');
        END
    END TRY
    BEGIN CATCH
        -- En caso de error, informamos en la tabla temporal
        INSERT INTO #Result (bResult, vchMessage)
        VALUES (0, CONCAT(ERROR_PROCEDURE(), ' : ', ERROR_MESSAGE(), ' - ', ERROR_LINE()));
        PRINT CONCAT(ERROR_PROCEDURE(), ' : ', ERROR_MESSAGE(), ' - ', ERROR_LINE());
    END CATCH

    -- Devolver el contenido de #Result
    SELECT * FROM #Result;

    DROP TABLE #Result;
END
GO