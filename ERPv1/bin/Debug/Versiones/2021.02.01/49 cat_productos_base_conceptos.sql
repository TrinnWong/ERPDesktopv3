IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'cat_productos_base_conceptos'
)
BEGIN

CREATE TABLE [dbo].[cat_productos_base_conceptos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductoId] [int] NOT NULL,
	[ConceptoId] [int] NOT NULL,
	[RegistrarTiempo] [bit] NULL,
	[RegistrarVolumen] [bit] NULL,
	[CreadoEl] [nchar](10) NULL,
 CONSTRAINT [PK_cat_productos_base_conceptos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_productos_base_conceptos]  WITH CHECK ADD  CONSTRAINT [FK_cat_productos_base_conceptos_cat_conceptos] FOREIGN KEY([ConceptoId])
REFERENCES [dbo].[cat_conceptos] ([ConceptoId])


ALTER TABLE [dbo].[cat_productos_base_conceptos] CHECK CONSTRAINT [FK_cat_productos_base_conceptos_cat_conceptos]


ALTER TABLE [dbo].[cat_productos_base_conceptos]  WITH CHECK ADD  CONSTRAINT [FK_cat_productos_base_conceptos_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[cat_productos_base_conceptos] CHECK CONSTRAINT [FK_cat_productos_base_conceptos_cat_productos]


END
