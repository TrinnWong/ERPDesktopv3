if not exists (
	select 1
	from sysobjects
	where name = 'cat_productos_guisos'
)
BEGIN

CREATE TABLE [dbo].[cat_productos_guisos](
	[ProductoId] [int] NOT NULL,
	[ProductoGuisoId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_productos_guisos_1] PRIMARY KEY CLUSTERED 
(
	[ProductoId] ASC,
	[ProductoGuisoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_productos_guisos]  WITH CHECK ADD  CONSTRAINT [FK_cat_productos_guisos_cat_guisos] FOREIGN KEY([ProductoGuisoId])
REFERENCES [dbo].[cat_guisos] ([productoId])


ALTER TABLE [dbo].[cat_productos_guisos] CHECK CONSTRAINT [FK_cat_productos_guisos_cat_guisos]


ALTER TABLE [dbo].[cat_productos_guisos]  WITH CHECK ADD  CONSTRAINT [FK_cat_productos_guisos_cat_productos1] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[cat_productos_guisos] CHECK CONSTRAINT [FK_cat_productos_guisos_cat_productos1]


END


