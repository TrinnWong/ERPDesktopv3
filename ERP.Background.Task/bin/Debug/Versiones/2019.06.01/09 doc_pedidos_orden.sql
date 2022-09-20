if not exists (
	select 1
	from sysobjects
	where name = 'doc_pedidos_orden'
)
begin

CREATE TABLE [dbo].[doc_pedidos_orden](
	[PedidoId] [int] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[ComandaId] [int] NULL,
	[PorcDescuento] [decimal](5, 2) NOT NULL,
	[Subtotal] [money] NOT NULL,
	[Descuento] [money] NOT NULL,
	[Impuestos] [money] NOT NULL,
	[Total] [money] NOT NULL,
	[ClienteId] [int] NULL,
	[MotivoCancelacion] [varchar](150) NULL,
	[Activo] [bit] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_cat_rest_comandas_orden] PRIMARY KEY CLUSTERED 
(
	[PedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_pedidos_orden]  WITH CHECK ADD  CONSTRAINT [FK_cat_rest_comandas_orden_cat_clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[cat_clientes] ([ClienteId])


ALTER TABLE [dbo].[doc_pedidos_orden] CHECK CONSTRAINT [FK_cat_rest_comandas_orden_cat_clientes]

ALTER TABLE [dbo].[doc_pedidos_orden]  WITH CHECK ADD  CONSTRAINT [FK_cat_rest_comandas_orden_cat_rest_comandas] FOREIGN KEY([ComandaId])
REFERENCES [dbo].[cat_rest_comandas] ([ComandaId])


ALTER TABLE [dbo].[doc_pedidos_orden] CHECK CONSTRAINT [FK_cat_rest_comandas_orden_cat_rest_comandas]


ALTER TABLE [dbo].[doc_pedidos_orden]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_pedidos_orden] CHECK CONSTRAINT [FK_doc_pedidos_orden_cat_sucursales]
END
GO


