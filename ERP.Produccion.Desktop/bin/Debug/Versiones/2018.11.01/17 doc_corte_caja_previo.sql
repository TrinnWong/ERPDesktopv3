if not exists(
	select 1
	from sysobjects
	where name = 'doc_corte_caja_previo'
)
begin

CREATE TABLE [dbo].[doc_corte_caja_previo](
	[CorteCajaId] [int] NOT NULL,
	[CajaId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[VentaIniId] [bigint] NULL,
	[VentaFinId] [bigint] NULL,
	[FechaApertura] [datetime] NOT NULL,
	[FechaCorte] [datetime] NOT NULL,
	[TotalCorte] [money] NOT NULL,
	[TotalIngresos] [money] NOT NULL,
	[TotalEgresos] [money] NOT NULL,
 CONSTRAINT [PK_doc_corte_caja_previo] PRIMARY KEY CLUSTERED 
(
	[CorteCajaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END

go