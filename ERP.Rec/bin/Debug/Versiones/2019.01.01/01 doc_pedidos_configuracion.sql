if not exists (
	select 1
	from sysobjects
	where name = 'doc_pedidos_configuracion'
)
begin

	
CREATE TABLE [dbo].[doc_pedidos_configuracion](
	[PedidoConfiguracionId] [int] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Inicio] [date] NOT NULL,
	[Cierre] [date] NOT NULL,
	[FechaLlegada] [date] NULL,
	[FechaInicioEntrega] [date] NULL,
	[FechaFinEntrega] [date] NULL,
	[Activo] [bit] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[ModificadoEl] [datetime] NULL,
	[ModificadoPor] [int] NULL,
 CONSTRAINT [PK_doc_pedidos_configuracion] PRIMARY KEY CLUSTERED 
(
	[PedidoConfiguracionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



ALTER TABLE [dbo].[doc_pedidos_configuracion]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_configuracion_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_pedidos_configuracion] CHECK CONSTRAINT [FK_doc_pedidos_configuracion_cat_sucursales]


ALTER TABLE [dbo].[doc_pedidos_configuracion]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_configuracion_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_pedidos_configuracion] CHECK CONSTRAINT [FK_doc_pedidos_configuracion_cat_usuarios]


ALTER TABLE [dbo].[doc_pedidos_configuracion]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_configuracion_cat_usuarios1] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_pedidos_configuracion] CHECK CONSTRAINT [FK_doc_pedidos_configuracion_cat_usuarios1]



END
