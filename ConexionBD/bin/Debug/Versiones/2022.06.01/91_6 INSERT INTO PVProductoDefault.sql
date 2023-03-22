IF NOT EXISTS(
	SELECT 1
	FROM sis_preferencias
	WHERE Preferencia = 'PVProductoDefault'
)
BEGIN
	INSERT INTO sis_preferencias(
		Preferencia,Descripcion,ParaEmpresa,ParaUsuario,CreadoEl
	)
	SELECT 'PVProductoDefault','Si la preferencia está activa, en cada nueva venta se seleccionará el producto por default de manera automática. Como valor ingresar la clave del producto [VALOR=CLAVE_PRODUCTO]. ',1,0,GETDATE()
END