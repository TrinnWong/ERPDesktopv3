IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'PROD-EquivalenciaMaizSacoTortillaKg'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'PROD-EquivalenciaMaizSacoTortillaKg','Preferencia que se utiliza para guardar la equivalencia de Kilos Tortilla  por cada Saco de Maiz. Como valor se ingresarán los kilos de tortilla a los cuales equivale un saco de Maiz ',1,0,GETDATE()
END

IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'PROD-EquivalenciaMasecaSacoTortillaKg'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'PROD-EquivalenciaMasecaSacoTortillaKg','Preferencia que se utiliza para guardar la equivalencia de Kilos Tortilla  por cada Saco de Maseca. Como valor se ingresarán los kilos de tortilla a los cuales equivale un saco de Maseca ',1,0,GETDATE()
END