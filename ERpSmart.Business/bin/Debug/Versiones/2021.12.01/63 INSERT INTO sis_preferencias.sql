IF NOT EXISTS (
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'TipoDescuentoEmpleado'
)
BEGIN

	INSERT INTO sis_preferencias(
	Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	VALUES('TipoDescuentoEmpleado','Preferencia que especifica como se aplicará el descuento a empleado, si por Porcentaje o Importe VALORES[PorPorcentaje,PorImporte]',1,0,getdate())

	INSERT INTO sis_preferencias_empresa(
		PreferenciaId,EmpresaId,Valor,CreadoEl
	)
	SELECT Id,1,'PorImporte',GETDATE()
	FROM sis_preferencias
	where Preferencia = 'TipoDescuentoEmpleado'

END

IF NOT EXISTS (
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'ValidarGramosVenta'
)
BEGIN

	INSERT INTO sis_preferencias(
	Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	VALUES('ValidarGramosVenta','Preferencia que habilita la validación de gramos al intentar vender productos de báscula [NO NECESITA VALOR]',1,0,getdate())

	INSERT INTO sis_preferencias_empresa(
		PreferenciaId,EmpresaId,Valor,CreadoEl
	)
	SELECT Id,1,'',GETDATE()
	FROM sis_preferencias
	where Preferencia = 'ValidarGramosVenta'

END