if not exists(
	select 1
	from sysobjects
	where name = 'sis_versiones_detalle'
)
begin


CREATE TABLE [dbo].[sis_versiones_detalle](
	[VersionDetalleId] [int] NOT NULL,
	[VersionId] [smallint] NOT NULL,
	[ScriptName] [varchar](250) NOT NULL,
	[Completado] [bit] NOT NULL,
 CONSTRAINT [PK_sis_versiones_detalle] PRIMARY KEY CLUSTERED 
(
	[VersionDetalleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[sis_versiones_detalle]  WITH CHECK ADD  CONSTRAINT [FK_sis_versiones_detalle_sis_versiones] FOREIGN KEY([VersionId])
REFERENCES [dbo].[sis_versiones] ([VersionId])


ALTER TABLE [dbo].[sis_versiones_detalle] CHECK CONSTRAINT [FK_sis_versiones_detalle_sis_versiones]


end

GO


