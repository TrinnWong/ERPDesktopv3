if not exists (
	select 1
	from sysobjects
	where name = 'doc_pagos_cancelaciones'
)
begin

CREATE TABLE [dbo].[doc_pagos_cancelaciones](
	[PagoId] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[CanceladoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_pagos_cancelaciones] PRIMARY KEY CLUSTERED 
(
	[PagoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_pagos_cancelaciones]  WITH CHECK ADD  CONSTRAINT [FK_doc_pagos_cancelaciones_cat_usuarios] FOREIGN KEY([CanceladoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_pagos_cancelaciones] CHECK CONSTRAINT [FK_doc_pagos_cancelaciones_cat_usuarios]

END


