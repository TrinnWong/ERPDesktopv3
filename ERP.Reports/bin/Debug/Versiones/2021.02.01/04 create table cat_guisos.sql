
CREATE TABLE [dbo].[cat_guisos](
	[productoId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_productos_guisos] PRIMARY KEY CLUSTERED 
(
	[productoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[cat_guisos]  WITH CHECK ADD  CONSTRAINT [FK_cat_productos_guisos_cat_productos] FOREIGN KEY([productoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])
GO

ALTER TABLE [dbo].[cat_guisos] CHECK CONSTRAINT [FK_cat_productos_guisos_cat_productos]
GO


