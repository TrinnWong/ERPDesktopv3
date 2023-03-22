IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'PVCorteCajaOcultarDetalleCajero'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'PVCorteCajaOcultarDetalleCajero','Si la preferencia está activa, se ocultará la información de totales y no se imprimirá el corte. Solo se imprimirá con clave de supervisor',1,0,GETDATE()
END