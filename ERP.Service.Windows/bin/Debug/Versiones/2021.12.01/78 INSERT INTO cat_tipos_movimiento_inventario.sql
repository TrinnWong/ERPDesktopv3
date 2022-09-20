IF NOT EXISTS (
	SELECT 1
	FROM cat_tipos_movimiento_inventario
	WHERE TipoMovimientoInventarioId = 25
)
BEGIN
	INSERT INTO cat_tipos_movimiento_inventario(
	TipoMovimientoInventarioId,Descripcion,Activo,EsEntrada,TipoMovimientoCancelacionId
	)
	values(25,'Desperdicio de Inventario',1,0,NULL)
END