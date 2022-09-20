IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_produccion_solicitud_detalle'
)
BEGIN

CREATE TABLE [dbo].[doc_produccion_solicitud_detalle](
	[Id] [int] NOT NULL,
	[ProduccionSolicitudId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[UnidadId] [int] NOT NULL,
	[Cantidad] [float] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_produccion_solicitud_detalle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_produccion_solicitud_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_solicitud_detalle_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_produccion_solicitud_detalle] CHECK CONSTRAINT [FK_doc_produccion_solicitud_detalle_cat_productos]


ALTER TABLE [dbo].[doc_produccion_solicitud_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_solicitud_detalle_cat_unidadesmed] FOREIGN KEY([UnidadId])
REFERENCES [dbo].[cat_unidadesmed] ([Clave])


ALTER TABLE [dbo].[doc_produccion_solicitud_detalle] CHECK CONSTRAINT [FK_doc_produccion_solicitud_detalle_cat_unidadesmed]


ALTER TABLE [dbo].[doc_produccion_solicitud_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_solicitud_detalle_doc_produccion_solicitud] FOREIGN KEY([ProduccionSolicitudId])
REFERENCES [dbo].[doc_produccion_solicitud] ([ProduccionSolicitudId])


ALTER TABLE [dbo].[doc_produccion_solicitud_detalle] CHECK CONSTRAINT [FK_doc_produccion_solicitud_detalle_doc_produccion_solicitud]

END


