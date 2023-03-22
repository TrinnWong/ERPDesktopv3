if not exists (
	select 1
	from sysobjects
	where name = 'cat_politicas'
)
begin

CREATE TABLE [dbo].[cat_politicas](
	[PoliticaId] [int] NOT NULL,
	[Politica] [text] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_politicas] PRIMARY KEY CLUSTERED 
(
	[PoliticaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

end



