if not exists (
	select 1
	from sysobjects 
	where name = 'doc_sucursales_productos_recepcion'
)
BEGIN

	CREATE TABLE [dbo].[doc_sucursales_productos_recepcion](
		[SucursalId] [int] NOT NULL,
		[ProductoId] [int] NOT NULL,
		[CreadoEl] [datetime] NOT NULL,
	 CONSTRAINT [PK_doc_sucursales_productos_recepcion] PRIMARY KEY CLUSTERED 
	(
		[SucursalId] ASC,
		[ProductoId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]


	ALTER TABLE [dbo].[doc_sucursales_productos_recepcion]  WITH CHECK ADD  CONSTRAINT [FK_doc_sucursales_productos_recepcion_cat_productos] FOREIGN KEY([ProductoId])
	REFERENCES [dbo].[cat_productos] ([ProductoId])


	ALTER TABLE [dbo].[doc_sucursales_productos_recepcion] CHECK CONSTRAINT [FK_doc_sucursales_productos_recepcion_cat_productos]


	ALTER TABLE [dbo].[doc_sucursales_productos_recepcion]  WITH CHECK ADD  CONSTRAINT [FK_doc_sucursales_productos_recepcion_cat_sucursales] FOREIGN KEY([SucursalId])
	REFERENCES [dbo].[cat_sucursales] ([Clave])


	ALTER TABLE [dbo].[doc_sucursales_productos_recepcion] CHECK CONSTRAINT [FK_doc_sucursales_productos_recepcion_cat_sucursales]

END
GO

