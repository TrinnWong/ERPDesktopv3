IF NOT EXISTS(
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_clientes_productos_precios'
)
BEGIN

CREATE TABLE [dbo].[doc_clientes_productos_precios](
	[ClienteProductoPrecioId] [int] NOT NULL,
	[ClienteId] [int] NULL,
	[ProductoId] [int] NULL,
	[Precio] [decimal](18, 2) NULL,
	[CreadoEl] [datetime] NULL,
 CONSTRAINT [PK_doc_clientes_productos_precios] PRIMARY KEY CLUSTERED 
(
	[ClienteProductoPrecioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_clientes_productos_precios]  WITH CHECK ADD  CONSTRAINT [FK_doc_clientes_productos_precios_cat_clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[cat_clientes] ([ClienteId])


ALTER TABLE [dbo].[doc_clientes_productos_precios] CHECK CONSTRAINT [FK_doc_clientes_productos_precios_cat_clientes]


ALTER TABLE [dbo].[doc_clientes_productos_precios]  WITH CHECK ADD  CONSTRAINT [FK_doc_clientes_productos_precios_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_clientes_productos_precios] CHECK CONSTRAINT [FK_doc_clientes_productos_precios_cat_productos]

END


