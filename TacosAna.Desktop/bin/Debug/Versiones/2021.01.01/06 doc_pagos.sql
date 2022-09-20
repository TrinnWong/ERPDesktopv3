if not exists (
	select 1
	from sysobjects
	where name = 'doc_pagos'
)
begin


		CREATE TABLE [dbo].[doc_pagos](
			[PagoId] [int] NOT NULL,
			[ClienteId] [int] NOT NULL,
			[CargoId] [int] NULL,
			[FechaPago] [datetime] NOT NULL,
			[FormaPagoId] [int] NOT NULL,
			[Monto] [money] NOT NULL,
			[CreadoEl] [datetime] NOT NULL,
			[CreadoPor] [int] NOT NULL,
			Activo bit			
		 CONSTRAINT [PK_doc_pagos] PRIMARY KEY CLUSTERED 
		(
			[PagoId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]


		ALTER TABLE [dbo].[doc_pagos]  WITH CHECK ADD  CONSTRAINT [FK_doc_pagos_cat_clientes] FOREIGN KEY([ClienteId])
		REFERENCES [dbo].[cat_clientes] ([ClienteId])


		ALTER TABLE [dbo].[doc_pagos] CHECK CONSTRAINT [FK_doc_pagos_cat_clientes]


		ALTER TABLE [dbo].[doc_pagos]  WITH CHECK ADD  CONSTRAINT [FK_doc_pagos_cat_formas_pago] FOREIGN KEY([FormaPagoId])
		REFERENCES [dbo].[cat_formas_pago] ([FormaPagoId])


		ALTER TABLE [dbo].[doc_pagos] CHECK CONSTRAINT [FK_doc_pagos_cat_formas_pago]


		ALTER TABLE [dbo].[doc_pagos]  WITH CHECK ADD  CONSTRAINT [FK_doc_pagos_cat_usuarios] FOREIGN KEY([CreadoPor])
		REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


		ALTER TABLE [dbo].[doc_pagos] CHECK CONSTRAINT [FK_doc_pagos_cat_usuarios]


		ALTER TABLE [dbo].[doc_pagos]  WITH CHECK ADD  CONSTRAINT [FK_doc_pagos_doc_cargos] FOREIGN KEY([CargoId])
		REFERENCES [dbo].[doc_cargos] ([CargoId])


		ALTER TABLE [dbo].[doc_pagos] CHECK CONSTRAINT [FK_doc_pagos_doc_cargos]	


END
