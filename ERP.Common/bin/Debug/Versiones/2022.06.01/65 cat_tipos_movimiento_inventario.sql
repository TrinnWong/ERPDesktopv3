IF NOT EXISTS (
	SELECT 1
	FROM cat_tipos_movimiento_inventario
	WHERE TipoMovimientoInventarioId = 26
)
BEGIN

	INSERT INTO cat_tipos_movimiento_inventario(TipoMovimientoInventarioId,Descripcion,Activo,EsEntrada,TipoMovimientoCancelacionId)
	VALUES(26,'Devolucion de Pedido',1,1,NULL)

END