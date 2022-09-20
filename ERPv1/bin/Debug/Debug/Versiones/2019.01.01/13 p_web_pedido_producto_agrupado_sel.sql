IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_web_pedido_producto_agrupado_sel'
)
drop proc p_web_pedido_producto_agrupado_sel
go

-- p_web_pedido_producto_agrupado_sel 1
create proc p_web_pedido_producto_agrupado_sel
@pPedidoConfiguracionId int
as


	select Color = p.Color,
	Descripcion = pa.Descripcion,
	pa.DescripcionCorta,
	pa.Especificaciones,
	pa.Liquidacion,
	pa.Rating,
	productoImagenId = min(pi.ProductoId),
	NombreFoto = min(p2.Clave),
	PrecioVenta = confd.Precio,
	pa.ProductoAgrupadoId
	from doc_pedidos_configuracion conf
	INNER JOIN doc_pedidos_configuracion_det confd on confd.PedidoConfiguracionId = conf.PedidoConfiguracionId
	inner join cat_productos_agrupados_detalle pad on pad.ProductoId = confd.ProductoId
	
	inner join cat_productos_agrupados pa on pa.ProductoAgrupadoId = pad.ProductoAgrupadoId

	inner join cat_productos_agrupados_detalle pad2 on pad2.ProductoAgrupadoId = pa.ProductoAgrupadoId
	inner join cat_productos p on p.ProductoId = confd.ProductoId
	LEFT JOIN cat_productos_imagenes pi on pi.ProductoId = pad2.ProductoId
	left join cat_productos p2 on p2.ProductoiD = PI.ProductoId 
	
	where conf.PedidoConfiguracionId = @pPedidoConfiguracionId
	GROUP BY p.Color,pa.Descripcion,pa.DescripcionCorta,pa.Especificaciones,pa.Liquidacion,
	pa.Rating,confd.Precio,pa.ProductoAgrupadoId
	order by pa.Descripcion
	