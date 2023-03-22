IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'SolictarDevolucionPedido'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'SolictarDevolucionPedido','Si la preferencia está activa, se Habilitará la DEVLUCIÓN al finalizar el Pedido',1,0,GETDATE()
END

IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'PermitirEntradaDirectaPV'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'PermitirEntradaDirectaPV','Si la preferencia está activa, se Habilitará la entrada Directa desde el Punto de Venta',1,0,GETDATE()
END


