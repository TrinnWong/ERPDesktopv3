IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_productos_sobrantes_config'
)BEGIN


CREATE TABLE [dbo].[doc_productos_sobrantes_config](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpresaId] [int] NOT NULL,
	[ProductoSobranteId] [int] NOT NULL,
	[ProductoConvertirId] [int] NOT NULL,
	[Convertir] [bit] NULL,
	[CreadoEl] [datetime] NULL,
	[CreadoPor] [int] NULL,
 CONSTRAINT [PK_doc_productos_sobrantes_config] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_productos_sobrantes_config]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_sobrantes_config_cat_productos] FOREIGN KEY([ProductoConvertirId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_productos_sobrantes_config] CHECK CONSTRAINT [FK_doc_productos_sobrantes_config_cat_productos]


ALTER TABLE [dbo].[doc_productos_sobrantes_config]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_sobrantes_config_cat_productos1] FOREIGN KEY([ProductoSobranteId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_productos_sobrantes_config] CHECK CONSTRAINT [FK_doc_productos_sobrantes_config_cat_productos1]


ALTER TABLE [dbo].[doc_productos_sobrantes_config]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_sobrantes_config_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_productos_sobrantes_config] CHECK CONSTRAINT [FK_doc_productos_sobrantes_config_cat_usuarios]





END


