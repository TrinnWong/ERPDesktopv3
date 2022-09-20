IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'cat_tipos_mermas'
)
BEGIN

CREATE TABLE [dbo].[cat_tipos_mermas](
	[TipoMermaId] [smallint] NOT NULL,
	[Tipo] [varchar](500) NOT NULL,
	[CreadoEl] [datetime] NULL,
 CONSTRAINT [PK_cat_tipos_mermas] PRIMARY KEY CLUSTERED 
(
	[TipoMermaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END
GO


