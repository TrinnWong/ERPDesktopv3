if not exists(
	select 1
	from sysobjects
	where name = 'cat_productos_agrupados'
)
begin
CREATE TABLE [dbo].[cat_productos_agrupados](
	[ProductoAgrupadoId] [int] NOT NULL,
	[Descripcion] [varchar](60) NOT NULL,
	[DescripcionCorta] [varchar](30) NULL,
	[CreadoEl] [datetime] NOT NULL,
	[Especificaciones] [varchar](500) NULL,
 CONSTRAINT [PK_cat_productos_agrupados] PRIMARY KEY CLUSTERED 
(
	[ProductoAgrupadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

