IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'PV-RetiroAutomatico'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'PV-RetiroAutomatico','Preferencia que se utiliza para generar avisos automaticos para retiros. Se requiere ingresar valor para saber la cantidad fija que se deberá de retirar cuando haya la cantidad disponible en caja ',1,0,GETDATE()
END