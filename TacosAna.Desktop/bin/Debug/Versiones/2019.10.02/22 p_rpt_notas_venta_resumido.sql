
-- p_rpt_notas_venta_resumido 1,1,'20180101','20180801'
alter proc [dbo].[p_rpt_notas_venta_resumido]
@pSucursalId int,
@pCajaId int,
@pMesaId int,
@pDel DateTime,
@pAl  DateTime
as

	select 
		Empresa = emp.NombreComercial,
		Sucursal = suc.NombreSucursal,
		Del = @pDel,
		Al = @pAl,
		Folio = 'NV'+cast(v.VentaId as varchar),
		Fecha = cast(v.Fecha as date),
		Caja = caja.Descripcion,
		Mesa = [dbo].[fnGetComandaMesas](po.PedidoId),
		Total = case when v.FechaCancelacion is null then v.TotalVenta + v.TotalDescuento else 0 end,
		Descuento =case when v.FechaCancelacion is null then v.TotalDescuento else 0 end,
		Importe = case when v.FechaCancelacion is null then v.TotalVenta else 0 end,
		Cajero = rh.Nombre,
		Estatus = case when v.FechaCancelacion is not null then 'C' else '' END
	from doc_ventas v
	inner join cat_sucursales suc on suc.Clave = v.SucursalId
	inner join cat_cajas caja on caja.Clave = v.CajaId
	inner join cat_empresas emp on emp.Clave = suc.Empresa
	inner join cat_usuarios usu on usu.IdUsuario = v.UsuarioCreacionId
	inner join rh_empleados rh on rh.NumEmpleado = usu.IdEmpleado
	left join doc_pedidos_orden po on po.VentaId = v.VentaId 
	left join doc_pedidos_orden_mesa pom on pom.PedidoOrdenId = po.PedidoId 
									
	
	where v.SucursalId = @pSucursalId and
	@pCajaId  in (0,v.CajaId) and
	CONVERT(VARCHAR,v.Fecha,112)  between CONVERT(VARCHAR,@pDel,112) and CONVERT(VARCHAR,@pAl,112) --and
	and (
										(@pMesaId  > 0 and pom.MesaId = @pMesaId)
										OR
										@pMesaId = 0
									)
	group by emp.NombreComercial,
		 suc.NombreSucursal,
		
		cast(v.VentaId as varchar),
		 cast(v.Fecha as date),
		 caja.Descripcion,
		 [dbo].[fnGetComandaMesas](po.PedidoId),
		 case when v.FechaCancelacion is null then v.TotalVenta + v.TotalDescuento else 0 end,
		case when v.FechaCancelacion is null then v.TotalDescuento else 0 end,
		case when v.FechaCancelacion is null then v.TotalVenta else 0 end,
		 rh.Nombre,
		 case when v.FechaCancelacion is not null then 'C' else '' END,
		 v.VentaId
	order by v.VentaId





