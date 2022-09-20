IF NOT EXISTS (
	SELECT 1
	FROM [cat_tipos_requisiciones]
)
BEGIN

	INSERT INTO [dbo].[cat_tipos_requisiciones](
	TipoRequisicionId,Descripcion,CreadoEl)
	VALUES(1,'PR',GETDATE())

	INSERT INTO [dbo].[cat_tipos_requisiciones](
	TipoRequisicionId,Descripcion,CreadoEl
	)
	VALUES(2,'PO',GETDATE())

END