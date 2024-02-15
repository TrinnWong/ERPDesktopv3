
-- p_corte_caja_validaMovs 9,3,'20220921',0
ALTER Proc [dbo].[p_corte_caja_validaMovs]
@pCajaId int,
@pUsuarioId int,
@pFechaHoraCorte datetime,
@pHayMovimientos bit out
as

	set @pHayMovimientos = 0
	set dateformat dmy
	declare @fechaUltimoCorte datetime,
		@corteCajaId int,
		@gastos money,
		@ventaIniId int,
		@ventaFinId int,
		@error varchar(500) = '',
		@esSupervisorGral bit

		set @pFechaHoraCorte = dbo.fn_GetDateTimeServer()

	select @fechaUltimoCorte = isnull(max(FechaCorte),'19000101')
	from doc_corte_caja
	where CajaId = @pCajaId	

	

	select @esSupervisorGral = EsSupervisor
	from cat_usuarios
	where IdUsuario = @pUsuarioId

	--validar CANCELACIONES
	if not exists(
		select 1
		from doc_ventas v
		where cajaId = @pCajaId and
		FechaCancelacion between 
		@fechaUltimoCorte and @pFechaHoraCorte
		and v.activo = 1 
		and (
			UsuarioCreacionId = @pUsuarioId OR
			@esSupervisorGral = 1
		)
	)
	--validar retiros
	and not exists(
		select 1
		from doc_retiros r
		where 
		(
			r.CreadoPor = @pUsuarioId
			OR
			@esSupervisorGral = 1
		)
		 and
		
			r.CajaId = @pCajaId 
			
		 and
		r.FechaRetiro between @fechaUltimoCorte and @pFechaHoraCorte
	)
	--validar gastos
	and not exists(
		select 1
		from doc_gastos g
		where g.CajaId = @pCajaId and
		(
			g.CreadoPor = @pUsuarioId
			OR
			@esSupervisorGral = 1
		) and
		g.CreadoEl between @fechaUltimoCorte and @pFechaHoraCorte
	)
	--validar devoluciones
	and not exists(
		select 1
		from doc_devoluciones dev
		where (
			dev.CreadoPor = @pUsuarioId
			OR
			@esSupervisorGral =1
		) and
		dev.CreadoEl between @fechaUltimoCorte and @pFechaHoraCorte
		
	)
	--Validar ventas
	and not exists (
		select 1
		from doc_ventas v
		where cajaId = @pCajaId and
		Fecha > @pFechaHoraCorte 
		and v.activo = 1 
		and (
			UsuarioCreacionId = @pUsuarioId
			OR
			@esSupervisorGral = 1
		)
		
	)
	--validar apartados
	and not exists (
		select 1
		from doc_apartados a
		inner join doc_apartados_pagos ap on ap.ApartadoId = a.ApartadoId
		where a.CajaId = @pCajaId  and
		ap.FechaPago between 
		@fechaUltimoCorte and @pFechaHoraCorte and
		a.Activo = 1 and
		(
			ap.CreadoPor = @pUsuarioId
			or 
			@esSupervisorGral = 1
		)
	)	
	
	begin
		set @error= 'No hay movimientos para generar el corte'		
		set @pHayMovimientos = 0
	
	end
	else
		set @pHayMovimientos = 1

	select @error














