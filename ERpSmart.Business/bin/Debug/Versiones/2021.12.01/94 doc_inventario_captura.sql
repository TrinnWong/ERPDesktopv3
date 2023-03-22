IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'doc_inventario_captura'
)
BEGIN

CREATE TABLE [dbo].[doc_inventario_captura](
	[Id] [int] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [decimal](18, 5) NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[Cerrado] [bit] NOT NULL,
 CONSTRAINT [PK_doc_inventario_captura] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_inventario_captura]  WITH CHECK ADD  CONSTRAINT [FK_doc_inventario_captura_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])

ALTER TABLE [dbo].[doc_inventario_captura] CHECK CONSTRAINT [FK_doc_inventario_captura_cat_productos]


ALTER TABLE [dbo].[doc_inventario_captura]  WITH CHECK ADD  CONSTRAINT [FK_doc_inventario_captura_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_inventario_captura] CHECK CONSTRAINT [FK_doc_inventario_captura_cat_sucursales]


ALTER TABLE [dbo].[doc_inventario_captura]  WITH CHECK ADD  CONSTRAINT [FK_doc_inventario_captura_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_inventario_captura] CHECK CONSTRAINT [FK_doc_inventario_captura_cat_usuarios]






END
