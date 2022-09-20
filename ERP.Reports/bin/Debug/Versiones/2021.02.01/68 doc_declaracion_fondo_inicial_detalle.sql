IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS 
	WHERE name = 'doc_declaracion_fondo_inicial_detalle'
)
BEGIN
CREATE TABLE [dbo].[doc_declaracion_fondo_inicial_detalle](
	[DeclaracionFondoDetalleId] [int] NOT NULL,
	[DeclaracionFondoId] [int] NOT NULL,
	[DenominacionId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Total] [money] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NULL,
 CONSTRAINT [PK_doc_declaracion_fondo_inicial_detalle] PRIMARY KEY CLUSTERED 
(
	[DeclaracionFondoDetalleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_declaracion_fondo_inicial_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_declaracion_fondo_inicial_detalle_cat_denominaciones] FOREIGN KEY([DenominacionId])
REFERENCES [dbo].[cat_denominaciones] ([Clave])


ALTER TABLE [dbo].[doc_declaracion_fondo_inicial_detalle] CHECK CONSTRAINT [FK_doc_declaracion_fondo_inicial_detalle_cat_denominaciones]


ALTER TABLE [dbo].[doc_declaracion_fondo_inicial_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_declaracion_fondo_inicial_detalle_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_declaracion_fondo_inicial_detalle] CHECK CONSTRAINT [FK_doc_declaracion_fondo_inicial_detalle_cat_usuarios]


ALTER TABLE [dbo].[doc_declaracion_fondo_inicial_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_declaracion_fondo_inicial_detalle_doc_declaracion_fondo_inicial] FOREIGN KEY([DeclaracionFondoId])
REFERENCES [dbo].[doc_declaracion_fondo_inicial] ([DeclaracionFondoId])


ALTER TABLE [dbo].[doc_declaracion_fondo_inicial_detalle] CHECK CONSTRAINT [FK_doc_declaracion_fondo_inicial_detalle_doc_declaracion_fondo_inicial]
END


