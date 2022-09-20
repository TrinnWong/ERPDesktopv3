IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_cocimientos'
)
begin

	CREATE TABLE [dbo].[doc_cocimientos](
		[CocimientoId] [int] NOT NULL,
		[ProductoId] [int] NOT NULL,
		[ProduccionId] [int] NOT NULL,
		[FechaCocimiento] [datetime] NOT NULL,
		[FechaHabilitado] [datetime] NULL,
		[CreadoEl] [datetime] NOT NULL,
		[CreadoPor] [int] NOT NULL,
	 CONSTRAINT [PK_doc_cocimientos] PRIMARY KEY CLUSTERED 
	(
		[CocimientoId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]


	ALTER TABLE [dbo].[doc_cocimientos]  WITH CHECK ADD  CONSTRAINT [FK_doc_cocimientos_cat_productos] FOREIGN KEY([ProductoId])
	REFERENCES [dbo].[cat_productos] ([ProductoId])


	ALTER TABLE [dbo].[doc_cocimientos] CHECK CONSTRAINT [FK_doc_cocimientos_cat_productos]


	ALTER TABLE [dbo].[doc_cocimientos]  WITH CHECK ADD  CONSTRAINT [FK_doc_cocimientos_cat_usuarios] FOREIGN KEY([CreadoPor])
	REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


	ALTER TABLE [dbo].[doc_cocimientos] CHECK CONSTRAINT [FK_doc_cocimientos_cat_usuarios]


	ALTER TABLE [dbo].[doc_cocimientos]  WITH CHECK ADD  CONSTRAINT [FK_doc_cocimientos_doc_produccion] FOREIGN KEY([ProduccionId])
	REFERENCES [dbo].[doc_produccion] ([ProduccionId])


	ALTER TABLE [dbo].[doc_cocimientos] CHECK CONSTRAINT [FK_doc_cocimientos_doc_produccion]

END

