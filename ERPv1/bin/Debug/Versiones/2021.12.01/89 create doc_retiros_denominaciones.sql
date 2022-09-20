IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'doc_retiros_denominaciones'
)
BEGIN

CREATE TABLE [dbo].[doc_retiros_denominaciones](
	[RetiroId] [int] NOT NULL,
	[DenominacionId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[ValorDenominacion] [money] NOT NULL,
	[Total] [money] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_retiros_denominaciones] PRIMARY KEY CLUSTERED 
(
	[RetiroId] ASC,
	[DenominacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_retiros_denominaciones]  WITH CHECK ADD  CONSTRAINT [FK_doc_retiros_denominaciones_cat_denominaciones] FOREIGN KEY([DenominacionId])
REFERENCES [dbo].[cat_denominaciones] ([Clave])


ALTER TABLE [dbo].[doc_retiros_denominaciones] CHECK CONSTRAINT [FK_doc_retiros_denominaciones_cat_denominaciones]


ALTER TABLE [dbo].[doc_retiros_denominaciones]  WITH CHECK ADD  CONSTRAINT [FK_doc_retiros_denominaciones_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])



ALTER TABLE [dbo].[doc_retiros_denominaciones] CHECK CONSTRAINT [FK_doc_retiros_denominaciones_cat_usuarios]


ALTER TABLE [dbo].[doc_retiros_denominaciones]  WITH CHECK ADD  CONSTRAINT [FK_doc_retiros_denominaciones_doc_retiros] FOREIGN KEY([RetiroId])
REFERENCES [dbo].[doc_retiros] ([RetiroId])


ALTER TABLE [dbo].[doc_retiros_denominaciones] CHECK CONSTRAINT [FK_doc_retiros_denominaciones_doc_retiros]


END
