if not exists (
	select 1
	from sysobjects
	where name = 'doc_web_carrito'
)
begin

CREATE TABLE [dbo].[doc_web_carrito](
	[uUID] [varchar](50) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Total] [money] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[EnvioCalle] [varchar](250) NOT NULL,
	[EnvioColonia] [varchar](100) NOT NULL,
	[EnvioCiudad] [varchar](70) NOT NULL,
	[EnvioEstadoId] [int] NOT NULL,
	[EnvioCP] [varchar](5) NOT NULL,
	[EnvioPersonaRecibe] [varchar](250) NOT NULL,
	[EnvioTelefonoContacto] [varchar](20) NOT NULL,
 CONSTRAINT [PK_doc_web_carrito] PRIMARY KEY CLUSTERED 
(
	[uUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



SET ANSI_PADDING OFF


ALTER TABLE [dbo].[doc_web_carrito]  WITH CHECK ADD  CONSTRAINT [FK_doc_web_carrito_cat_estados] FOREIGN KEY([EnvioEstadoId])
REFERENCES [dbo].[cat_estados] ([EstadoId])


ALTER TABLE [dbo].[doc_web_carrito] CHECK CONSTRAINT [FK_doc_web_carrito_cat_estados]


end
go


