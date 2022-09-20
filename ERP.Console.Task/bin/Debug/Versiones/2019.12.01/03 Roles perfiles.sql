if not exists (
	select 1
	from sysobjects
	where name = 'sis_roles_perfiles'

)
begin

CREATE TABLE [dbo].[sis_roles_perfiles](
	[RolId] [smallint] NOT NULL,
	[PerfilId] [smallint] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_sis_roles_perfiles] PRIMARY KEY CLUSTERED 
(
	[RolId] ASC,
	[PerfilId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[sis_roles_perfiles]  WITH CHECK ADD  CONSTRAINT [FK_sis_roles_perfiles_sis_perfiles] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[sis_perfiles] ([PerfilId])


ALTER TABLE [dbo].[sis_roles_perfiles] CHECK CONSTRAINT [FK_sis_roles_perfiles_sis_perfiles]


ALTER TABLE [dbo].[sis_roles_perfiles]  WITH CHECK ADD  CONSTRAINT [FK_sis_roles_perfiles_sis_roles] FOREIGN KEY([RolId])
REFERENCES [dbo].[sis_roles] ([RolId])


ALTER TABLE [dbo].[sis_roles_perfiles] CHECK CONSTRAINT [FK_sis_roles_perfiles_sis_roles]


END
GO
