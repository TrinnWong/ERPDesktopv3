IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'doc_productos_existencias_diario'
)
BEGIN

CREATE TABLE [dbo].[doc_productos_existencias_diario](
	[Id] [int] IDENTITY(1,1)  ,
	[SucursalId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[FechaCorteExistencia] [datetime] NOT NULL,
	[Existencia] [float] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_productos_existencias_diario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_productos_existencias_diario]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_existencias_diario_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_productos_existencias_diario] CHECK CONSTRAINT [FK_doc_productos_existencias_diario_cat_productos]

ALTER TABLE [dbo].[doc_productos_existencias_diario]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_existencias_diario_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_productos_existencias_diario] CHECK CONSTRAINT [FK_doc_productos_existencias_diario_cat_sucursales]


ALTER TABLE [dbo].[doc_productos_existencias_diario]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_existencias_diario_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_productos_existencias_diario] CHECK CONSTRAINT [FK_doc_productos_existencias_diario_cat_usuarios]


END


