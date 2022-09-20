if not exists(
	select 1
	from sysobjects
	where name = 'cat_web_configuracion'
)

BEGIN
CREATE TABLE [dbo].[cat_web_configuracion](
	[SucursalId] [int] NOT NULL,
	[Dominio] [varchar](100) NOT NULL,
	[ServidorFTP] [varchar](50) NOT NULL,
	[UsuarioFTP] [varchar](50) NOT NULL,
	[PasswordFTP] [varchar](20) NOT NULL,
	[FolderProductos] [varchar](150) NOT NULL,
 CONSTRAINT [PK_cat_web_configuracion] PRIMARY KEY CLUSTERED 
(
	[SucursalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_web_configuracion]  WITH CHECK ADD  CONSTRAINT [FK_cat_web_configuracion_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[cat_web_configuracion] CHECK CONSTRAINT [FK_cat_web_configuracion_cat_sucursales]

END
GO


