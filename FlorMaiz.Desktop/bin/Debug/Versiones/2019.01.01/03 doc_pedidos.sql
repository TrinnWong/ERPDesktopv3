if not exists (
	select 1
	from sysobjects
	where name = 'doc_pedidos'
)
begin

CREATE TABLE [dbo].[doc_pedidos](
	[PedidoId] [int] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[PedidoConfiguracionId] [int] NULL,
	[ClienteId] [int] NOT NULL,
	[CiudadId] [int] NOT NULL,
	[LugarEntrega] [varchar](300) NULL,
	[FechaEntrega] [date] NOT NULL,
	[HoraEntrega] [timestamp] NOT NULL,
	[EstatusId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_pedidos] PRIMARY KEY CLUSTERED 
(
	[PedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[doc_pedidos]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_cat_clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[cat_clientes] ([ClienteId])


ALTER TABLE [dbo].[doc_pedidos] CHECK CONSTRAINT [FK_doc_pedidos_cat_clientes]


ALTER TABLE [dbo].[doc_pedidos]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_cat_municipios] FOREIGN KEY([CiudadId])
REFERENCES [dbo].[cat_municipios] ([MunicipioId])


ALTER TABLE [dbo].[doc_pedidos] CHECK CONSTRAINT [FK_doc_pedidos_cat_municipios]


ALTER TABLE [dbo].[doc_pedidos]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_pedidos] CHECK CONSTRAINT [FK_doc_pedidos_cat_sucursales]


ALTER TABLE [dbo].[doc_pedidos]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_pedidos] CHECK CONSTRAINT [FK_doc_pedidos_cat_usuarios]


ALTER TABLE [dbo].[doc_pedidos]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_doc_pedidos_configuracion] FOREIGN KEY([PedidoConfiguracionId])
REFERENCES [dbo].[doc_pedidos_configuracion] ([PedidoConfiguracionId])


ALTER TABLE [dbo].[doc_pedidos] CHECK CONSTRAINT [FK_doc_pedidos_doc_pedidos_configuracion]




END

