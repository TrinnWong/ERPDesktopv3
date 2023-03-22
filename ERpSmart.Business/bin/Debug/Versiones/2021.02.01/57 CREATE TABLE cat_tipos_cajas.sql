IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'cat_tipos_cajas'
)
BEGIN
	CREATE TABLE [dbo].[cat_tipos_cajas](
		[TipoCajaId] [smallint] NOT NULL,
		[Nombre] [varchar](50) NOT NULL,
		[Activo] [bit] NOT NULL,
	 CONSTRAINT [PK_cat_tipos_cajas] PRIMARY KEY CLUSTERED 
	(
		[TipoCajaId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END
GO


