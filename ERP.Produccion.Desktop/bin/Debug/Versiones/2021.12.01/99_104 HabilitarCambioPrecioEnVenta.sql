IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'HabilitarCambioPrecioEnVenta'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'HabilitarCambioPrecioEnVenta','Si la preferencia está activa, se permitirá el cambio de precio por el cajero dentro del punto de venta',1,0,GETDATE()
END