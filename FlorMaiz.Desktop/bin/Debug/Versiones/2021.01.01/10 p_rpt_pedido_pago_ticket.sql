if exists (
	select 1
	from sysobjects
	where name = 'p_rpt_pedido_pago_ticket'
)
drop proc p_rpt_pedido_pago_ticket
go

-- p_rpt_pedido_pago_ticket 1,16
create proc p_rpt_pedido_pago_ticket
@pPagoId int,
@pPedidoId int
as

	select Folio = po.PedidoId,
			FechaApartado = po.CreadoEl,
			PagoRealizado =P.Monto,
			FechaPago = p.FechaPago,
			TotalApartado = c.Total,
			Saldo = cast(c.Saldo as money),
			Empresa = e.NombreComercial,
			Sucursal = s.NombreSucursal,
			FechaLimite = pro.FechaProgramada,
			ExpedidoEn = RTRIM(s.Calle) + ' '+
						RTRIM(s.NoExt) + ' '+
						RTRIM(s.NoInt) + ' '+
						RTRIM(s.Colonia) + ' '+
						RTRIM(s.Ciudad) + ' '+
						RTRIM(s.Estado),
			po.ClienteId,
			Cliente = cli.Nombre,
			--------
			ClaveProducto = PROD.Clave,
			Producto = prod.Descripcion,
			Cantidad = pProd.Cantidad,
			Importe = pProd.Total,
			TextoCabecera1 = ISNULL(TextoCabecera1,''),
			TextoCabecera2 = ISNULL(TextoCabecera2,''),
			TextoPie = ISNULL(TextoPie,''),
			AnticipoAbono = 'ANTICIPO',
			Serie = isnull(confA.Serie,'P'),
			Atendio = rh.Nombre
	from doc_pagos p
	INNER join doc_cargos c on c.CargoId = p.CargoId
	inner join doc_pedidos_orden po on po.PedidoId = @pPedidoId and
								po.CargoId = c.CargoId	
	inner join doc_pedidos_orden_detalle pprod on pprod.PedidoId = po.PedidoId
	inner join cat_sucursales s on s.Clave = po.SucursalId
	inner join cat_empresas e on e.Clave = s.Empresa
	inner join cat_clientes cli on cli.ClienteId = po.ClienteId
	inner join cat_productos prod on prod.ProductoId = pprod.ProductoId
	inner join cat_usuarios usu on usu.IdUsuario = p.CreadoPor
	inner join rh_empleados rh on rh.NumEmpleado = usu.IdEmpleado
	left join doc_pedidos_orden_programacion pro on pro.PedidoId = po.PedidoId
	LEFT JOIN cat_configuracion_ticket_apartado confA on confA.SucursalId = po.SucursalId
	where p.PagoId = @pPagoId