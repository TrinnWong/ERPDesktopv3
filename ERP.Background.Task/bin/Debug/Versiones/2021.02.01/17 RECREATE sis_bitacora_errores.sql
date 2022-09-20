if not exists (
	select 1
	from sis_bitacora_errores
)
BEGIN

DROP TABLE sis_bitacora_errores

CREATE TABLE [dbo].[sis_bitacora_errores](
	[IdError] [int] IDENTITY(1,1) NOT NULL,
	[Sistema] [varchar](60) NOT NULL,
	[Clase] [varchar](250) NULL,
	[ExStackTrace] [varchar](2000) NULL,
	[ExInnerException] [varchar](2000) NULL,
	[ExMessage] [varchar](500)  NULL,
	[CreadoEl] [datetime] NULL,
	[CreadoPor] [int] NULL,
 CONSTRAINT [PK_sis_bitacora_errores] PRIMARY KEY CLUSTERED 
(
	[IdError] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[sis_bitacora_errores]  WITH CHECK ADD  CONSTRAINT [FK_sis_bitacora_errores_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[sis_bitacora_errores] CHECK CONSTRAINT [FK_sis_bitacora_errores_cat_usuarios]

END
GO

