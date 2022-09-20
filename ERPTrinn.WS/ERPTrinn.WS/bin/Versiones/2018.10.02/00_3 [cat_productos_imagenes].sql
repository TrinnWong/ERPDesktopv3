if not exists (
	select 1
	from sysobjects
	where name = 'cat_productos_imagenes'
)
begin
	CREATE TABLE [dbo].[cat_productos_imagenes](
		[ProductoImageId] [int] NOT NULL,
		[ProductoId] [int] NOT NULL,
		[FileName] [varchar](250) NOT NULL,
		[CreadoEl] [datetime] NOT NULL,
	 CONSTRAINT [PK_cat_productos_imagenes] PRIMARY KEY CLUSTERED 
	(
		[ProductoImageId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]



	ALTER TABLE [dbo].[cat_productos_imagenes]  WITH CHECK ADD  CONSTRAINT [FK_cat_productos_imagenes_cat_productos] FOREIGN KEY([ProductoId])
	REFERENCES [dbo].[cat_productos] ([ProductoId])


	ALTER TABLE [dbo].[cat_productos_imagenes] CHECK CONSTRAINT [FK_cat_productos_imagenes_cat_productos]
END
GO


