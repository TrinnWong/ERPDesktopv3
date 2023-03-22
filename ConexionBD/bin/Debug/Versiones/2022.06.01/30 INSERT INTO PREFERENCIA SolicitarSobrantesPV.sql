IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'SolicitarSobrantesPV'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'SolicitarSobrantesPV','Si la preferencia está activa, Será requerido que haya una captura de sobrantes para el dia anterior, no se podrá usar el punto de venta sin la captura de sobrantes',1,0,GETDATE()
END