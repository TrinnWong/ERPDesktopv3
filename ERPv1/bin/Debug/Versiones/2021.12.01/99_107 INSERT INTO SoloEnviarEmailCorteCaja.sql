IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'SoloEnviarEmailCorteCaja'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'SoloEnviarEmailCorteCaja','Si la preferencia está activa, se Deshabilitará la impresión y solo se enviará por email',1,0,GETDATE()
END