IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS 
	WHERE NAME = 'doc_aceptaciones_sucursal'
)
BEGIN

CREATE TABLE [dbo].[doc_aceptaciones_sucursal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SucursalId] [int] NOT NULL,
	[MovimientoId] [int] NULL,
	[Fecha] [datetime] NOT NULL,
	[AceptadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_aceptaciones_sucursal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_aceptaciones_sucursal]  WITH CHECK ADD  CONSTRAINT [FK_doc_aceptaciones_sucursal_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_aceptaciones_sucursal] CHECK CONSTRAINT [FK_doc_aceptaciones_sucursal_cat_sucursales]


ALTER TABLE [dbo].[doc_aceptaciones_sucursal]  WITH CHECK ADD  CONSTRAINT [FK_doc_aceptaciones_sucursal_cat_usuarios] FOREIGN KEY([AceptadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_aceptaciones_sucursal] CHECK CONSTRAINT [FK_doc_aceptaciones_sucursal_cat_usuarios]


ALTER TABLE [dbo].[doc_aceptaciones_sucursal]  WITH CHECK ADD  CONSTRAINT [FK_doc_aceptaciones_sucursal_doc_inv_movimiento] FOREIGN KEY([MovimientoId])
REFERENCES [dbo].[doc_inv_movimiento] ([MovimientoId])


ALTER TABLE [dbo].[doc_aceptaciones_sucursal] CHECK CONSTRAINT [FK_doc_aceptaciones_sucursal_doc_inv_movimiento]

END


