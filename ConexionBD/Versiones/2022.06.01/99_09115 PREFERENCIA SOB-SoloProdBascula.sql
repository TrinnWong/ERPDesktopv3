
IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'SOB-SoloProdBascula'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'SOB-SoloProdBascula','Si la preferencia está activa. Solo se mostrarán los productos que requieran bascula o sean a granel en el listado de productos sobrantes',1,0,GETDATE()
END