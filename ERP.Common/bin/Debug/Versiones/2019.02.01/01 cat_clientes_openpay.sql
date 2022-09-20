if not exists (
	select 1
	from sysobjects
	where name = 'cat_clientes_openpay'
)
begin

	CREATE TABLE [dbo].[cat_clientes_openpay](
		[ClienteId] [int] NOT NULL,
		[OpenPayId] [varchar](35) NOT NULL,
		[CreadoEl] [datetime] NOT NULL,
	 CONSTRAINT [PK_cat_clientes_openpay_1] PRIMARY KEY CLUSTERED 
	(
		[ClienteId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]



	ALTER TABLE [dbo].[cat_clientes_openpay]  WITH CHECK ADD  CONSTRAINT [FK_cat_clientes_openpay_cat_clientes] FOREIGN KEY([ClienteId])
	REFERENCES [dbo].[cat_clientes] ([ClienteId])


	ALTER TABLE [dbo].[cat_clientes_openpay] CHECK CONSTRAINT [FK_cat_clientes_openpay_cat_clientes]


END


