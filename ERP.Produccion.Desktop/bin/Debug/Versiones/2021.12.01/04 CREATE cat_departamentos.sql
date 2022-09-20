IF NOT EXISTS (
	SELECT 1
	FROM sysobjects
	WHERE name = 'cat_departamentos'

)
BEGIN




CREATE TABLE [dbo].[cat_departamentos](
	[DepartamentoId] [int] NOT NULL,
	[Nombre] [varchar](500) NOT NULL,
	[Activo] [bit] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_cat_departamentos] PRIMARY KEY CLUSTERED 
(
	[DepartamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_departamentos]  WITH CHECK ADD  CONSTRAINT [FK_cat_departamentos_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[cat_departamentos] CHECK CONSTRAINT [FK_cat_departamentos_cat_usuarios]

END


