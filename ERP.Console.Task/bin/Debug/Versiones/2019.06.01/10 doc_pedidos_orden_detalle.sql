if not exists (
	select 1
	from sysobjects
	where name = 'doc_pedidos_orden_detalle'
)
begin

CREATE TABLE [dbo].[doc_pedidos_orden_detalle](
	[PedidoDetalleId] [int] NOT NULL,
	[PedidoId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [decimal](14, 3) NOT NULL,
	[PrecioUnitario] [money] NOT NULL,
	[PorcDescuento] [decimal](5, 2) NOT NULL,
	[Descuento] [money] NOT NULL,
	[Impuestos] [money] NOT NULL,
	[Notas] [varchar](200) NULL,
	[Total] [money] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[TasaIVA] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_doc_pedidos_orden_detalle] PRIMARY KEY CLUSTERED 
(
	[PedidoDetalleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_pedidos_orden_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_detalle_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_pedidos_orden_detalle] CHECK CONSTRAINT [FK_doc_pedidos_orden_detalle_cat_productos]


ALTER TABLE [dbo].[doc_pedidos_orden_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_detalle_doc_pedidos_orden] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[doc_pedidos_orden] ([PedidoId])


ALTER TABLE [dbo].[doc_pedidos_orden_detalle] CHECK CONSTRAINT [FK_doc_pedidos_orden_detalle_doc_pedidos_orden]

END
GO


