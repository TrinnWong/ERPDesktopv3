IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'doc_corte_caja_datos_entrada'
)
BEGIN

CREATE TABLE [dbo].[doc_corte_caja_datos_entrada](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SucursalId] [int] NOT NULL,
	[TiradaTortilla] [decimal](14, 3) NOT NULL,
	[MasaKg] [decimal](14, 3) NOT NULL,
	[TiradaTortillaKg] [decimal](14, 3) NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_corte_caja_datos_entrada] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_corte_caja_datos_entrada]  WITH CHECK ADD  CONSTRAINT [FK_doc_corte_caja_datos_entrada_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_corte_caja_datos_entrada] CHECK CONSTRAINT [FK_doc_corte_caja_datos_entrada_cat_sucursales]


ALTER TABLE [dbo].[doc_corte_caja_datos_entrada]  WITH CHECK ADD  CONSTRAINT [FK_doc_corte_caja_datos_entrada_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_corte_caja_datos_entrada] CHECK CONSTRAINT [FK_doc_corte_caja_datos_entrada_cat_usuarios]

END


