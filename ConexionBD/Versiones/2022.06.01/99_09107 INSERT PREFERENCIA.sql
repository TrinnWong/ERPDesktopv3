IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'SOBRANTE-QuitarBasculaEnCaptura'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'SOBRANTE-QuitarBasculaEnCaptura','Si la preferencia está activa, se desactivará la báscula al querer captruar los sobrantes desde el PV',1,0,GETDATE()
END
