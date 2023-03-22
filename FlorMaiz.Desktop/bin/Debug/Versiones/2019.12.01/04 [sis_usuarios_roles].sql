if not exists (
	select 1
	from sysobjects
	where name = 'sis_usuarios_roles'

)
begin

CREATE TABLE [dbo].[sis_usuarios_roles](
	[UsuarioId] [int] NOT NULL,
	[RolId] [smallint] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_sis_usuarios_roles] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC,
	[RolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[sis_usuarios_roles]  WITH CHECK ADD  CONSTRAINT [FK_sis_usuarios_roles_cat_usuarios] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[sis_usuarios_roles] CHECK CONSTRAINT [FK_sis_usuarios_roles_cat_usuarios]


ALTER TABLE [dbo].[sis_usuarios_roles]  WITH CHECK ADD  CONSTRAINT [FK_sis_usuarios_roles_sis_roles] FOREIGN KEY([RolId])
REFERENCES [dbo].[sis_roles] ([RolId])


ALTER TABLE [dbo].[sis_usuarios_roles] CHECK CONSTRAINT [FK_sis_usuarios_roles_sis_roles]
END
GO


