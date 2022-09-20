if not exists (
	select 1
	from sysobjects
	where name = 'cat_cajas_impresora'
)
begin

CREATE TABLE [dbo].[cat_cajas_impresora](
	[CajaImpresoraId] [int] NOT NULL,
	[CajaId] [int] NOT NULL,
	[ImpresoraId] [smallint] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_cajas_impresora] PRIMARY KEY CLUSTERED 
(
	[CajaImpresoraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_cajas_impresora]  WITH CHECK ADD  CONSTRAINT [FK_cat_cajas_impresora_cat_cajas] FOREIGN KEY([CajaId])
REFERENCES [dbo].[cat_cajas] ([Clave])


ALTER TABLE [dbo].[cat_cajas_impresora] CHECK CONSTRAINT [FK_cat_cajas_impresora_cat_cajas]


ALTER TABLE [dbo].[cat_cajas_impresora]  WITH CHECK ADD  CONSTRAINT [FK_cat_cajas_impresora_cat_impresoras] FOREIGN KEY([ImpresoraId])
REFERENCES [dbo].[cat_impresoras] ([ImpresoraId])


ALTER TABLE [dbo].[cat_cajas_impresora] CHECK CONSTRAINT [FK_cat_cajas_impresora_cat_impresoras]


END


