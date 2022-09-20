IF NOT EXISTS(
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'doc_empleados_productos_descuentos'
)
BEGIN

CREATE TABLE [dbo].[doc_empleados_productos_descuentos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpleadoId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[MontoDescuento] [decimal](14, 2) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[ModificadoPor] [int] NOT NULL,
	[ModificadoEl] [datetime] NULL,
 CONSTRAINT [PK_doc_empleados_productos_descuentos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[doc_empleados_productos_descuentos]  WITH CHECK ADD  CONSTRAINT [FK_doc_empleados_productos_descuentos_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_empleados_productos_descuentos] CHECK CONSTRAINT [FK_doc_empleados_productos_descuentos_cat_productos]


ALTER TABLE [dbo].[doc_empleados_productos_descuentos]  WITH CHECK ADD  CONSTRAINT [FK_doc_empleados_productos_descuentos_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_empleados_productos_descuentos] CHECK CONSTRAINT [FK_doc_empleados_productos_descuentos_cat_usuarios]


ALTER TABLE [dbo].[doc_empleados_productos_descuentos]  WITH CHECK ADD  CONSTRAINT [FK_doc_empleados_productos_descuentos_cat_usuarios1] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_empleados_productos_descuentos] CHECK CONSTRAINT [FK_doc_empleados_productos_descuentos_cat_usuarios1]


ALTER TABLE [dbo].[doc_empleados_productos_descuentos]  WITH CHECK ADD  CONSTRAINT [FK_doc_empleados_productos_descuentos_rh_empleados] FOREIGN KEY([EmpleadoId])
REFERENCES [dbo].[rh_empleados] ([NumEmpleado])


ALTER TABLE [dbo].[doc_empleados_productos_descuentos] CHECK CONSTRAINT [FK_doc_empleados_productos_descuentos_rh_empleados]



END