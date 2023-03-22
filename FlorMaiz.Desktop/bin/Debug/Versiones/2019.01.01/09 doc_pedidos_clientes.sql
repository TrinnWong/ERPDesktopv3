if not exists (
	select 1
	from sysobjects
	where name = 'doc_pedidos_clientes'
)
begin

	
CREATE TABLE [dbo].[doc_pedidos_clientes](
	[PedidoClienteId] [int] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[EstatusId] [smallint] NOT NULL,
	[FechaEntregaProgramada] [datetime] NOT NULL,
	[HoraEntrega] [time](7) NULL,
	[FechaEntregaReal] [datetime] NULL,
	[SitioEntregaId] [smallint] NULL,
	[ClienteDireccionId] [int] NULL,
	[CreadoEl] [datetime] NOT NULL,
	[PedidoConfiguracionId] [int] NULL,
 CONSTRAINT [PK_doc_pedidos_clientes] PRIMARY KEY CLUSTERED 
(
	[PedidoClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



ALTER TABLE [dbo].[doc_pedidos_clientes]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_clientes_cat_clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[cat_clientes] ([ClienteId])

ALTER TABLE [dbo].[doc_pedidos_clientes] CHECK CONSTRAINT [FK_doc_pedidos_clientes_cat_clientes]


ALTER TABLE [dbo].[doc_pedidos_clientes]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_clientes_cat_clientes_direcciones] FOREIGN KEY([ClienteDireccionId])
REFERENCES [dbo].[cat_clientes_direcciones] ([ClienteDireccionId])


ALTER TABLE [dbo].[doc_pedidos_clientes] CHECK CONSTRAINT [FK_doc_pedidos_clientes_cat_clientes_direcciones]


ALTER TABLE [dbo].[doc_pedidos_clientes]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_clientes_cat_estatus_pedido] FOREIGN KEY([EstatusId])
REFERENCES [dbo].[cat_estatus_pedido] ([EstatusPedidoId])


ALTER TABLE [dbo].[doc_pedidos_clientes] CHECK CONSTRAINT [FK_doc_pedidos_clientes_cat_estatus_pedido]


ALTER TABLE [dbo].[doc_pedidos_clientes]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_clientes_cat_sitios_entrega_pedido] FOREIGN KEY([SitioEntregaId])
REFERENCES [dbo].[cat_sitios_entrega_pedido] ([SitioEntregaPedidoId])


ALTER TABLE [dbo].[doc_pedidos_clientes] CHECK CONSTRAINT [FK_doc_pedidos_clientes_cat_sitios_entrega_pedido]


ALTER TABLE [dbo].[doc_pedidos_clientes]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_clientes_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_pedidos_clientes] CHECK CONSTRAINT [FK_doc_pedidos_clientes_cat_sucursales]


ALTER TABLE [dbo].[doc_pedidos_clientes]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_clientes_doc_pedidos_configuracion] FOREIGN KEY([PedidoConfiguracionId])
REFERENCES [dbo].[doc_pedidos_configuracion] ([PedidoConfiguracionId])


ALTER TABLE [dbo].[doc_pedidos_clientes] CHECK CONSTRAINT [FK_doc_pedidos_clientes_doc_pedidos_configuracion]


END

