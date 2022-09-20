if not exists (
	select 1
	from sysobjects
	where name = 'doc_pedidos_orden_cargos'
)
begin

CREATE TABLE [dbo].[doc_pedidos_orden_cargos](
	[PedidoId] [int] NOT NULL,
	[CargoAdicionalId] [smallint] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_pedidos_orden_cargos] PRIMARY KEY CLUSTERED 
(
	[PedidoId] ASC,
	[CargoAdicionalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_pedidos_orden_cargos]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_cargos_cat_cargos_adicionales] FOREIGN KEY([CargoAdicionalId])
REFERENCES [dbo].[cat_cargos_adicionales] ([CargoAdicionalId])


ALTER TABLE [dbo].[doc_pedidos_orden_cargos] CHECK CONSTRAINT [FK_doc_pedidos_orden_cargos_cat_cargos_adicionales]



ALTER TABLE [dbo].[doc_pedidos_orden_cargos]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_cargos_doc_pedidos_orden] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[doc_pedidos_orden] ([PedidoId])


ALTER TABLE [dbo].[doc_pedidos_orden_cargos] CHECK CONSTRAINT [FK_doc_pedidos_orden_cargos_doc_pedidos_orden]
END
GO


