if NOT EXISTS (
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'PV-Local'
)
BEGIN

Insert Into sis_preferencias(Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl)
VALUES('PV-Local','Si la preferencia está activa, la información de ventas se almacenará localmente',0,0,GETDATE())

END

