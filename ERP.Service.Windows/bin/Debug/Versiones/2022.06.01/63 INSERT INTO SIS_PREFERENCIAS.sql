IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'PVBotonRegistroBasculaPedidosApp'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'PVBotonRegistroBasculaPedidosApp','Si la preferencia está activa, se mostrará un botón en el punto de venta en dode se podrá registrar la báscula de pedidos registrados desde la app. NO NECESITA VALOR',1,0,GETDATE()
END