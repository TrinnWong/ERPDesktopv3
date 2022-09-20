if not exists (
	select 1
	from sysobjects
	where name = 'doc_pedidos_configuracion_det'
)
begin


	CREATE TABLE [dbo].[doc_pedidos_configuracion_det](
		[PedidoConfiguracionDetId] [int] NOT NULL,
		[PedidoConfiguracionId] [int] NOT NULL,
		[ProductoId] [int] NOT NULL,
		[CreadoEl] [datetime] NOT NULL,
		[CreadoPor] [int] NOT NULL,
	 CONSTRAINT [PK_doc_pedidos_configuracion_det_1] PRIMARY KEY CLUSTERED 
	(
		[PedidoConfiguracionDetId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]



	ALTER TABLE [dbo].[doc_pedidos_configuracion_det]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_configuracion_det_cat_productos] FOREIGN KEY([ProductoId])
	REFERENCES [dbo].[cat_productos] ([ProductoId])


	ALTER TABLE [dbo].[doc_pedidos_configuracion_det] CHECK CONSTRAINT [FK_doc_pedidos_configuracion_det_cat_productos]


	ALTER TABLE [dbo].[doc_pedidos_configuracion_det]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_configuracion_det_cat_usuarios] FOREIGN KEY([CreadoPor])
	REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


	ALTER TABLE [dbo].[doc_pedidos_configuracion_det] CHECK CONSTRAINT [FK_doc_pedidos_configuracion_det_cat_usuarios]


	ALTER TABLE [dbo].[doc_pedidos_configuracion_det]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_configuracion_det_doc_pedidos_configuracion] FOREIGN KEY([PedidoConfiguracionId])
	REFERENCES [dbo].[doc_pedidos_configuracion] ([PedidoConfiguracionId])


	ALTER TABLE [dbo].[doc_pedidos_configuracion_det] CHECK CONSTRAINT [FK_doc_pedidos_configuracion_det_doc_pedidos_configuracion]

END

