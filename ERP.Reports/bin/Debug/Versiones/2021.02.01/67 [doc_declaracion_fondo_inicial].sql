IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_declaracion_fondo_inicial'
)
BEGIN

CREATE TABLE [dbo].[doc_declaracion_fondo_inicial](
	[DeclaracionFondoId] [int] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[CajaId] [int] NULL,
	[CorteCajaId] [int] NULL,
	[Total] [money] NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_declaraciones_fondo] PRIMARY KEY CLUSTERED 
(
	[DeclaracionFondoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_declaracion_fondo_inicial]  WITH CHECK ADD  CONSTRAINT [FK_doc_declaracion_fondo_inicial_cat_cajas] FOREIGN KEY([CajaId])
REFERENCES [dbo].[cat_cajas] ([Clave])


ALTER TABLE [dbo].[doc_declaracion_fondo_inicial] CHECK CONSTRAINT [FK_doc_declaracion_fondo_inicial_cat_cajas]


ALTER TABLE [dbo].[doc_declaracion_fondo_inicial]  WITH CHECK ADD  CONSTRAINT [FK_doc_declaraciones_fondo_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_declaracion_fondo_inicial] CHECK CONSTRAINT [FK_doc_declaraciones_fondo_cat_sucursales]


ALTER TABLE [dbo].[doc_declaracion_fondo_inicial]  WITH CHECK ADD  CONSTRAINT [FK_doc_declaraciones_fondo_doc_corte_caja] FOREIGN KEY([CorteCajaId])
REFERENCES [dbo].[doc_corte_caja] ([CorteCajaId])


ALTER TABLE [dbo].[doc_declaracion_fondo_inicial] CHECK CONSTRAINT [FK_doc_declaraciones_fondo_doc_corte_caja]

END


