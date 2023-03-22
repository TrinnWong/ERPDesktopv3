IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'CorteCajaEmail'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'CorteCajaEmail','Si la preferencia está activa, se enviará el corte de caja detallado a los correos configurados en el valor de esta preferencia [Valor=usuario@example.com]',1,0,GETDATE()
END