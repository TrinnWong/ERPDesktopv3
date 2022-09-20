IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'CargoAdicionalTarjeta'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'CargoAdicionalTarjeta','Si la preferencia está activa, se agregará un cargo en cada producto de venta cuando la compra sea pagada con tarjeta. Como Valor se ingresará el porcentaje del valor del producto que se quiere agregar como cargo [Valores de 0 a 100]',1,0,GETDATE()
END