IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_cocimientos_grupos'

)
BEGIN

CREATE TABLE [dbo].[doc_cocimientos_grupos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SucursalId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_cocimientos_grupos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_cocimientos_grupos]  WITH CHECK ADD  CONSTRAINT [FK_doc_cocimientos_grupos_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_cocimientos_grupos] CHECK CONSTRAINT [FK_doc_cocimientos_grupos_cat_sucursales]


ALTER TABLE [dbo].[doc_cocimientos_grupos]  WITH CHECK ADD  CONSTRAINT [FK_doc_cocimientos_grupos_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_cocimientos_grupos] CHECK CONSTRAINT [FK_doc_cocimientos_grupos_cat_usuarios]

END

