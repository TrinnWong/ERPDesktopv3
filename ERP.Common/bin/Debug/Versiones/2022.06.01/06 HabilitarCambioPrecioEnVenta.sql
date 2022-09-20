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

IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'ConectarConBascula'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'ConectarConBascula','Si la preferencia está activa, se intentará hacer la conexión con báscula',1,0,GETDATE()
END

IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'UsarPesoInteligente'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'UsarPesoInteligente','Si la preferencia está activa, se intentará obtener el peso de bascula desde una tarea central',1,0,GETDATE()
END

IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'PVExcluirReibido'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'PVExcluirReibido','Si la preferencia está activa, el Punto de Venta dejará de Solicitar el monto recibido al cobrar',1,0,GETDATE()
END

IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'SolictarDevolucionPedido'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'SolictarDevolucionPedido','Si la preferencia está activa, se Habilitará la DEVLUCIÓN al finalizar el Pedido',1,0,GETDATE()
END

IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'PermitirEntradaDirectaPV'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'PermitirEntradaDirectaPV','Si la preferencia está activa, se Habilitará la entrada Directa desde el Punto de Venta',1,0,GETDATE()
END


IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'CargaBuscadorProductosAlAbrir'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'CargaBuscadorProductosAlAbrir','Si la preferencia está activa, se cargarán los productos al abrir el buscador de productos, se recomienda tener esta preferencia activa si no hay muchos productos en BD',1,0,GETDATE()
END


