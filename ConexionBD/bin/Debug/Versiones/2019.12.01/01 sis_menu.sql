if not exists (
select 1
from sysobjects
where name = 'sis_menu'
)
begin

CREATE TABLE [dbo].[sis_menu](
	[MenuId] [smallint] NOT NULL,
	[Titulo] [varchar](50) NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
	[Tipo] [tinyint] NOT NULL,
	[MenuWinBarNameId] [varchar](100) NULL,
	[MenuPadreId] [smallint] NULL,
	[Activo] [nchar](10) NOT NULL,
 CONSTRAINT [PK_sis_menu] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[sis_menu]  WITH CHECK ADD  CONSTRAINT [FK_sis_menu_sis_menu] FOREIGN KEY([MenuPadreId])
REFERENCES [dbo].[sis_menu] ([MenuId])


ALTER TABLE [dbo].[sis_menu] CHECK CONSTRAINT [FK_sis_menu_sis_menu]



END
GO


