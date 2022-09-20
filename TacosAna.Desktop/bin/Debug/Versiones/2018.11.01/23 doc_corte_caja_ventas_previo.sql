if not exists (
	select 1
	from sysobjects
	where name = 'doc_corte_caja_ventas_previo'
)
begin

CREATE TABLE [dbo].[doc_corte_caja_ventas_previo](
	[CorteId] [int] NOT NULL,
	[VentaId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_corte_caja_ventas_previo] PRIMARY KEY CLUSTERED 
(
	[CorteId] ASC,
	[VentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END
GO


