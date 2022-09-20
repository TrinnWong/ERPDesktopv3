if not exists (
	select 1
	from sysobjects
	where name = 'cat_clientes_automovil'
)
begin
CREATE TABLE [dbo].[cat_clientes_automovil](
	[ClienteAutoId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Modelo] [varchar](150) NOT NULL,
	[Color] [varchar](50) NOT NULL,
	[Placas] [varchar](20) NULL,
	[Observaciones] [varchar](300) NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_clientes_automovil] PRIMARY KEY CLUSTERED 
(
	[ClienteAutoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_clientes_automovil]  WITH CHECK ADD  CONSTRAINT [FK_cat_clientes_automovil_cat_clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[cat_clientes] ([ClienteId])


ALTER TABLE [dbo].[cat_clientes_automovil] CHECK CONSTRAINT [FK_cat_clientes_automovil_cat_clientes]

END
GO


