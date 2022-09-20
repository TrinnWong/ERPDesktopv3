if not exists(
	select 1
	from sysobjects
	where name = 'cat_sitios_entrega_pedido'
)
begin
	CREATE TABLE [dbo].[cat_sitios_entrega_pedido](
		[SitioEntregaPedidoId] [smallint] NOT NULL,
		[Descripcion] [varchar](200) NOT NULL,
		[CiudadId] [int] NOT NULL,
		[CreadoEl] [datetime] NOT NULL,
	 CONSTRAINT [PK_cat_sitios_entrega_pedido] PRIMARY KEY CLUSTERED 
	(
		[SitioEntregaPedidoId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	ALTER TABLE [dbo].[cat_sitios_entrega_pedido]  WITH CHECK ADD  CONSTRAINT [FK_cat_sitios_entrega_pedido_cat_municipios] FOREIGN KEY([CiudadId])
	REFERENCES [dbo].[cat_municipios] ([MunicipioId])


	ALTER TABLE [dbo].[cat_sitios_entrega_pedido] CHECK CONSTRAINT [FK_cat_sitios_entrega_pedido_cat_municipios]

end





