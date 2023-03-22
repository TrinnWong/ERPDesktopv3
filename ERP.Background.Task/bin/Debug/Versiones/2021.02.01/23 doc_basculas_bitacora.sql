IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS 
	WHERE name = 'doc_basculas_bitacora'
)
BEGIN
CREATE TABLE [dbo].[doc_basculas_bitacora](
	[Id] [int] NOT NULL,
	[BasculaId] [int] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[Cantidad] [decimal](10, 4) NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_basculas_bitacora] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_basculas_bitacora]  WITH CHECK ADD  CONSTRAINT [FK_doc_basculas_bitacora_cat_basculas] FOREIGN KEY([BasculaId])
REFERENCES [dbo].[cat_basculas] ([BasculaId])


ALTER TABLE [dbo].[doc_basculas_bitacora] CHECK CONSTRAINT [FK_doc_basculas_bitacora_cat_basculas]


ALTER TABLE [dbo].[doc_basculas_bitacora]  WITH CHECK ADD  CONSTRAINT [FK_doc_basculas_bitacora_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])

END

ALTER TABLE [dbo].[doc_basculas_bitacora] CHECK CONSTRAINT [FK_doc_basculas_bitacora_cat_sucursales]
GO


