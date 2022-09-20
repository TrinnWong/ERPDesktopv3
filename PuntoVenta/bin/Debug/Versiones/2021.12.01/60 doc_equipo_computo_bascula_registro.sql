IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'doc_equipo_computo_bascula_registro'
)
BEGIN


	CREATE TABLE [dbo].[doc_equipo_computo_bascula_registro](
		[Id] [bigint] NOT NULL,
		[EquipoConputoId] [int] NOT NULL,
		[Peso] [float] NOT NULL,
		[CreadoEl] [datetime] NOT NULL,
		[OcupadaPorApp] [BIT] NULL
	 CONSTRAINT [PK_doc_equipo_computo_bascula_registro] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]


	ALTER TABLE [dbo].[doc_equipo_computo_bascula_registro]  WITH CHECK ADD  CONSTRAINT [FK_doc_equipo_computo_bascula_registro_cat_equipos_computo] FOREIGN KEY([EquipoConputoId])
	REFERENCES [dbo].[cat_equipos_computo] ([EquipoComputoId])


	ALTER TABLE [dbo].[doc_equipo_computo_bascula_registro] CHECK CONSTRAINT [FK_doc_equipo_computo_bascula_registro_cat_equipos_computo]


END


