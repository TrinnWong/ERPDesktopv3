IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'CorteCajaSubReporteVentasExistenciasProd'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'CorteCajaSubReporteVentasExistenciasProd','Si la preferencia está activa, se mostrará un subreporte en el corte de caja con un listado de productos, ventas y existencia Final.',1,0,GETDATE()
END