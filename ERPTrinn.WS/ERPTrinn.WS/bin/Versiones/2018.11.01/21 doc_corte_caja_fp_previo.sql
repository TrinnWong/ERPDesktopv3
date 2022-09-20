if not exists (
	select 1
	from sysobjects
	where name = 'doc_corte_caja_fp_previo'
)
begin

CREATE TABLE [dbo].[doc_corte_caja_fp_previo](
	[CorteCajaId] [int] NOT NULL,
	[FormaPagoId] [int] NOT NULL,
	[Total] [money] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_corte_caja_fp_previo] PRIMARY KEY CLUSTERED 
(
	[CorteCajaId] ASC,
	[FormaPagoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END