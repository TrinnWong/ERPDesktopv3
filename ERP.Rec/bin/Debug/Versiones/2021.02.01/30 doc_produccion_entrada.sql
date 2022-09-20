

CREATE TABLE [dbo].[doc_produccion_entrada](
	[ProduccionId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [decimal](10, 4) NOT NULL,
	[UnidadId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_produccion_entrada] PRIMARY KEY CLUSTERED 
(
	[ProduccionId] ASC,
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[doc_produccion_entrada]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_entrada_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])
GO

ALTER TABLE [dbo].[doc_produccion_entrada] CHECK CONSTRAINT [FK_doc_produccion_entrada_cat_productos]
GO

ALTER TABLE [dbo].[doc_produccion_entrada]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_entrada_cat_unidadesmed] FOREIGN KEY([UnidadId])
REFERENCES [dbo].[cat_unidadesmed] ([Clave])
GO

ALTER TABLE [dbo].[doc_produccion_entrada] CHECK CONSTRAINT [FK_doc_produccion_entrada_cat_unidadesmed]
GO

ALTER TABLE [dbo].[doc_produccion_entrada]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_entrada_doc_produccion] FOREIGN KEY([ProduccionId])
REFERENCES [dbo].[doc_produccion] ([ProduccionId])
GO

ALTER TABLE [dbo].[doc_produccion_entrada] CHECK CONSTRAINT [FK_doc_produccion_entrada_doc_produccion]
GO


