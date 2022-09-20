if not exists (
	select 1
	from sysobjects
	where name = 'doc_corte_caja_apartados_pagos_previo'
)
begin

CREATE TABLE [dbo].[doc_corte_caja_apartados_pagos_previo](
	[CorteCajaId] [int] NOT NULL,
	[ApartadoPagoId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_corte_caja_apartados_pagos_previo] PRIMARY KEY CLUSTERED 
(
	[CorteCajaId] ASC,
	[ApartadoPagoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

end
GO
