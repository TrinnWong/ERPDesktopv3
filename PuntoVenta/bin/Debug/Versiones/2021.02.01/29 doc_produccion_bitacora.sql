
IF NOT EXISTS (
	select 1
	from sysobjects
	where name = 'doc_produccion_bitacora'
)
BEGIN

CREATE TABLE [dbo].[doc_produccion_bitacora](
	[ProduccionId] [int] NOT NULL,
	[BitacoraId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_produccion_bitacora] PRIMARY KEY CLUSTERED 
(
	[ProduccionId] ASC,
	[BitacoraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END


