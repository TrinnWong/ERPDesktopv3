IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'sis_cuenta'
)
BEGIN

CREATE TABLE [dbo].[sis_cuenta](
	[EmpresaId] [int] NOT NULL,
	[ClienteKey] [varchar](2000) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](2000) NOT NULL,
 CONSTRAINT [PK_sis_config_api] PRIMARY KEY CLUSTERED 
(
	[EmpresaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[sis_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_sis_cuenta_cat_empresas] FOREIGN KEY([EmpresaId])
REFERENCES [dbo].[cat_empresas] ([Clave])


ALTER TABLE [dbo].[sis_cuenta] CHECK CONSTRAINT [FK_sis_cuenta_cat_empresas]


END
GO


