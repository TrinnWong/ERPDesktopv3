IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'sis_preferencias_sucursales'
)
BEGIN

CREATE TABLE [dbo].[sis_preferencias_sucursales](
	[Id] [int] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[PreferenciaId] [int] NOT NULL,
	[Valor] [varchar](50) NULL,
	[CreadoEl] [datetime]  NULL,
 CONSTRAINT [PK_sis_preferencias_sucursales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[sis_preferencias_sucursales]  WITH CHECK ADD  CONSTRAINT [FK_sis_preferencias_sucursales_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[sis_preferencias_sucursales] CHECK CONSTRAINT [FK_sis_preferencias_sucursales_cat_sucursales]


ALTER TABLE [dbo].[sis_preferencias_sucursales]  WITH CHECK ADD  CONSTRAINT [FK_sis_preferencias_sucursales_sis_preferencias] FOREIGN KEY([PreferenciaId])
REFERENCES [dbo].[sis_preferencias] ([Id])


ALTER TABLE [dbo].[sis_preferencias_sucursales] CHECK CONSTRAINT [FK_sis_preferencias_sucursales_sis_preferencias]

END


