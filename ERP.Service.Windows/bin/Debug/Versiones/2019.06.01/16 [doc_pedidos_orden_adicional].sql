if not exists (
	select 1
	from sysobjects
	where name = 'doc_pedidos_orden_adicional'
)
begin
CREATE TABLE [dbo].[doc_pedidos_orden_adicional](
	[PedidoDetalleId] [int] NOT NULL,
	[AdicionalId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_pedidos_orden_adicional] PRIMARY KEY CLUSTERED 
(
	[PedidoDetalleId] ASC,
	[AdicionalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_pedidos_orden_adicional]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_adicional_cat_rest_platillo_adicionales] FOREIGN KEY([AdicionalId])
REFERENCES [dbo].[cat_rest_platillo_adicionales] ([Id])


ALTER TABLE [dbo].[doc_pedidos_orden_adicional] CHECK CONSTRAINT [FK_doc_pedidos_orden_adicional_cat_rest_platillo_adicionales]


ALTER TABLE [dbo].[doc_pedidos_orden_adicional]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_adicional_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_pedidos_orden_adicional] CHECK CONSTRAINT [FK_doc_pedidos_orden_adicional_cat_usuarios]


ALTER TABLE [dbo].[doc_pedidos_orden_adicional]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_adicional_doc_pedidos_orden_detalle] FOREIGN KEY([PedidoDetalleId])
REFERENCES [dbo].[doc_pedidos_orden_detalle] ([PedidoDetalleId])


ALTER TABLE [dbo].[doc_pedidos_orden_adicional] CHECK CONSTRAINT [FK_doc_pedidos_orden_adicional_doc_pedidos_orden_detalle]
END
GO


