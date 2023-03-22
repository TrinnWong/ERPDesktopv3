IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'doc_maiz_maseca_rendimiento'
)
BEGIN

CREATE TABLE [dbo].[doc_maiz_maseca_rendimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SucursalId] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[MaizSacos] [float] NOT NULL,
	[MasecaSacos] [float] NOT NULL,
	[TortillaMaizRendimiento] [float] NOT NULL,
	[TortillaMasecaRendimiento] [float] NOT NULL,
	[TortillaTotalRendimiento] [float] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[ModificadoEl] [datetime] NULL,
	[ModificadoPor] [int] NULL,
 CONSTRAINT [PK_doc_maiz_maseca_rendimiento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_maiz_maseca_rendimiento]  WITH CHECK ADD  CONSTRAINT [FK_doc_maiz_maseca_rendimiento_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_maiz_maseca_rendimiento] CHECK CONSTRAINT [FK_doc_maiz_maseca_rendimiento_cat_sucursales]


ALTER TABLE [dbo].[doc_maiz_maseca_rendimiento]  WITH CHECK ADD  CONSTRAINT [FK_doc_maiz_maseca_rendimiento_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_maiz_maseca_rendimiento] CHECK CONSTRAINT [FK_doc_maiz_maseca_rendimiento_cat_usuarios]


ALTER TABLE [dbo].[doc_maiz_maseca_rendimiento]  WITH CHECK ADD  CONSTRAINT [FK_doc_maiz_maseca_rendimiento_cat_usuarios1] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_maiz_maseca_rendimiento] CHECK CONSTRAINT [FK_doc_maiz_maseca_rendimiento_cat_usuarios1]


END


