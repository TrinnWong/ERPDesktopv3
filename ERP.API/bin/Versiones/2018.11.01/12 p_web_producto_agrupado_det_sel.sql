
-- p_web_producto_agrupado_det_sel 1
alter proc p_web_producto_agrupado_det_sel
@pProductoAgrupadoId int
as

	select pa.ProductoAgrupadoId,
		pa.Descripcion,
		pa.DescripcionCorta,
		pre.Precio,
		Rating = 0,
		Clave = p.Clave,
		p.ProductoId,
		p.Talla,
		Especificaciones = cast(pa.Especificaciones as varchar(500)),
		p.Color,
		P.Color2,
		p.SobrePedido,
		ProductoImagenId = MIN(pI.ProductoId),
		pe.ExistenciaTeorica
	from cat_productos_agrupados pa
	inner join cat_productos_agrupados_detalle pad on pad.ProductoAgrupadoId = pa.ProductoAgrupadoId
	inner join cat_productos p on p.ProductoId = pad.ProductoId and
							p.estatus = 1
	inner join cat_productos_existencias pe on pe.ProductoId = p.ProductoId
	inner join cat_productos_precios pre on pre.IdProducto = p.ProductoId and
									pre.IdPrecio = 1
	left join cat_productos_imagenes pi on pi.ProductoId = p.ProductoId
	where pa.ProductoAgrupadoId = @pProductoAgrupadoId and
	(
		p.SobrePedido = 1 OR
		pe.ExistenciaTeorica > 0
	)
	group by pa.ProductoAgrupadoId,
		pa.Descripcion,
		pa.DescripcionCorta,
		pre.Precio,
		p.Clave,
		p.ProductoId,
		p.Talla,
		p.Color,
		P.Color2,
		p.SobrePedido,
		PE.ExistenciaTeorica,
		pa.Especificaciones
	


