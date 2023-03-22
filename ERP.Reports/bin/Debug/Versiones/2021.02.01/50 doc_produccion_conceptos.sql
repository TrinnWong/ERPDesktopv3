IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_produccion_conceptos'
)
BEGIN



CREATE TABLE [dbo].[doc_produccion_conceptos](
	[ProduccionConceptoId] [int] NOT NULL,
	[ProduccionId] [int] NOT NULL,
	[ConceptoId] [int] NOT NULL,
	[Inicio] [datetime] NULL,
	[Fin] [datetime] NULL,
	[Cantidad] [decimal](18, 4) NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[ModificadoEl] [datetime] NULL,
	[ModificadoPor] [int] NULL,
 CONSTRAINT [PK_doc_produccion_conceptos] PRIMARY KEY CLUSTERED 
(
	[ProduccionConceptoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_produccion_conceptos]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_conceptos_cat_conceptos] FOREIGN KEY([ConceptoId])
REFERENCES [dbo].[cat_conceptos] ([ConceptoId])


ALTER TABLE [dbo].[doc_produccion_conceptos] CHECK CONSTRAINT [FK_doc_produccion_conceptos_cat_conceptos]


ALTER TABLE [dbo].[doc_produccion_conceptos]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_conceptos_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_produccion_conceptos] CHECK CONSTRAINT [FK_doc_produccion_conceptos_cat_usuarios]


ALTER TABLE [dbo].[doc_produccion_conceptos]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_conceptos_cat_usuarios1] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_produccion_conceptos] CHECK CONSTRAINT [FK_doc_produccion_conceptos_cat_usuarios1]


ALTER TABLE [dbo].[doc_produccion_conceptos]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_conceptos_doc_produccion] FOREIGN KEY([ProduccionId])
REFERENCES [dbo].[doc_produccion] ([ProduccionId])


ALTER TABLE [dbo].[doc_produccion_conceptos] CHECK CONSTRAINT [FK_doc_produccion_conceptos_doc_produccion]



END