if not exists (
	select 1
	from sysobjects
	where name = 'doc_pedidos_orden_ingre'
)
begin

CREATE TABLE [dbo].[doc_pedidos_orden_ingre](
	[PedidoDetalleId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Con] [bit] NOT NULL,
	[Sin] [bit] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_pedidos_orden_ingre] PRIMARY KEY CLUSTERED 
(
	[PedidoDetalleId] ASC,
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_pedidos_orden_ingre]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_ingre_cat_productos_base] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_pedidos_orden_ingre] CHECK CONSTRAINT [FK_doc_pedidos_orden_ingre_cat_productos_base]


ALTER TABLE [dbo].[doc_pedidos_orden_ingre]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_ingre_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_pedidos_orden_ingre] CHECK CONSTRAINT [FK_doc_pedidos_orden_ingre_cat_usuarios]


ALTER TABLE [dbo].[doc_pedidos_orden_ingre]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_ingre_doc_pedidos_orden_detalle] FOREIGN KEY([PedidoDetalleId])
REFERENCES [dbo].[doc_pedidos_orden_detalle] ([PedidoDetalleId])


ALTER TABLE [dbo].[doc_pedidos_orden_ingre] CHECK CONSTRAINT [FK_doc_pedidos_orden_ingre_doc_pedidos_orden_detalle]
END
GO


