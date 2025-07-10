
/****** Object:  Table [dbo].[Articulo]    Script Date: 10/07/2025 01:14:38 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Articulo](
	[iIdArticulo] [int] IDENTITY(1,1) NOT NULL,
	[nvchNombre] [nvarchar](100) NOT NULL,
	[vchCodigo] [varchar](50) NOT NULL,
	[mPrecioCompra] [money] NOT NULL,
	[mPrecioVenta] [money] NOT NULL,
	[iIdProveedor] [int] NULL,
	[nvchDescripcion] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[iIdArticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_iIdProveedor] FOREIGN KEY([iIdProveedor])
REFERENCES [dbo].[Proveedor] ([iIdProveedor])
GO

ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK_Articulo_iIdProveedor]
GO



CREATE TABLE [dbo].[Inventario](
	[iIdInventario] [int] IDENTITY(1,1) NOT NULL,
	[iIdArticulo] [int] NOT NULL,
	[smCantidad] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[iIdInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD FOREIGN KEY([iIdArticulo])
REFERENCES [dbo].[Articulo] ([iIdArticulo])
GO

ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD CHECK  (([smCantidad]>=(0)))
GO


CREATE TABLE [dbo].[Pedido](
	[iIdPedido] [int] IDENTITY(1,1) NOT NULL,
	[iIdProveedor] [int] NOT NULL,
	[dtFecha] [datetime] NOT NULL,
	[nvchDescripcion] [nvarchar](3000) NULL,
	[mEnvio] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[iIdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pedido] ADD  DEFAULT (getdate()) FOR [dtFecha]
GO

ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD FOREIGN KEY([iIdProveedor])
REFERENCES [dbo].[Proveedor] ([iIdProveedor])
GO



CREATE TABLE [dbo].[PedidoDetalle](
	[iIdPedidoDetalle] [int] IDENTITY(1,1) NOT NULL,
	[iIdPedido] [int] NOT NULL,
	[iIdArticulo] [int] NOT NULL,
	[smCantidad] [smallint] NOT NULL,
	[mPrecioUnitario] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[iIdPedidoDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PedidoDetalle]  WITH CHECK ADD FOREIGN KEY([iIdArticulo])
REFERENCES [dbo].[Articulo] ([iIdArticulo])
GO

ALTER TABLE [dbo].[PedidoDetalle]  WITH CHECK ADD FOREIGN KEY([iIdPedido])
REFERENCES [dbo].[Pedido] ([iIdPedido])
GO

ALTER TABLE [dbo].[PedidoDetalle]  WITH CHECK ADD CHECK  (([smCantidad]>(0)))
GO



CREATE TABLE [dbo].[Proveedor](
	[iIdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[nvchNombre] [nvarchar](100) NOT NULL,
	[vchTelefono] [varchar](20) NOT NULL,
	[nvchDireccion] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[iIdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Venta](
	[iIdVenta] [int] IDENTITY(1,1) NOT NULL,
	[iIdArticulo] [int] NOT NULL,
	[iCantidad] [int] NOT NULL,
	[mPrecioFinal] [money] NOT NULL,
	[dtFechaVenta] [datetime] NOT NULL,
	[vchReferenciaVenta] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[iIdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Venta] ADD  CONSTRAINT [DF_Venta_Fecha]  DEFAULT (getdate()) FOR [dtFechaVenta]
GO

ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Articulo] FOREIGN KEY([iIdArticulo])
REFERENCES [dbo].[Articulo] ([iIdArticulo])
GO

ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Articulo]
GO

ALTER TABLE [dbo].[Venta]  WITH CHECK ADD CHECK  (([iCantidad]>(0)))
GO




