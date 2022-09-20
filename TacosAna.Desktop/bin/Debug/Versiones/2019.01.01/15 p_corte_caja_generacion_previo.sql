
-- p_corte_caja_generacion_previo 1,1,'20180516',0,1
ALTER Proc [dbo].[p_corte_caja_generacion_previo]
@pCajaId int,
@pUsuarioId int,
@pFechaHoraCorte datetime,
@pCorteCajaId int out,
@pPermitirCorteEnCero bit
as


	declare @fechaUltimoCorte datetime,
		@corteCajaId int,
		@gastos money,
		@retiros money,
		@ventaIniId int,
		@ventaFinId int,
		@sucursalId int,
		@esSupervisorGral bit,
		@cajeroOrigId int

	/***Limpiar tablas***/
	select CorteCajaId
	into #tmpCorteCaja_temp
	from [doc_corte_caja_previo]
	where CreadoPor = @pUsuarioId	


	delete [doc_corte_caja_apartados_pagos]
	from [doc_corte_caja_apartados_pagos] a
	inner join #tmpCorteCaja_temp tmp on tmp.CorteCajaId = a.CorteCajaId

	delete doc_corte_caja_denominaciones_previo
	from doc_corte_caja_denominaciones_previo a
	inner join #tmpCorteCaja_temp tmp on tmp.CorteCajaId = a.CorteCajaId

	delete doc_corte_caja_egresos_previo
	from doc_corte_caja_egresos_previo a
	inner join #tmpCorteCaja_temp tmp on tmp.CorteCajaId = a.CorteCajaId

	delete doc_corte_caja_fp_apartado_previo
	from doc_corte_caja_fp_apartado_previo a
	inner join #tmpCorteCaja_temp tmp on tmp.CorteCajaId = a.CorteCajaId

	delete doc_corte_caja_fp_previo
	from doc_corte_caja_fp_previo a
	inner join #tmpCorteCaja_temp tmp on tmp.CorteCajaId = a.CorteCajaId

	delete doc_corte_caja_previo
	from doc_corte_caja_previo a
	inner join #tmpCorteCaja_temp tmp on tmp.CorteCajaId = a.CorteCajaId

	delete doc_corte_caja_ventas_previo
	from doc_corte_caja_ventas_previo a
	inner join #tmpCorteCaja_temp tmp on tmp.CorteCajaId = a.CorteId
	/*******************************/
	


	select @esSupervisorGral = usu.EsSupervisor
	from cat_usuarios usu
	where usu.IdUsuario = @pUsuarioId	


	select @pFechaHoraCorte = case when max(Fecha) > getdate() then max(Fecha) else getdate() end
	from doc_ventas
	where activo = 1

	set @pFechaHoraCorte = isnull(@pFechaHoraCorte,getdate())


	select @fechaUltimoCorte = convert(varchar,getdate(),112)
	--from doc_corte_caja
	--where CajaId = @pCajaId

	select @sucursalId  =Sucursal
	from cat_cajas
	where Clave = @pCajaId


	if @fechaUltimoCorte = '19000101' 
	begin
		select @fechaUltimoCorte = min(Fecha)
		from doc_ventas
		where CajaId = @pCajaId
	end

	begin tran

	select @corteCajaId = isnull(max(CorteCajaId),0) + 1
	from doc_corte_caja_previo

	select @pCorteCajaId = @corteCajaId


	--validar CANCELACIONES
	if not exists(
		select 1
		from doc_ventas v
		where cajaId = @pCajaId and
		FechaCancelacion between 
		@fechaUltimoCorte and @pFechaHoraCorte
		and v.activo = 1 
		--and (
		--	UsuarioCreacionId = @pUsuarioId or
		--	@esSupervisorGral = 1
		--)
	)
	--validar retiros
	and not exists(
		select 1
		from doc_retiros r
		where 
		--(
		--	r.CreadoPor = @pUsuarioId or
		--	@esSupervisorGral = 1
		--) and
		r.CajaId = @pCajaId and
		r.FechaRetiro between @fechaUltimoCorte and @pFechaHoraCorte
	)
	--validar gastos
	and not exists(
		select 1
		from doc_gastos g
		where g.CajaId = @pCajaId and
		--(
		--	g.CreadoPor = @pUsuarioId or
		--	@esSupervisorGral = 1
		--) and
		g.CreadoEl between @fechaUltimoCorte and @pFechaHoraCorte
	)
	--validar devoluciones
	and not exists(
		select 1
		from doc_devoluciones dev
		where 
		--(
		--	dev.CreadoPor = @pUsuarioId or
		--	@esSupervisorGral = 1
		--) and
		dev.CreadoEl between @fechaUltimoCorte and @pFechaHoraCorte
		
	)
		
	--validar apartados
	and not exists (
		select 1
		from doc_apartados a
		inner join doc_apartados_pagos ap on ap.ApartadoId = a.ApartadoId
		where a.CajaId = @pCajaId  and
		ap.FechaPago between 
		@fechaUltimoCorte and @pFechaHoraCorte and
		a.Activo = 1 
		--and
		--(
		--	ap.CreadoPor = @pUsuarioId or
		--	@esSupervisorGral = 1
		--)
	)	
	--
	if not exists (
		select 1
		from doc_ventas v
		where cajaId = @pCajaId and
		Fecha between 
		@fechaUltimoCorte and @pFechaHoraCorte
		and v.activo = 1 
		--and (
		--	v.UsuarioCreacionId = @pUsuarioId 
		--	or
		--	@esSupervisorGral = 1
		--)
		having isnull(max(ventaid),0) > 0
	)	
	AND @pPermitirCorteEnCero = 0
	begin
		RAISERROR (15600,-1,-1, 'No hay movimientos para generar el corte');  
		
		goto fin
	
	end

	/************LIMITAR LAS VENTAS QUE SE PUEDEN CONSIDERAR EN EL CORTE*****************/
	select *
	into #tmpVentas
	from doc_ventas
	where cajaId = @pCajaId and
	UsuarioCreacionId = @pUsuarioId AND

	Fecha between 
	@fechaUltimoCorte and @pFechaHoraCorte --AND
	--(
	--	UsuarioCreacionId = @pUsuarioId
	--	or
	--	@esSupervisorGral = 1
	--)
	--Quitar los tickets de apartados
	and ventaId not in (
		select VentaId
		from doc_apartados
		where isnull(ventaid,0) > 0
	)

	if(@esSupervisorGral = 1)
		select @cajeroOrigId = UsuarioCreacionId
		from #tmpVentas

	insert into doc_corte_caja_previo(
		CorteCajaId,	CajaId,		CreadoEl,		CreadoPor,
		VentaIniId,		VentaFinId,	FechaApertura,	FechaCorte,
		TotalCorte,		TotalIngresos,TotalEgresos)
	select @corteCajaId, @pCajaId, getdate(),		@pUsuarioId,
		min(VentaId),	max(ventaid),isnull(@fechaUltimoCorte,getdate()),	@pFechaHoraCorte,
		isnull(sum(
			case when v.Activo = 1 then TotalVenta 
				else 0
			end
		),0), isnull(sum(case when v.Activo = 1 then TotalVenta 
				else 0
			end),0),			0
	from #tmpVentas v
	--where cajaId = @pCajaId and
	--Fecha between 
	--@fechaUltimoCorte and @pFechaHoraCorte AND
	--UsuarioCreacionId = @pUsuarioId
	

	
	if @@error <> 0
	begin 
		rollback tran
		goto fin
	end


	insert into doc_corte_caja_ventas_previo(CorteId,VentaId,CreadoEl)
	select @corteCajaId, v.VentaId,GETDATE()
	from #tmpVentas v

	if @@error <> 0
	begin 
		rollback tran
		goto fin
	end

	select @gastos = isnull(sum(Monto),0)
	from doc_gastos
	where activo = 1 and
	cajaid = @pCajaId and
	creadoEl between @fechaUltimoCorte and @pFechaHoraCorte 
	--and
	--(
	--	CreadoPor = @pUsuarioId
	--	or
	--	@esSupervisorGral = 1
	--)

	select @retiros = sum(MontoRetiro)
	from doc_retiros r
	where r.SucursalId = @sucursalId AND
	--(
	--	r.CreadoPor = @pUsuarioId
	--	or
	--	@esSupervisorGral = 1
	--) and
	r.CajaId = @pCajaId and
	r.FechaRetiro  between @fechaUltimoCorte and @pFechaHoraCorte 


	update doc_corte_caja_previo
	set TotalEgresos = isnull(@gastos,0) + isnull(@retiros,0)
	where CorteCajaId = @corteCajaId

	if @@error <> 0
	begin 
		rollback tran
		goto fin
	end

	insert into doc_corte_caja_egresos_previo(CorteCajaId,Gastos)
	select @corteCajaId,@gastos

	if @@error <> 0
	begin 
		rollback tran
		goto fin
	end

	select @ventaIniId=VentaIniId,
		@ventaFinId=VentaFinId
	from doc_corte_caja_previo
	where cortecajaId = @corteCajaId
	
	insert into [dbo].[doc_corte_caja_fp_previo](
		CorteCajaId,FormaPagoId,Total,CreadoEl
	)
	select @corteCajaId,vfp.FormaPagoId,sum(Cantidad),getdate()
	from [dbo].[doc_ventas_formas_pago] vfp
	inner join #tmpVentas v on v.ventaId = vfp.ventaId
	where v.VentaId between @ventaIniId and @ventaFinId
	and v.Activo = 1
	--AND (
	--	V.UsuarioCreacionId = @pUsuarioId
	--	or
	--	@esSupervisorGral = 1
	--)
	group by vfp.FormaPagoId


	if @@error <> 0
	begin 
		rollback tran
		goto fin
	end

	insert into [doc_corte_caja_fp_apartado_previo](
		CorteCajaId,FormaPagoId,Total,CreadoEl
	)
	select @corteCajaId,fp.FormaPagoId,isnull(Sum(Cantidad),0),GETDATE()
	from [dbo].[doc_apartados_formas_pago] fp
	inner join doc_apartados_pagos ap on ap.ApartadoPagoId = fp.ApartadoPagoId
	where ap.Cajaid = @pCajaId AND
	FechaPago between @fechaUltimoCorte and @pFechaHoraCorte 
	group by fp.FormaPagoId



	if @@error <> 0
	begin 
		rollback tran
		goto fin
	end

	insert into [dbo].[doc_corte_caja_apartados_pagos_previo](
		CorteCajaId,ApartadoPagoId,CreadoEl
	)
	select @corteCajaId,ap.ApartadoPagoId,GETDATE()
	from  doc_apartados_pagos ap 
	where ap.Cajaid = @pCajaId AND
	ap.FechaPago between @fechaUltimoCorte and @pFechaHoraCorte 
	group by ap.ApartadoPagoId


	if @@error <> 0
	begin 
		rollback tran
		goto fin
	end



	
	commit tran


	fin:







