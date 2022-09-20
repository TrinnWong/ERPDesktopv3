
if not exists (
	select 1
	from sysobjects
	where name = 'doc_productos_minimo'
)
begin
CREATE TABLE [dbo].[doc_productos_minimo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SucursalId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Notificacion] [bit] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_productos_minimo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[doc_productos_minimo]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_minimo_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])

ALTER TABLE [dbo].[doc_productos_minimo] CHECK CONSTRAINT [FK_doc_productos_minimo_cat_productos]


ALTER TABLE [dbo].[doc_productos_minimo]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_minimo_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_productos_minimo] CHECK CONSTRAINT [FK_doc_productos_minimo_cat_sucursales]

END


