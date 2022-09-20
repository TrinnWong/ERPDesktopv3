if not exists (
	select 1
	from sysobjects
	where name = 'cat_usuarios_sucursales'
)
begin
CREATE TABLE [dbo].[cat_usuarios_sucursales](
	[UsuarioId] [int] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_usuarios_sucursales] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC,
	[SucursalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_usuarios_sucursales]  WITH CHECK ADD  CONSTRAINT [FK_cat_usuarios_sucursales_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[cat_usuarios_sucursales] CHECK CONSTRAINT [FK_cat_usuarios_sucursales_cat_sucursales]


ALTER TABLE [dbo].[cat_usuarios_sucursales]  WITH CHECK ADD  CONSTRAINT [FK_cat_usuarios_sucursales_cat_usuarios] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[cat_usuarios_sucursales] CHECK CONSTRAINT [FK_cat_usuarios_sucursales_cat_usuarios]
END
GO


