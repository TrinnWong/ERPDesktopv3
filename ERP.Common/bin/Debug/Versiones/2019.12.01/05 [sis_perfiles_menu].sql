if not exists (
	select 1
	from sysobjects
	where name = 'sis_perfiles_menu'

)
begin
CREATE TABLE [dbo].[sis_perfiles_menu](
	[PerfilId] [smallint] NOT NULL,
	[MenuId] [smallint] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_sis_perfiles_menu] PRIMARY KEY CLUSTERED 
(
	[PerfilId] ASC,
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[sis_perfiles_menu]  WITH CHECK ADD  CONSTRAINT [FK_sis_perfiles_menu_sis_menu] FOREIGN KEY([MenuId])
REFERENCES [dbo].[sis_menu] ([MenuId])


ALTER TABLE [dbo].[sis_perfiles_menu] CHECK CONSTRAINT [FK_sis_perfiles_menu_sis_menu]


ALTER TABLE [dbo].[sis_perfiles_menu]  WITH CHECK ADD  CONSTRAINT [FK_sis_perfiles_menu_sis_perfiles] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[sis_perfiles] ([PerfilId])


ALTER TABLE [dbo].[sis_perfiles_menu] CHECK CONSTRAINT [FK_sis_perfiles_menu_sis_perfiles]
end
GO


