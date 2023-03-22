
-- p_rpt_ventas_resumen 1
alter proc [dbo].[p_rpt_ventas_resumen]
@pSucursalId int
as


	select  
		v.SucursalId,
		Sucursal = suc.NombreSucursal,
		v.Serie,
		v.Folio,
		p.Clave,
		FechaHora = v.FechaCreacion,
		p.Descripcion,
		vd.Cantidad,
		vd.Descuento,
		Cancelado =cast(case when v.FechaCancelacion is null then 0 else 1 end as bit),
		Total =  case when v.FechaCancelacion is null then  vd.Total else 0 end ,
		Cliente =isnull(c.clave,'') +' '+ c.Nombre,
		Coche = cast(aut.Modelo as varchar) + ' Color:' + isnull(aut.Color,'') +' Placas:' +  isnull(aut.Placas,''),
		FolioPagoWeb = 'Folio:'+cast(w.id as varchar) +' Ref:'+ isnull(TransactionRef,''), 
		Observaciones = isnull(aut.Observaciones,'') +' ' + isnull(v.MotivoCancelacion,'')
	from doc_ventas v
	inner join cat_sucursales suc on suc.Clave = v.SucursalId
	inner join doc_ventas_detalle vd on vd.VentaID= v.ventaId
	inner join cat_productos p on p.ProductoId = vd.ProductoId
	left join cat_clientes c on c.ClienteId = v.ClienteId
	left join cat_clientes_automovil aut on aut.ClienteId = c.ClienteId
	left join doc_web_carrito w on w.VentaId = v.VentaId

	where @pSucursalId in (v.SucursalId,0)
	group by v.SucursalId, suc.NombreSucursal,
	v.Serie,
		v.Folio,
		p.Clave,
		v.FechaCreacion,
		p.Descripcion,
		vd.Cantidad,
		vd.Descuento,
		v.FechaCancelacion,
		vd.Total,
		c.Nombre,
		aut.Modelo,
		aut.Color,
		aut.Placas,
		aut.Observaciones,
		v.MotivoCancelacion,
		c.clave,
		w.id,
		TransactionRef
	order by v.FechaCreacion desc
	

