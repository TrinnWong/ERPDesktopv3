IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_cocimientos_grupos_movs_inventario'
)
BEGIN

CREATE TABLE [dbo].[doc_cocimientos_grupos_movs_inventario](
	[CocimientoGrupoId] [int] NOT NULL,
	[MovimientoInventarioId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_cocimientos_grupos_movs_inventario] PRIMARY KEY CLUSTERED 
(
	[CocimientoGrupoId] ASC,
	[MovimientoInventarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_cocimientos_grupos_movs_inventario]  WITH CHECK ADD  CONSTRAINT [FK_doc_cocimientos_grupos_movs_inventario_doc_cocimientos_grupos] FOREIGN KEY([CocimientoGrupoId])
REFERENCES [dbo].[doc_cocimientos_grupos] ([Id])


ALTER TABLE [dbo].[doc_cocimientos_grupos_movs_inventario] CHECK CONSTRAINT [FK_doc_cocimientos_grupos_movs_inventario_doc_cocimientos_grupos]


ALTER TABLE [dbo].[doc_cocimientos_grupos_movs_inventario]  WITH CHECK ADD  CONSTRAINT [FK_doc_cocimientos_grupos_movs_inventario_doc_inv_movimiento] FOREIGN KEY([MovimientoInventarioId])
REFERENCES [dbo].[doc_inv_movimiento] ([MovimientoId])


ALTER TABLE [dbo].[doc_cocimientos_grupos_movs_inventario] CHECK CONSTRAINT [FK_doc_cocimientos_grupos_movs_inventario_doc_inv_movimiento]


END


