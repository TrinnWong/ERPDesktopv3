if exists (
	select 1
	from sysobjects
	where name = 'p_rpt_cuenta'
)
drop proc p_rpt_cuenta
go

-- p_rpt_cuenta 1
create proc p_rpt_cuenta
@pPedidoId int
as

	declare @meseroId int

	select @meseroId = EmpleadoId
	from doc_pedidos_orden_mesero
	where PedidoOrdenId = @pPedidoId

	select 
		Folio = p.PedidoId,
		e.NombreComercial,
		Cantidad = pd.Cantidad,
		Descripcion = pr.DescripcionCorta,
		PrecioUnitario = pd.PrecioUnitario,
		Importe = pd.Total,
		Mesa = dbo.fnGetComandaMesas(p.PedidoId),
		Mesero = cast(empleado.NumEmpleado as varchar(50)),
		Total = (select sum(Total) from doc_pedidos_orden_detalle where pedidoid= @pPedidoId)
	from doc_pedidos_orden p
	inner join doc_pedidos_orden_detalle pd on pd.PedidoId = p.PedidoId
	inner join cat_sucursales suc on suc.Clave = p.SucursalId
	inner join cat_empresas e on e.Clave = suc.Empresa
	inner join cat_productos pr on pr.ProductoId = pd.ProductoId
	inner join rh_empleados empleado on empleado.NumEmpleado = @meseroId
	where p.PedidoId = @pPedidoId