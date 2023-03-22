If not exists (
	SELECT 1
	FROM [cat_tipos_movimiento_inventario]
	WHERE TipoMovimientoInventarioId in (27,28,29,30)
)
BEGIN

	INSERT INTO [cat_tipos_movimiento_inventario](
	TipoMovimientoInventarioId,Descripcion,Activo,EsEntrada,TipoMovimientoCancelacionId
	)
	VALUES(27,'Entrada por Traspaso(Devolución)(CANCELACIÓN)',1,0,NULL)


	INSERT INTO [cat_tipos_movimiento_inventario](
	TipoMovimientoInventarioId,Descripcion,Activo,EsEntrada,TipoMovimientoCancelacionId
	)
	VALUES(28,'Entrada por Traspaso(Devolución)',1,1,27)


	INSERT INTO [cat_tipos_movimiento_inventario](
	TipoMovimientoInventarioId,Descripcion,Activo,EsEntrada,TipoMovimientoCancelacionId
	)
	VALUES(29,'Salida por Traspaso(Devolución)(CANCELACIÓN)',1,1,NULL)


	INSERT INTO [cat_tipos_movimiento_inventario](
	TipoMovimientoInventarioId,Descripcion,Activo,EsEntrada,TipoMovimientoCancelacionId
	)
	VALUES(30,'Salida por Traspaso(Devolución)',1,0,29)

END


