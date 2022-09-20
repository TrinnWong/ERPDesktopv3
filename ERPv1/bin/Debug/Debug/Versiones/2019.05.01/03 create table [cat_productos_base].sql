if not exists (
	select 1
	from sysobjects
	where name = 'cat_productos_base'
)
begin
CREATE TABLE [dbo].[cat_productos_base](
	[ProductoMateriaPrimaId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[ProductoBaseId] [int] NOT NULL,
	[Cantidad] [decimal](14, 2) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[ModificadoEl] [datetime] NULL,
 CONSTRAINT [PK_cat_productos_base] PRIMARY KEY CLUSTERED 
(
	[ProductoMateriaPrimaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_productos_base]  WITH CHECK ADD  CONSTRAINT [FK_cat_productos_base_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[cat_productos_base] CHECK CONSTRAINT [FK_cat_productos_base_cat_productos]


ALTER TABLE [dbo].[cat_productos_base]  WITH CHECK ADD  CONSTRAINT [FK_cat_productos_base_cat_productos1] FOREIGN KEY([ProductoBaseId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[cat_productos_base] CHECK CONSTRAINT [FK_cat_productos_base_cat_productos1]
END
GO


