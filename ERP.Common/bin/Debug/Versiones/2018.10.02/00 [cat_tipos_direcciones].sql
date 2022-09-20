if not exists (
	select 1
	from sysobjects
	where name = 'cat_tipos_direcciones'
)
begin
	CREATE TABLE [dbo].[cat_tipos_direcciones](
		[TipoDireccionId] tinyint NOT NULL,
		[Nombre] [varchar](50) NOT NULL,
		[CreadoEl] [datetime] NOT NULL,
	 CONSTRAINT [PK_cat_tipos_direcciones] PRIMARY KEY CLUSTERED 
	(
		[TipoDireccionId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END




