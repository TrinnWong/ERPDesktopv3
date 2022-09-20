
IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'cat_productos_principales'
)
BEGIN

CREATE TABLE [dbo].[cat_productos_principales](
	[SucursalId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[CreadoEl] [datetime] NULL,
 CONSTRAINT [PK_cat_productos_principales] PRIMARY KEY CLUSTERED 
(
	[SucursalId] ASC,
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_productos_principales]  WITH CHECK ADD  CONSTRAINT [FK_cat_productos_principales_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[cat_productos_principales] CHECK CONSTRAINT [FK_cat_productos_principales_cat_productos]


ALTER TABLE [dbo].[cat_productos_principales]  WITH CHECK ADD  CONSTRAINT [FK_cat_productos_principales_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[cat_productos_principales] CHECK CONSTRAINT [FK_cat_productos_principales_cat_sucursales]

END
GO


