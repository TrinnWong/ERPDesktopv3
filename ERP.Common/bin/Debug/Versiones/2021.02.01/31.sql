IF NOT EXISTS (
	select 1
	from sysobjects
	where name = 'doc_produccion_salida'
)

begin
CREATE TABLE [dbo].[doc_produccion_salida](
	[ProduccionId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [decimal](10, 4) NULL,
	[UnidadId] [int] NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_produccion_salida] PRIMARY KEY CLUSTERED 
(
	[ProduccionId] ASC,
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_produccion_salida]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_salida_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_produccion_salida] CHECK CONSTRAINT [FK_doc_produccion_salida_cat_productos]


ALTER TABLE [dbo].[doc_produccion_salida]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_salida_cat_unidadesmed] FOREIGN KEY([UnidadId])
REFERENCES [dbo].[cat_unidadesmed] ([Clave])


ALTER TABLE [dbo].[doc_produccion_salida] CHECK CONSTRAINT [FK_doc_produccion_salida_cat_unidadesmed]


ALTER TABLE [dbo].[doc_produccion_salida]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_salida_doc_produccion] FOREIGN KEY([ProduccionId])
REFERENCES [dbo].[doc_produccion] ([ProduccionId])


ALTER TABLE [dbo].[doc_produccion_salida] CHECK CONSTRAINT [FK_doc_produccion_salida_doc_produccion]


end


