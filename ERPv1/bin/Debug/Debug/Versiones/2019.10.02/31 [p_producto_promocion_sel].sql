--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- p_producto_promocion_sel 1,41,10,0
alter proc [dbo].[p_producto_promocion_sel]
@pSucursalId int,
@pProductoId int,
@pPedidoId int=0,
@pPedidoDetalleId int=0
as

	declare @diaSemena int

	select @diaSemena =datepart(weekday, getdate())	

	select PD.PromocionId,
		ProductoId = @pProductoId,
		p.PorcentajeDescuento
	into #tmpExcepciones
	from doc_promociones p
	inner join cat_productos pro on pro.ProductoId = @pProductoId and
									(
										(p.FechaInicioVigencia <= GETDATE() and
										p.FechaFinVigencia >= GETDATE())
										or
										P.Permanente = 1
									)
	inner join doc_promociones_excepcion pd on pd.PromocionId = p.PromocionId 	
	where p.SucursalId = @pSucursalId and
	p.Activo = 1 and
	(
		(p.Lunes = 1 and @diaSemena = 2) OR
		(p.Martes = 1 and @diaSemena = 3) OR
		(p.Miercoles = 1 and @diaSemena = 4) OR
		(p.Jueves = 1 and @diaSemena = 5) OR
		(p.Viernes = 1 and @diaSemena = 6) OR
		(p.Sabado = 1 and @diaSemena = 7) OR
		(p.Domingo = 1 and @diaSemena = 1) 
	) 
	AND (
		PD.ProductoId = PRO.ProductoId
		or(
			PD.ProductoId IS NULL and
			PD.LineaId = PRO.ClaveLinea AND
			PD.FamiliaId = PRO.ClaveFamilia AND
			PD.Subfamilia = PRO.ClaveSubFamilia
		)
		or(
			PD.ProductoId IS NULL and
			PD.LineaId =pro.ClaveLinea AND
			PD.FamiliaId = PRO.ClaveFamilia AND
			PD.Subfamilia IS NULL
		)
		or(
			PD.ProductoId IS NULL and
			PD.LineaId =pro.ClaveLinea AND
			PD.FamiliaId  is null AND
			PD.Subfamilia IS NULL
		)
		or(
			PD.ProductoId IS NULL and
			PD.LineaId is null AND
			PD.FamiliaId is null AND
			PD.Subfamilia is null
		)
	)
	
	


	select TOP 1 PD.PromocionId,
		ProductoId = @pProductoId,
		p.PorcentajeDescuento	,
		MontoDescuento = cast(0 as decimal(5,2)),
		PromocionCMId = cast(0 as decimal(5,2))
	into #tmpResult
	from doc_promociones p
	inner join cat_productos pro on pro.ProductoId = @pProductoId and
									(
										(p.FechaInicioVigencia <= GETDATE() and
										p.FechaFinVigencia >= GETDATE())
										or
										P.Permanente = 1
									)
	inner join doc_promociones_detalle pd on pd.PromocionId = p.PromocionId 
	--left join doc_promociones_excepcion pe on pe.ProductoId = p.PromocionId									
	where p.SucursalId = @pSucursalId and
	p.Activo = 1 and
	(
		(p.Lunes = 1 and @diaSemena = 2) OR
		(p.Martes = 1 and @diaSemena = 3) OR
		(p.Miercoles = 1 and @diaSemena = 4) OR
		(p.Jueves = 1 and @diaSemena = 5) OR
		(p.Viernes = 1 and @diaSemena = 6) OR
		(p.Sabado = 1 and @diaSemena = 7) OR
		(p.Domingo = 1 and @diaSemena = 1) 
	) 
	AND (
		PD.ProductoId = PRO.ProductoId
		or(
			PD.ProductoId IS NULL and
			PD.LineaId = PRO.ClaveLinea AND
			PD.FamiliaId = PRO.ClaveFamilia AND
			PD.Subfamilia = PRO.ClaveSubFamilia
		)
		or(
			PD.ProductoId IS NULL and
			PD.LineaId =pro.ClaveLinea AND
			PD.FamiliaId = PRO.ClaveFamilia AND
			PD.Subfamilia IS NULL
		)
		or(
			PD.ProductoId IS NULL and
			PD.LineaId =pro.ClaveLinea AND
			PD.FamiliaId  is null AND
			PD.Subfamilia IS NULL
		)
		or(
			PD.ProductoId IS NULL and
			PD.LineaId is null AND
			PD.FamiliaId is null AND
			PD.Subfamilia is null
		)
	)
	AND NOT EXISTS(
		SELECT 1
		FROM #tmpExcepciones st1
		where st1.PromocionId = PD.PromocionId
	)
	ORDER BY p.PorcentajeDescuento desc

	


		select Pedidod = po.PedidoId,
			pod.ProductoId,
			CantidadCompra = cast(sum(pod.Cantidad) as decimal(5,2)),
			CantidadPagarPromo =  (
									cast((cast((sum(pod.Cantidad)  / min(pd.CantidadCompraMinima)) as int) 
									* MAX(pd.CantidadCobro))  as decimal(5,2))
								) +
								(
									sum(pod.Cantidad) -
									(
										min(pd.CantidadCompraMinima) 
										*
										cast((sum(pod.Cantidad)  / min(pd.CantidadCompraMinima)) as int)
									)
								)				
								,
			PrecioUnitario = max(pod.PrecioUnitario),
			pd.PromocionCMId
		into #tmpPromocionesCM
		from doc_promociones_cm_detalle pd
		inner join doc_promociones_cm p on p.PromocionCMId = pd.PromocionCMId
		inner join doc_pedidos_orden po on po.PedidoId = @pPedidoId 
		inner join doc_pedidos_orden_detalle pod on pod.PedidoId = po.PedidoId and
											pod.ProductoId = pd.ProductoId and
											isnull(pod.PromocionCMId,0)= 0
		where pd.ProductoId = @pProductoId and
		p.Activo = 1 and				
		dateadd(minute,datepart(minute,p.HoraVigencia),
		dateadd(hour,datepart(hour,p.HoraVigencia),p.FechaVigencia))	 >= getdate() and
		(CASE 
											WHEN P.Lunes = 1 AND DATEPART(WEEKDAY,GETDATE()) = 2 THEN 1
											WHEN P.Martes = 1 AND DATEPART(WEEKDAY,GETDATE()) = 3 THEN 1
											WHEN P.MIercoles = 1 AND DATEPART(WEEKDAY,GETDATE()) = 4 THEN 1
											WHEN P.Jueves = 1  AND DATEPART(WEEKDAY,GETDATE()) = 5 THEN 1
											WHEN P.Viernes = 1 AND DATEPART(WEEKDAY,GETDATE()) = 6 THEN 1
											WHEN P.Sabado = 1 AND DATEPART(WEEKDAY,GETDATE()) = 7 THEN 1
											WHEN P.Domingo = 1 AND DATEPART(WEEKDAY,GETDATE()) = 1 THEN 1
											else 0
		END) = 1
		group by po.PedidoId,pod.ProductoId,pd.PromocionCMId

		
		
		if exists(
			select 1
			from #tmpPromocionesCM
			where isnull(CantidadPagarPromo,0) < isnull(CantidadCompra,0)
		)
		begin
			
			declare @totalOrig money,
					@totalPromo money,
					@descuento decimal(5,2),
					@totalDescuento money,
					@promocionCMId int

			select @totalOrig = CantidadCompra * PrecioUnitario,
					@totalPromo =CantidadPagarPromo *  PrecioUnitario,
					@promocionCMId = PromocionCMId
			from #tmpPromocionesCM

			

			select @descuento = cast(100 as decimal(5,2)) - ((@totalPromo *  cast(100 as decimal(5,2))) /@totalOrig)

			if(isnull(@totalPromo,0) > 0)
			begin
				select @totalDescuento = @totalOrig * (@descuento/ cast(100 as decimal(5,2)))
				from #tmpPromocionesCM

				delete #tmpResult

				insert into #tmpResult(PromocionId,ProductoId,PorcentajeDescuento,
				MontoDescuento,PromocionCMId)
				select 0,@pProductoId,@descuento,@totalDescuento,@promocionCMId
			end
			

		end
	
	
		select PromocionId,
			ProductoId ,
			PorcentajeDescuento	,
			MontoDescuento ,
			PromocionCMId
		from #tmpResult
	






