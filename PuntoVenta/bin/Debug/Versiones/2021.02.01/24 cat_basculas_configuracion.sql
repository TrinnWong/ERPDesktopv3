if not exists (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'cat_basculas_configuracion'
)
BEGIN

CREATE TABLE [dbo].[cat_basculas_configuracion](
	[EquipoComputoId] [int] NOT NULL,
	[BasculaId] [int] NOT NULL,
	[PortName] [varchar](100) NOT NULL,
	[BaudRate] [int] NOT NULL,
	[ReadBufferSize] [int] NOT NULL,
	[WriteBufferSize] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_cat_basculas_configuracion] PRIMARY KEY CLUSTERED 
(
	[EquipoComputoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_basculas_configuracion]  WITH CHECK ADD  CONSTRAINT [FK_cat_basculas_configuracion_cat_equipos_computo] FOREIGN KEY([EquipoComputoId])
REFERENCES [dbo].[cat_equipos_computo] ([EquipoComputoId])


ALTER TABLE [dbo].[cat_basculas_configuracion] CHECK CONSTRAINT [FK_cat_basculas_configuracion_cat_equipos_computo]


ALTER TABLE [dbo].[cat_basculas_configuracion]  WITH CHECK ADD  CONSTRAINT [FK_cat_cajas_basculas_configuracion_cat_basculas] FOREIGN KEY([BasculaId])
REFERENCES [dbo].[cat_basculas] ([BasculaId])


ALTER TABLE [dbo].[cat_basculas_configuracion] CHECK CONSTRAINT [FK_cat_cajas_basculas_configuracion_cat_basculas]





end

