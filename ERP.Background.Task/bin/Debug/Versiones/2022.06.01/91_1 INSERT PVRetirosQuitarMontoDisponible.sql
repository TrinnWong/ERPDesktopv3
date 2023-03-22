IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'PVRetirosQuitarMontoDisponible'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'PVRetirosQuitarMontoDisponible','Si la preferencia está activa, al intentar realizar un retiro se omitirá mostrar el monto disponible. ',1,0,GETDATE()
END