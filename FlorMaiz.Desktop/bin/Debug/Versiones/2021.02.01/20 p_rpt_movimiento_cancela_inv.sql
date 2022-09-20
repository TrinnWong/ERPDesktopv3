if exists (
	select 1
	from sysobjects
	where name = 'p_rpt_movimiento_cancela_inv'
)
drop proc p_rpt_movimiento_cancela_inv
go
create Proc [dbo].[p_rpt_movimiento_cancela_inv]
@pMovimientoId int,
@pProductoCompraId int
as

	declare @proveedor varchar(200)
	
	
	select @proveedor = prov.Nombre
	from doc_productos_compra pc
	inner join doc_inv_movimiento m on m.ProductoCompraId = pc.ProductoCompraId
	inner join cat_proveedores prov on  prov.ProveedorId = PC.ProveedorId
	where m.MovimientoId = @pMovimientoId OR m.ProductoCompraId = @pProductoCompraId
	

	select SucursalOrigen = suc.NombreSucursal,
		SucursalDestino = sucDes.NombreSucursal,
		TipoMovimiento = TM.Descripcion,
		Folio = m.FolioMovimiento,
		FechaMovimiento = m.FechaCancelacion,
		FechaAfectaInv = m.FechaAutoriza,
		ProductoClave = PROD.Clave,
		Producto = cast(prod.Descripcion as varchar(26)),
		CantidadMov = md.Cantidad,
		PrecioUnitario = md.PrecioUnitario,
		RegistradoPor = usu.NombreUsuario,
		AutorizadoPor = usu2.NombreUsuario	,
		Proveedor = 	isnull(@proveedor,''),
		Remision = pc.NumeroRemision
	from doc_inv_movimiento m
	inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId
	inner join cat_productos prod on prod.ProductoId = md.ProductoId
	inner join cat_sucursales suc on suc.Clave = isnull(m.SucursalOrigenId,m.SucursalId)
	inner join cat_tipos_movimiento_inventario tm on tm.TipoMovimientoInventarioId = m.TipoMovimientoId
	inner join cat_usuarios usu on usu.IdUsuario = m.CreadoPor
	inner join cat_usuarios usu2 on usu2.IdUsuario = M.AutorizadoPor
	left join cat_sucursales sucDes on sucDes.Clave = m.SucursalDestinoId
	left join doc_productos_compra pc on pc.ProductoCompraId = m.ProductoCompraId
	
	where (m.MovimientoId = @pMovimientoId OR m.ProductoCompraId = @pProductoCompraId) AND
	m.Cancelado = 1









