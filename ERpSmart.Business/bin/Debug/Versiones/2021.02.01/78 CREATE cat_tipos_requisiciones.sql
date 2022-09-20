IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'cat_tipos_requisiciones'
)
BEGIN

CREATE TABLE [dbo].[cat_tipos_requisiciones](
	[TipoRequisicionId] [smallint] NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[CreadoEl] [datetime] NULL,
 CONSTRAINT [PK_cat_tipos_requisiciones] PRIMARY KEY CLUSTERED 
(
	[TipoRequisicionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END
GO


