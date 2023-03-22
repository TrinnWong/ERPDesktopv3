IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_productos_sobrantes_regitro_inventario'
)
BEGIN


CREATE TABLE [dbo].[doc_productos_sobrantes_regitro_inventario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SobranteRegsitroId] [int] NULL,
	[MovimientoDetalleId] [int] NULL,
	[CreadoEl] [datetime] NULL,
 CONSTRAINT [PK_doc_productos_sobrantes_regitro_inventario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_productos_sobrantes_regitro_inventario]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_sobrantes_regitro_inventario_doc_inv_movimiento_detalle] FOREIGN KEY([MovimientoDetalleId])
REFERENCES [dbo].[doc_inv_movimiento_detalle] ([MovimientoDetalleId])


ALTER TABLE [dbo].[doc_productos_sobrantes_regitro_inventario] CHECK CONSTRAINT [FK_doc_productos_sobrantes_regitro_inventario_doc_inv_movimiento_detalle]


ALTER TABLE [dbo].[doc_productos_sobrantes_regitro_inventario]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_sobrantes_regitro_inventario_doc_productos_sobrantes_registro] FOREIGN KEY([SobranteRegsitroId])
REFERENCES [dbo].[doc_productos_sobrantes_registro] ([Id])


ALTER TABLE [dbo].[doc_productos_sobrantes_regitro_inventario] CHECK CONSTRAINT [FK_doc_productos_sobrantes_regitro_inventario_doc_productos_sobrantes_registro]

END
GO


