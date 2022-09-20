if not exists (
	select 1
	from sysobjects
	where name = 'doc_corte_caja_egresos_previo'
)
begin

	CREATE TABLE [dbo].[doc_corte_caja_egresos_previo](
		[CorteCajaId] [int] NOT NULL,
		[Gastos] [money] NOT NULL,
	 CONSTRAINT [PK_doc_corte_caja_egresos_previo] PRIMARY KEY CLUSTERED 
	(
		[CorteCajaId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]


END
GO

