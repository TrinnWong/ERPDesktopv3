IF NOT EXISTS (
	SELECT 1
	FROM sysobjects
	where name = 'doc_productos_max_min'
)
BEGIN

CREATE TABLE [dbo].[doc_productos_max_min](
	[SucursalId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Maximo] [decimal](14, 4) NOT NULL,
	[Minimo] [decimal](14, 4) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_productos_max_min] PRIMARY KEY CLUSTERED 
(
	[SucursalId] ASC,
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_productos_max_min]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_max_min_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_productos_max_min] CHECK CONSTRAINT [FK_doc_productos_max_min_cat_productos]


ALTER TABLE [dbo].[doc_productos_max_min]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_max_min_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_productos_max_min] CHECK CONSTRAINT [FK_doc_productos_max_min_cat_sucursales]


END


