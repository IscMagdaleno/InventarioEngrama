
-- 1. Agregar campo 'smApartados' a Inventario si no existe
IF NOT EXISTS (
    SELECT 1 FROM sys.columns
    WHERE object_id = OBJECT_ID('dbo.Inventario')
      AND name = 'smApartados'
)
BEGIN
    ALTER TABLE dbo.Inventario
    ADD smApartados SMALLINT NOT NULL DEFAULT 0;
END
GO

-- 2. Tabla: Apartado (Cabecera de apartados)
IF OBJECT_ID('dbo.Apartado', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Apartado
    (
        iIdApartado         INT             IDENTITY(1,1) PRIMARY KEY,  -- PK
        nvchNombreCliente   NVARCHAR(200)   NOT NULL,                   -- Solo nombre del cliente general
        dtFechaApartado     DATETIME        NOT NULL DEFAULT(GETDATE()),-- Fecha de inicio de apartado
        mTotal              MONEY           NOT NULL,                   -- Total del precio final de todos los artículos en el apartado
        bPagado             BIT             NOT NULL DEFAULT(0) ,        -- Indica si el monto total fue liquidado
        nvchComentario      NVARCHAR(1000)  NOT NULL
        -- Puedes agregar un campo de usuario responsable u observaciones si lo requieres
    );
END
GO

-- 3. Tabla: ApartadoDetalle (Detalles de los artículos apartados)
IF OBJECT_ID('dbo.ApartadoDetalle', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.ApartadoDetalle
    (
        iIdApartadoDetalle  INT             IDENTITY(1,1) PRIMARY KEY,
        iIdApartado         INT             NOT NULL,           -- FK hacia Apartado
        iIdArticulo         INT             NOT NULL,           -- FK hacia Articulo
        iCantidad           INT             NOT NULL CHECK (iCantidad > 0),
        mPrecioFinal        MONEY           NOT NULL,           -- Precio final por la línea (NO unitario)
        
        CONSTRAINT FK_ApartadoDetalle_Apartado FOREIGN KEY (iIdApartado)
            REFERENCES dbo.Apartado(iIdApartado),
        CONSTRAINT FK_ApartadoDetalle_Articulo FOREIGN KEY (iIdArticulo)
            REFERENCES dbo.Articulo(iIdArticulo)
    );
END
GO

-- 4. Tabla: AbonoApartado (Para registrar los abonos de cada apartado)
IF OBJECT_ID('dbo.AbonoApartado', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.AbonoApartado
    (
        iIdAbonoApartado    INT             IDENTITY(1,1) PRIMARY KEY,
        iIdApartado         INT             NOT NULL,               -- FK hacia Apartado
        mAbono              MONEY           NOT NULL CHECK (mAbono > 0),
        dtFechaAbono        DATETIME        NOT NULL DEFAULT(GETDATE()),
        
        CONSTRAINT FK_AbonoApartado_Apartado FOREIGN KEY (iIdApartado)
            REFERENCES dbo.Apartado(iIdApartado)
    );
END
GO

-- Opcional: Índices para consultas rápidas (ajusta según tus necesidades de consulta)
CREATE INDEX IX_ApartadoDetalle_iIdApartado ON dbo.ApartadoDetalle(iIdApartado);
CREATE INDEX IX_AbonoApartado_iIdApartado ON dbo.AbonoApartado(iIdApartado);
GO

IF NOT EXISTS (SELECT 1 FROM sys.types WHERE is_table_type = 1 AND name = 'DTApartadoDetalle')
BEGIN
    CREATE TYPE dbo.DTApartadoDetalle AS TABLE
    (
        iIdApartadoDetalle INT          DEFAULT (-1),
        iIdApartado        INT          DEFAULT (-1),
        iIdArticulo        INT          DEFAULT (-1),
        iCantidad          INT          DEFAULT (-1),
        mPrecioFinal       MONEY        DEFAULT (0)
    );
END
GO