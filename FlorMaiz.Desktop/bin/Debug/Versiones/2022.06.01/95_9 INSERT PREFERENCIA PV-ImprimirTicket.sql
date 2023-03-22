IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'PV-ImprimirTicket'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'PV-ImprimirTicket','Si la preferencia está activa, se habilitará la impresión de Tickets y como valor se ingresará el monto minimo de venta para realizar la impresión',1,0,GETDATE()
END
GO