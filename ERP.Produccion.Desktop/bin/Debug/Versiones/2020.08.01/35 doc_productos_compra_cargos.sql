if not exists (
	select 1
	from sysobjects 
	where name = 'doc_productos_compra_cargos'
)
begin

CREATE TABLE [dbo].[doc_productos_compra_cargos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductoCompraId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Remision] [varchar](20) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[ProveedorId] [int] NOT NULL,
	[Total] [money] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_productos_compra_cargos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[doc_productos_compra_cargos]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_compra_cargos_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_productos_compra_cargos] CHECK CONSTRAINT [FK_doc_productos_compra_cargos_cat_productos]


ALTER TABLE [dbo].[doc_productos_compra_cargos]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_compra_cargos_doc_productos_compra] FOREIGN KEY([ProductoCompraId])
REFERENCES [dbo].[doc_productos_compra] ([ProductoCompraId])


ALTER TABLE [dbo].[doc_productos_compra_cargos] CHECK CONSTRAINT [FK_doc_productos_compra_cargos_doc_productos_compra]



/****** Object:  Index [IX_doc_productos_compra_cargos]    Script Date: 10/7/2020 1:21:51 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_doc_productos_compra_cargos] ON [dbo].[doc_productos_compra_cargos]
(
	[ProductoId] ASC,
	[ProductoCompraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

END