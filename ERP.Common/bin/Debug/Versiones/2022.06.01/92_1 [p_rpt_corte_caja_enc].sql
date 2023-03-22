
-- [p_rpt_corte_caja_enc] 49
ALTER Proc [dbo].[p_rpt_corte_caja_enc]
@pCorteCajaId int
as

	declare @egresos money,
			@apartados money,
			@vales money,
			@cajaId int,
			@efectivo money,
			@tarjetas money,
			@fondoFinal money

	select @egresos = isnull(Gastos,0)
	from [dbo].[doc_corte_caja_egresos]
	where CorteCajaId = @pCorteCajaId

	
	select @apartados = sum(a.Importe)
	from doc_apartados_pagos a
	inner join doc_corte_caja cc on cc.CorteCajaId = @pCorteCajaId 
	where a.FechaPago between cc.FechaApertura and cc.FechaCorte and
	cc.CreadoPor = a.CreadoPor


	select @vales = isnull(sum(monto),0)
	from doc_ventas_formas_pago_vale fpv
	inner join doc_ventas v on v.ventaId = fpv.VentaId
	inner join doc_corte_caja cc on cc.cortecajaid = @pCorteCajaId
	where v.cajaid = @cajaId and
	fpv.CreadoEl between cc.FechaApertura and cc.FechaCorte and
	cc.cajaId = v.cajaId

	/***Efectivo de ventas y apartados*****/
	select @efectivo = SUM(VD.Total)
	FROM doc_ventas_detalle VD
	INNER JOIN doc_corte_caja_ventas CCV ON CCV.CorteId = @pCorteCajaId AND
								CCV.VentaId = VD.VentaId
	INNER JOIN doc_ventas_formas_pago VFP ON VFP.VentaId = CCV.VentaId AND VFP.FormaPagoId = 1
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND V.FechaCancelacion IS NULL
	
	select @tarjetas = SUM(VD.Total)
	FROM doc_ventas_detalle VD
	INNER JOIN doc_corte_caja_ventas CCV ON CCV.CorteId = @pCorteCajaId AND
								CCV.VentaId = VD.VentaId
	INNER JOIN doc_ventas_formas_pago VFP ON VFP.VentaId = CCV.VentaId AND VFP.FormaPagoId <> 1
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND V.FechaCancelacion IS NULL
	
	SELECT @fondoFinal = ISNULL(SUM(Total),0)
	from doc_corte_caja_denominaciones
	where CorteCajaId = @pCorteCajaId

	select
			suc.NombreSucursal,
			Direccion = RTRIM(ISNULL(suc.Calle,'')) + ' '+
						RTRIM(ISNULL(suc.NoExt ,'')) + ' ' +
						RTRIM(ISNULL(suc.NoInt,'')) +' '+
						RTRIM(ISNULL(suc.Colonia, '')) + ' '+
						RTRIM(ISNULL(suc.Ciudad,'')) +','+
						RTRIM(ISNULL(suc.Estado,'')) +','+
						RTRIM(ISNULL(suc.Pais,'')),
			RFC = emp.RFC,
			NombreEmpresa = NombreComercial,
			Apertura = cc.FechaApertura,
			Corte = cc.FechaCorte,
			FolioIni = isnull(VentaIniId,0),
			FolioFin=isnull(VentaFinId,0),
			Usuario = rh.Nombre,
			Caja = caj.Descripcion,
			CC.TotalCorte,
			Egresos = @egresos,
			FolioVenta =isnull(v.Ventaid,0),
			TotalVenta = isnull(@efectivo,0)+isnull(@tarjetas,0),--case when v.activo = 0 then 0 else  isnull(v.TotalVenta,0) end,
			TotalNV = case when isnull(v.activo,0) = 0 then 0 else V.TotalVenta end,
			cc.CorteCajaId,
			Estatus = case when v.activo = 0 then 'C' else '' END,
			TotalApartado = isnull(@apartados,0),
			TotalGeneral =ISNULL(fi.Total,0) + isnull(@efectivo,0)+isnull(@tarjetas,0)-isnull(@egresos,0),
			Efectivo = @efectivo,
			Tarjetas=@tarjetas,
			FondoInicial = ISNULL(fi.Total,0),
			FondoFinal = @fondoFinal
		from doc_corte_caja cc
		inner join cat_cajas caj on cc.CajaId = caj.Clave
		inner join cat_sucursales suc on suc.Clave = caj.Sucursal
		inner join cat_empresas emp on emp.Clave = suc.Empresa	
		inner join cat_usuarios usu on usu.IdUsuario = CreadoPor
		inner join rh_empleados rh on rh.NumEmpleado = usu.IdEmpleado
		LEFT join doc_ventas v on v.VentaId between VentaIniId and VentaFinId AND
									cc.CorteCajaId = @pCorteCajaId and
									v.SucursalId = suc.Clave and
									V.VentaId NOT IN(
										SELECT ap.VentaId
										FROM doc_apartados ap
										where isnull(ap.VentaId,0) > 0
									)	
		LEFT JOIN doc_declaracion_fondo_inicial fi on fi.CorteCajaId = cc.CorteCajaId AND
											fi.CajaId = caj.Clave AND
											fi.SucursalId = caj.Sucursal
												
		where cc.CorteCajaId = @pCorteCajaId
		



	








