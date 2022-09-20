if not exists (
	select 1
	from sysobjects
	where name = 'doc_pedidos_orden_programacion'
)
begin

CREATE TABLE [dbo].[doc_pedidos_orden_programacion](
	[PedidoProgramacionId] [int] NOT NULL,
	[PedidoId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[FechaProgramada] [datetime] NOT NULL,
	[HoraProgramada] [time](7) NOT NULL,
	[CreadoEl] [int] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_pedidos_orden_programacion] PRIMARY KEY CLUSTERED 
(
	[PedidoProgramacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_pedidos_orden_programacion]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_programacion_cat_clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[cat_clientes] ([ClienteId])


ALTER TABLE [dbo].[doc_pedidos_orden_programacion] CHECK CONSTRAINT [FK_doc_pedidos_orden_programacion_cat_clientes]


ALTER TABLE [dbo].[doc_pedidos_orden_programacion]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_programacion_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_pedidos_orden_programacion] CHECK CONSTRAINT [FK_doc_pedidos_orden_programacion_cat_usuarios]


ALTER TABLE [dbo].[doc_pedidos_orden_programacion]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_programacion_doc_pedidos_orden] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[doc_pedidos_orden] ([PedidoId])


ALTER TABLE [dbo].[doc_pedidos_orden_programacion] CHECK CONSTRAINT [FK_doc_pedidos_orden_programacion_doc_pedidos_orden]


END
GO
