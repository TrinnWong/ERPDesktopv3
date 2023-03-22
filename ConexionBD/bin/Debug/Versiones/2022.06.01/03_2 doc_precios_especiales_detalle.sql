IF NOT EXISTS (
SELECT 1
FROM SYSOBJECTS
WHERE NAME = 'doc_precios_especiales_detalle'

)
BEGIN

CREATE TABLE [dbo].[doc_precios_especiales_detalle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrecioEspeciaId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[PrecioEspecial] [decimal](14, 2) NOT NULL,
	[MontoAdicional] [decimal](14, 2) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[ModificadoEl] [datetime] NULL,
	[ModificadoPor] [int] NULL,
 CONSTRAINT [PK_doc_precios_especiales_detalle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_precios_especiales_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_precios_especiales_detalle_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_precios_especiales_detalle] CHECK CONSTRAINT [FK_doc_precios_especiales_detalle_cat_productos]


ALTER TABLE [dbo].[doc_precios_especiales_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_precios_especiales_detalle_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_precios_especiales_detalle] CHECK CONSTRAINT [FK_doc_precios_especiales_detalle_cat_usuarios]


ALTER TABLE [dbo].[doc_precios_especiales_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_precios_especiales_detalle_cat_usuarios1] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_precios_especiales_detalle] CHECK CONSTRAINT [FK_doc_precios_especiales_detalle_cat_usuarios1]


ALTER TABLE [dbo].[doc_precios_especiales_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_precios_especiales_detalle_doc_precios_especiales] FOREIGN KEY([PrecioEspeciaId])
REFERENCES [dbo].[doc_precios_especiales] ([Id])


ALTER TABLE [dbo].[doc_precios_especiales_detalle] CHECK CONSTRAINT [FK_doc_precios_especiales_detalle_doc_precios_especiales]


END
