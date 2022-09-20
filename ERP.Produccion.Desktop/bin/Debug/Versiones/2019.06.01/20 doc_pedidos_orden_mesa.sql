if not exists (
	select 1
	from sysobjects
	where name = 'doc_pedidos_orden_mesa'
)
begin

CREATE TABLE [dbo].[doc_pedidos_orden_mesa](
	[PedidoOrdenId] [int] NOT NULL,
	[MesaId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_pedidos_orden_mesa] PRIMARY KEY CLUSTERED 
(
	[PedidoOrdenId] ASC,
	[MesaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_pedidos_orden_mesa]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_mesa_cat_rest_mesas] FOREIGN KEY([MesaId])
REFERENCES [dbo].[cat_rest_mesas] ([MesaId])


ALTER TABLE [dbo].[doc_pedidos_orden_mesa] CHECK CONSTRAINT [FK_doc_pedidos_orden_mesa_cat_rest_mesas]


ALTER TABLE [dbo].[doc_pedidos_orden_mesa]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_mesa_doc_pedidos_orden] FOREIGN KEY([PedidoOrdenId])
REFERENCES [dbo].[doc_pedidos_orden] ([PedidoId])


ALTER TABLE [dbo].[doc_pedidos_orden_mesa] CHECK CONSTRAINT [FK_doc_pedidos_orden_mesa_doc_pedidos_orden]
End
GO


