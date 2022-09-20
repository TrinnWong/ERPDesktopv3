IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'DesactivarBotonesProductosTouchPV'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'DesactivarBotonesProductosTouchPV','Si la preferencia está activa, se desactivará la carga de botonera para familias y productos al iniciar el punto de venta',1,0,GETDATE()
END