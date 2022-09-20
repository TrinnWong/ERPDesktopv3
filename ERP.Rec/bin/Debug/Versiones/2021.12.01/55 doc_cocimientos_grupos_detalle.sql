IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_cocimientos_grupos_detalle'

)
BEGIN

CREATE TABLE [dbo].[doc_cocimientos_grupos_detalle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CocimientoGrupoId] [int] NOT NULL,
	[CocimientoId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_cocimientos_grupos_detalle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_cocimientos_grupos_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_cocimientos_grupos_detalle_doc_cocimientos] FOREIGN KEY([CocimientoId])
REFERENCES [dbo].[doc_cocimientos] ([CocimientoId])


ALTER TABLE [dbo].[doc_cocimientos_grupos_detalle] CHECK CONSTRAINT [FK_doc_cocimientos_grupos_detalle_doc_cocimientos]


ALTER TABLE [dbo].[doc_cocimientos_grupos_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_cocimientos_grupos_detalle_doc_cocimientos_grupos] FOREIGN KEY([CocimientoGrupoId])
REFERENCES [dbo].[doc_cocimientos_grupos] ([Id])


ALTER TABLE [dbo].[doc_cocimientos_grupos_detalle] CHECK CONSTRAINT [FK_doc_cocimientos_grupos_detalle_doc_cocimientos_grupos]


end


