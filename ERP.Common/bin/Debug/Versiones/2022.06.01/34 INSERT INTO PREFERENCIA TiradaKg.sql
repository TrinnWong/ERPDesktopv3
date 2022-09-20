IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'EquivalenciaTiradaMasaTortillaKg'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'EquivalenciaTiradaMasaTortillaKg','Preferencia que se utiliza para guardar la equivalencia de Tiradas de Masa-Kilos Tortilla. Como valor se ingresarán los kilos de tortilla a los cuales equivale una tirada de masa ',1,0,GETDATE()
END