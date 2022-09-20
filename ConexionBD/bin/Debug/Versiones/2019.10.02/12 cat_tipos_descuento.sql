if not exists (
	select 1
	from sysobjects
	where name = 'cat_tipos_descuento'
)
begin
	CREATE TABLE [dbo].[cat_tipos_descuento](
		[TipoDescuentoId] [tinyint] NOT NULL,
		[Descripcion] [varchar](50) NOT NULL,
	 CONSTRAINT [PK_cat_tipos_cortesia] PRIMARY KEY CLUSTERED 
	(
		[TipoDescuentoId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
end
GO


