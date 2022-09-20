if not exists(
	select 1
	from sysobjects
	where name = 'doc_pedidos_clientes_det'
)
begin

CREATE TABLE [dbo].[doc_pedidos_clientes_det](
	[PedidoClienteDetId] [int] NOT NULL,
	[PedidoClienteId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [decimal](8, 2) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_pedidos_clientes_det] PRIMARY KEY CLUSTERED 
(
	[PedidoClienteDetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



ALTER TABLE [dbo].[doc_pedidos_clientes_det]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_clientes_det_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])

ALTER TABLE [dbo].[doc_pedidos_clientes_det] CHECK CONSTRAINT [FK_doc_pedidos_clientes_det_cat_productos]


ALTER TABLE [dbo].[doc_pedidos_clientes_det]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_clientes_det_doc_pedidos_clientes] FOREIGN KEY([PedidoClienteDetId])
REFERENCES [dbo].[doc_pedidos_clientes] ([PedidoClienteId])


ALTER TABLE [dbo].[doc_pedidos_clientes_det] CHECK CONSTRAINT [FK_doc_pedidos_clientes_det_doc_pedidos_clientes]

end

