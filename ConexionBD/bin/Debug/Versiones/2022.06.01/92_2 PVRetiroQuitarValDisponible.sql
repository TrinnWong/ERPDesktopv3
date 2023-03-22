IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'PVRetiroQuitarValDisponible'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'PVRetiroQuitarValDisponible','Si la preferencia está activa, se omitirá la validación de monto disponible para retirar, se podrá retirar un monto mayor a las ventas registradas. NO NECESITA VALOR ',1,0,GETDATE()
END