IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'cat_produccion_productos_sucursal'
)
BEGIN

CREATE TABLE [dbo].[cat_produccion_productos_sucursal](
	[Id] [int] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_produccion_productos_sucursal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_produccion_productos_sucursal]  WITH CHECK ADD  CONSTRAINT [FK_cat_produccion_productos_sucursal_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[cat_produccion_productos_sucursal] CHECK CONSTRAINT [FK_cat_produccion_productos_sucursal_cat_productos]


ALTER TABLE [dbo].[cat_produccion_productos_sucursal]  WITH CHECK ADD  CONSTRAINT [FK_cat_produccion_productos_sucursal_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[cat_produccion_productos_sucursal] CHECK CONSTRAINT [FK_cat_produccion_productos_sucursal_cat_sucursales]


END
