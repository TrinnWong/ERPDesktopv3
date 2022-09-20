if not exists (
	select 1
	from sysobjects
	where name = 'doc_corte_caja_denominaciones_previo'
)
begin

CREATE TABLE [dbo].[doc_corte_caja_denominaciones_previo](
	[CorteCajaId] [int] NOT NULL,
	[DenominacionId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Valor] [money] NOT NULL,
	[Total] [money] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_corte_caja_denominaciones_previo] PRIMARY KEY CLUSTERED 
(
	[CorteCajaId] ASC,
	[DenominacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END

