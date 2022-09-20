IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_ventas_pagos'
)
BEGIN

CREATE TABLE [dbo].[doc_ventas_pagos](
	[VentaId] [bigint] NOT NULL,
	[PagoId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_ventas_pagos] PRIMARY KEY CLUSTERED 
(
	[VentaId] ASC,
	[PagoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_ventas_pagos]  WITH CHECK ADD  CONSTRAINT [FK_doc_ventas_pagos_doc_pagos] FOREIGN KEY([PagoId])
REFERENCES [dbo].[doc_pagos] ([PagoId])


ALTER TABLE [dbo].[doc_ventas_pagos] CHECK CONSTRAINT [FK_doc_ventas_pagos_doc_pagos]


ALTER TABLE [dbo].[doc_ventas_pagos]  WITH CHECK ADD  CONSTRAINT [FK_doc_ventas_pagos_doc_ventas] FOREIGN KEY([VentaId])
REFERENCES [dbo].[doc_ventas] ([VentaId])


ALTER TABLE [dbo].[doc_ventas_pagos] CHECK CONSTRAINT [FK_doc_ventas_pagos_doc_ventas]

END
GO


