
IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'SOB-HabilitarDevolucion'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'SOB-HabilitarDevolucion','Si la preferencia está activa. Se habilitará la captura de devoluciones',1,0,GETDATE()
END