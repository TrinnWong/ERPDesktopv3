IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'sis_preferencias_empresa'
)
BEGIN


CREATE TABLE [dbo].[sis_preferencias_empresa](
	[Id] [int]IDENTITY(1,1) NOT NULL,
	[PreferenciaId] [int] NOT NULL,
	[EmpresaId] [int] NOT NULL,
	[Valor] [varchar](1000) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_sis_preferencias_empresa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[sis_preferencias_empresa]  WITH CHECK ADD  CONSTRAINT [FK_sis_preferencias_empresa_sis_preferencias] FOREIGN KEY([PreferenciaId])
REFERENCES [dbo].[sis_preferencias] ([Id])


ALTER TABLE [dbo].[sis_preferencias_empresa] CHECK CONSTRAINT [FK_sis_preferencias_empresa_sis_preferencias]

END

