
-- [p_rpt_VentaTicket] 66
ALTER PROC [dbo].[p_rpt_VentaTicket]
@pVentaId INT
AS


	declare @Giro varchar(20) ,
		@Observaciones varchar(500)	

	select @Giro = Giro
	from cat_configuracion

	select @Observaciones = case when @Giro = 'AUTOLAV'
								then 'Nombre:'+cli.Nombre + ', ' +
									'Modelo:'+isnull(a.Modelo,'') + ' ' +
									isnull(a.Color,'') + ' ' +
									isnull(a.placas,'') + ', '+
									'Obs:'+isnull(a.Observaciones,'')
								else ''
							End
	from doc_ventas v
	inner join cat_clientes cli on cli.clienteId = v.ClienteId
	inner join cat_clientes_automovil a on a.ClienteId = cli.clienteId
	where VentaId = @pVentaId

	SELECT  suc.NombreSucursal,
			Direccion = RTRIM(ISNULL(suc.Calle,'')) + ' '+
						RTRIM(ISNULL(suc.NoExt ,'')) + ' ' +
						RTRIM(ISNULL(suc.NoInt,'')) +' '+
						RTRIM(ISNULL(suc.Colonia, '')) + ' '+
						RTRIM(ISNULL(suc.Ciudad,'')) +','+
						RTRIM(ISNULL(suc.Estado,'')) +','+
						RTRIM(ISNULL(suc.Pais,'')) ,
			FOLIO = cast(v.Folio as bigint),
			vd.VentaDetalleId,
			FECHA = CONVERT(VARCHAR,v.FechaCreacion,103),
			HORA = CONVERT(VARCHAR,v.FechaCreacion,108),
			Producto = case when isnull(vd.Descripcion,'') = '' then
									prod.DescripcionCorta + ' ' +isnull(prod.talla,'') + ' ' + 
									case 
										when prod.ProductoId = 0 then isnull(pcm.NombrePromocion,'') 
										when vd.cargoAdicionalId > 0 then cargo.Descripcion
										else '' 
									end
							else isnull(vd.Descripcion,'')
						end,
			Cantidad = vd.Cantidad,
			ImportePartida = vd.Total,
			TotalVenta = v.TotalVenta,
			TotalDescuentoVenta = v.TotalDescuento,
			SubTotalVenta = v.TotalVenta - v.Impuestos,
			ImpuestosVenta = v.Impuestos,
			TotalRecibido = SUM(vfp.Cantidad) + isnull(v.cambio,0),
			suc.Telefono1,
			RFC = emp.RFC,
			vd.PrecioUnitario,
			v.Cambio,
			TextoCabecera1 = conf.TextoCabecera1,
			conf.TextoCabecera2,
			conf.TextoPie,
			Serie = isnull(conf.Serie,''),
			Atendio = rhe.Nombre,
			MotivoCancelacion =case when isnull(v.MotivoCancelacion,'') = '' then ''
									else 'Motivo Cancelaci�n:' + isnull(v.MotivoCancelacion,'')
								End,
			TasaIVA = isnull(max(vd.TasaIVA),0),
			Observaciones = @Observaciones,
			FolioOrden = ISNULL(TP.Folio,'') + PO.Folio,
			Titulo = ISNULL(emp.NombreComercial,'')+ISNULL(suc.NombreSucursal,'')
	FROM dbo.doc_ventas v
	INNER JOIN dbo.doc_ventas_detalle vd ON vd.VentaId = v.VentaId
	INNER JOIN dbo.cat_productos prod ON prod.ProductoId = vd.ProductoId
	INNER JOIN dbo.cat_sucursales suc ON suc.Clave = v.SucursalId	
	inner join cat_empresas emp on emp.Clave = 1
	inner join cat_usuarios usu on usu.IdUsuario = v.UsuarioCreacionId
	inner join rh_empleados rhE on rhE.NumEmpleado = usu.IdEmpleado
	left JOIN dbo.doc_ventas_formas_pago vfp ON vfp.VentaId = v.VentaId
	LEFT JOIN cat_configuracion_ticket_venta conf on conf.SucursalId = v.SucursalId
	left join doc_promociones_cm pcm on pcm.PromocionCMId = vd.PromocionCMId
	left join	cat_cargos_adicionales cargo on cargo.CargoAdicionalId = vd.CargoAdicionalId
	LEFT JOIN	doc_pedidos_orden PO on PO.VentaId = v.VentaId
	LEFT JOIN	cat_tipos_pedido TP on TP.TipoPedidoId = PO.TipoPedidoId
	WHERE v.VentaId = @pVentaId
	GROUP BY v.VentaId,suc.Calle,suc.NoExt ,suc.NoInt,suc.Colonia,suc.Ciudad,suc.Estado,suc.Pais,v.FechaCreacion,
	prod.DescripcionCorta,vd.Cantidad,vd.Total,v.TotalVenta,v.TotalDescuento,v.Impuestos,v.Impuestos,vd.VentaDetalleId,
	suc.NombreSucursal,suc.Telefono1,emp.RFC,vd.PrecioUnitario,v.Cambio,prod.talla,
	conf.TextoCabecera1,conf.TextoCabecera2,conf.TextoPie,conf.Serie,rhe.Nombre,
	v.MotivoCancelacion,v.Folio,pcm.NombrePromocion,prod.ProductoId,
	vd.cargoAdicionalId,cargo.Descripcion,vd.Descripcion,PO.Folio,TP.Folio,emp.NombreComercial













