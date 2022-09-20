
if not exists (
	select 1
	from sysobjects
	where name = 'cat_rest_platillo_adicionales'
)
begin
CREATE TABLE [dbo].[cat_rest_platillo_adicionales](
	[Id] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[MostrarSiempre] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_cat_rest_platillo_adicionales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_rest_platillo_adicionales]  WITH CHECK ADD  CONSTRAINT [FK_cat_rest_platillo_adicionales_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[cat_rest_platillo_adicionales] CHECK CONSTRAINT [FK_cat_rest_platillo_adicionales_cat_usuarios]
END

GO


