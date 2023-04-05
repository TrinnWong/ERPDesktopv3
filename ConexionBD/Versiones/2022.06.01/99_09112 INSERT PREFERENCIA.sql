IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'MAIZ-SACO-CLAVE'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'MAIZ-SACO-CLAVE','Preferencia obligatoria para Tortillerías, para conocer la clave con la cual se controlará el inventario de Sacos de Maiz',1,0,GETDATE()
END


IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'MASECA-SACO-CLAVE'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'MASECA-SACO-CLAVE','Preferencia obligatoria para Tortillerías, para conocer la clave con la cual se controlará el inventario de Sacos de Maseca',1,0,GETDATE()
END


IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'QuitarVal-MasecaMaizCorte'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'QuitarVal-MasecaMaizCorte','Si la preferencia está activa, se dejará de solicitar como obligatorio la captura de sacos de Maiz y sacos de Maseca previa al realizar un corte de caja',1,0,GETDATE()
END

