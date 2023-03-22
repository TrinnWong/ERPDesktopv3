IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'PVExcluirBasculaPedidos'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'PVExcluirBasculaPedidos','Si la preferencia está activa, el sistema no se conectará a la báscula al querere registrar un producto a granel, el peso se ingresará manualmente',1,0,GETDATE()
END