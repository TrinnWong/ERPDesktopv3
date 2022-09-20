


-- p_inv_producto_kardex_grd 1,24393
ALTER Proc [dbo].[p_inv_producto_kardex_grd]
@pSucursalId int,
@pProductoId int
as	

	select FechaMov = m.FechaMovimiento,
		SucursalMov=suc.NombreSucursal,
		SucursalOrigen = sucO.NombreSucursal,
		SucursalDestino = sucD.NombreSucursal,
		FolioMov = m.FolioMovimiento,
		Movimiento = tipoMov.Descripcion,
		prod.clave,
		prod.DescripcionCorta,
		CantidadEntrada = ISNULL(case when tipoMov.EsEntrada = 1 then md.Cantidad else 0 end,0),
		CantidadSalida = ISNULL(case when tipoMov.EsEntrada = 0 then md.Cantidad else 0 end,0),
		Existencia = md.Disponible,
		CostoUltimaCompra,
		CostoPromedio,
		ValCostoUltimaCompra,
		ValCostoPromedio,
		m.Comentarios,
		ValorMovimiento	 = case when m.TipoMovimientoId in (2,7) then ValorMovimiento else null end	,
		OtrosCargos = isnull(md.Flete,0) + isnull(md.Comisiones,0)
	from doc_inv_movimiento m
	inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId and
											md.ProductoId=@pProductoId
	inner join cat_tipos_movimiento_inventario tipoMov on tipoMov.TipoMovimientoInventarioId = m.TipoMovimientoId
	inner join cat_sucursales suc on suc.Clave = m.SucursalId
	inner join cat_productos prod on prod.ProductoId = md.ProductoId
	left join cat_sucursales sucO on sucO.Clave = m.SucursalOrigenId
	left join cat_sucursales sucD on sucD.Clave = m.SucursalDestinoId
	where m.SucursalId = @pSucursalId and
	(m.Activo = 1 OR m.Cancelado = 1) and
	m.Autorizado = 1
	order by m.FechaMovimiento ASC









