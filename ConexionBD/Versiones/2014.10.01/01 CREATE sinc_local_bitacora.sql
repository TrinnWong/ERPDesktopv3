

CREATE TABLE [dbo].[sinc_local_bitacora](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecordSyncId] [int] NOT NULL,
	[TableName] [varchar](500) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[Scope] [varchar](500) NULL,
 CONSTRAINT [PK_SincronizacionLocalBitacora] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


