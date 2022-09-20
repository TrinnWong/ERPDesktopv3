if not exists (
	select 1
	from sysobjects
	where name = 'doc_pedidos_orden_mesero'
)
begin

CREATE TABLE [dbo].[doc_pedidos_orden_mesero](
	[PedidoOrdenId] [int] NOT NULL,
	[EmpleadoId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_pedidos_orden_mesero] PRIMARY KEY CLUSTERED 
(
	[PedidoOrdenId] ASC,
	[EmpleadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_pedidos_orden_mesero]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_mesero_doc_pedidos_orden] FOREIGN KEY([PedidoOrdenId])
REFERENCES [dbo].[doc_pedidos_orden] ([PedidoId])


ALTER TABLE [dbo].[doc_pedidos_orden_mesero] CHECK CONSTRAINT [FK_doc_pedidos_orden_mesero_doc_pedidos_orden]


ALTER TABLE [dbo].[doc_pedidos_orden_mesero]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_mesero_rh_empleados] FOREIGN KEY([EmpleadoId])
REFERENCES [dbo].[rh_empleados] ([NumEmpleado])


ALTER TABLE [dbo].[doc_pedidos_orden_mesero] CHECK CONSTRAINT [FK_doc_pedidos_orden_mesero_rh_empleados]
END
GO


