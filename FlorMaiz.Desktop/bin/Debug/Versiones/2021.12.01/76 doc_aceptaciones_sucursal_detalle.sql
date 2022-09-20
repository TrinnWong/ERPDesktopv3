IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS 
	WHERE NAME = 'doc_aceptaciones_sucursal_detalle'
)
BEGIN

CREATE TABLE [dbo].[doc_aceptaciones_sucursal_detalle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AceptacionSucursalId] [int] NOT NULL,
	[MovimientoDetalleId] [int] NULL,
	[CantidadReal] [decimal](14, 4) NULL,
	[MovimientoDetalleAjusteId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_aceptaciones_sucursal_detalle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_aceptaciones_sucursal_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_aceptaciones_sucursal_detalle_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_aceptaciones_sucursal_detalle] CHECK CONSTRAINT [FK_doc_aceptaciones_sucursal_detalle_cat_usuarios]


ALTER TABLE [dbo].[doc_aceptaciones_sucursal_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_aceptaciones_sucursal_detalle_doc_aceptaciones_sucursal] FOREIGN KEY([AceptacionSucursalId])
REFERENCES [dbo].[doc_aceptaciones_sucursal] ([Id])


ALTER TABLE [dbo].[doc_aceptaciones_sucursal_detalle] CHECK CONSTRAINT [FK_doc_aceptaciones_sucursal_detalle_doc_aceptaciones_sucursal]


ALTER TABLE [dbo].[doc_aceptaciones_sucursal_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_aceptaciones_sucursal_detalle_doc_inv_movimiento_detalle] FOREIGN KEY([MovimientoDetalleId])
REFERENCES [dbo].[doc_inv_movimiento_detalle] ([MovimientoDetalleId])


ALTER TABLE [dbo].[doc_aceptaciones_sucursal_detalle] CHECK CONSTRAINT [FK_doc_aceptaciones_sucursal_detalle_doc_inv_movimiento_detalle]


ALTER TABLE [dbo].[doc_aceptaciones_sucursal_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_aceptaciones_sucursal_detalle_doc_inv_movimiento_detalle1] FOREIGN KEY([MovimientoDetalleAjusteId])
REFERENCES [dbo].[doc_inv_movimiento_detalle] ([MovimientoDetalleId])


ALTER TABLE [dbo].[doc_aceptaciones_sucursal_detalle] CHECK CONSTRAINT [FK_doc_aceptaciones_sucursal_detalle_doc_inv_movimiento_detalle1]



END