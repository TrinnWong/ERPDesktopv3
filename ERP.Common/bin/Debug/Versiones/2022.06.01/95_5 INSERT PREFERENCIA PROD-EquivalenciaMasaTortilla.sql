IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'PROD-EquivalenciaMasaTortilla'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'PROD-EquivalenciaMasaTortilla','Si la preferencia está activa, como valor se ingresará los kilos de masa que se necesitan para producir un kilo de tortilla',1,0,GETDATE()
END
GO
IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'CCaja-TortilleriaMetodoCalculo'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'CCaja-TortilleriaMetodoCalculo','Si la preferencia está activa, como valor se ingresará la clave del método que se usará para el calculo del corte de caja [MODE-MAIZ]=El calculo del corte de realizará en base a los kilos de maiz usado en producción. [MODE-TIRADAS]=El calculo del corte se realizará en base a las los kilos de masa que se hayan producido para masa de venta y masa para tortillas',1,0,GETDATE()
END
GO