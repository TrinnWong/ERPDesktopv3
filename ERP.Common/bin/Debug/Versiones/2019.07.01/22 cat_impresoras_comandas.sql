if not exists (
	select 1
	from sysobjects
	where name = 'cat_impresoras_comandas'
)
begin

CREATE TABLE [dbo].[cat_impresoras_comandas](
	[ImpresoraId] [smallint] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_impresoras_comandas] PRIMARY KEY CLUSTERED 
(
	[ImpresoraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_impresoras_comandas]  WITH CHECK ADD  CONSTRAINT [FK_cat_impresoras_comandas_cat_impresoras] FOREIGN KEY([ImpresoraId])
REFERENCES [dbo].[cat_impresoras] ([ImpresoraId])

ALTER TABLE [dbo].[cat_impresoras_comandas] CHECK CONSTRAINT [FK_cat_impresoras_comandas_cat_impresoras]


END
GO


