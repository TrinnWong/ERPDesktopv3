if  exists(
	select 1
	from sysobjects
	where name = 'sis_bitacora_errores'
)
BEGIN
DROP TABLE sis_bitacora_errores
END
GO
if not exists(
	select 1
	from sysobjects
	where name = 'sis_bitacora_errores'
)
begin
	CREATE TABLE [dbo].[sis_bitacora_errores](
		[IdError] [int] NOT NULL,
		[Sistema] [varchar](50) NOT NULL,
		[Clase] [varchar](250) NULL,
		[Metodo] [varchar](250) NULL,
		[Error] [varchar](500) NOT NULL,
		[CreadoEl] [datetime] NULL,
	 CONSTRAINT [PK_sis_bitacora_errores] PRIMARY KEY CLUSTERED 
	(
		[IdError] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

end
GO


