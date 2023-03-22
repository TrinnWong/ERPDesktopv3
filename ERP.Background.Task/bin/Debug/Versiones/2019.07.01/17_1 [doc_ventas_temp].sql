if not exists (
	select 1
	from sysobjects
	where name = 'doc_ventas_temp'
)
begin

CREATE TABLE [dbo].[doc_ventas_temp](
	[VentaId] [int] NOT NULL,
	[VentaTempId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_ventas_temp] PRIMARY KEY CLUSTERED 
(
	[VentaId] ASC,
	[VentaTempId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

Go


