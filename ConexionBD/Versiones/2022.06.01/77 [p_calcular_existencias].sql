ALTER Proc [dbo].[p_calcular_existencias]
@pSucursalId int,
@pProductoId int,
@pMovimientoDetalleId int = 0
as
BEGIN



	declare @entradas float,
			@entradasAnt float,
			@salidasInv float,
			@salidasVentas float,
			@salidasAnt float,
			@salidasTot float,
			@existencia float,
			@existenciaAnt float,
			@costoUltimaCompra money,
			@costoPromedio money,
			@valuadoCostoUCompra money,
			@valuadoCostoPromedio money,
			@comprasAcumuladas money,
			@tipoMovimiento int,
			@ultimoValorCtoProm money,
			@actualValorMov money,
			@disopnible decimal(14,2),
			@apartado decimal(14,2),
			@esMatriz bit=0,
			@costoPromedioMatriz float,
			@costoUltCompraMatriz float,
			@lastMovId int

	set @esMatriz = case when @pSucursalId = 1 then 1 else 0 end
	select @tipoMovimiento = m.TipoMovimientoId
	from doc_inv_movimiento m
	inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId
	where md.MovimientoDetalleId = @pMovimientoDetalleId


	if(@esMatriz = 0)
	BEGIN		
		select  @lastMovId = md.MovimientoDetalleId
		from doc_inv_movimiento_detalle md
		inner join doc_inv_movimiento m on m.MovimientoId = md.MovimientoId
		where md.ProductoId = @pProductoId and m.SucursalId = 1

		select  @costoPromedioMatriz = isnull(CostoPromedio,0),
				 @costoUltCompraMatriz = isnull(CostoUltimaCompra,0)
		from doc_inv_movimiento_detalle md
		inner join doc_inv_movimiento m on m.MovimientoId = md.MovimientoId 
		where md.ProductoId = @pProductoId AND 
		md.MovimientoDetalleId = @lastMovId
	END

	select @entradas = ISNULL(SUM(MD.Cantidad),0)
	from doc_inv_movimiento m
	inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId and
												md.ProductoId = @pProductoId	
	INNER JOIN cat_tipos_movimiento_inventario 	tm on tm.TipoMovimientoInventarioId = m.TipoMovimientoId and
											tm.EsEntrada=1												
	where (m.Activo =1 OR m.Cancelado = 1) and
	m.Autorizado = 1 and
	m.SucursalId = @pSucursalId


	select @entradasAnt = ISNULL(SUM(MD.Cantidad),0)
	from doc_inv_movimiento m
	inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId and
												md.ProductoId = @pProductoId and
												md.MovimientoDetalleId < @pMovimientoDetalleId
	INNER JOIN cat_tipos_movimiento_inventario 	tm on tm.TipoMovimientoInventarioId = m.TipoMovimientoId and
											tm.EsEntrada=1												
	where (m.Activo =1 OR m.Cancelado = 1) and
	m.Autorizado = 1 and
	m.SucursalId = @pSucursalId


	select @salidasInv = ISNULL(SUM(MD.Cantidad),0)
	from doc_inv_movimiento m
	inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId and
												md.ProductoId = @pProductoId	
	INNER JOIN cat_tipos_movimiento_inventario 	tm on tm.TipoMovimientoInventarioId = m.TipoMovimientoId and
											tm.EsEntrada=0												
	where (m.Activo =1 OR m.Cancelado = 1) and
	m.Autorizado = 1 and
	m.SucursalId = @pSucursalId and
	md.MovimientoDetalleId <= @pMovimientoDetalleId

	select @salidasAnt = ISNULL(SUM(MD.Cantidad),0)
	from doc_inv_movimiento m
	inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId and
												md.ProductoId = @pProductoId	 and
												md.MovimientoDetalleId < @pMovimientoDetalleId
	INNER JOIN cat_tipos_movimiento_inventario 	tm on tm.TipoMovimientoInventarioId = m.TipoMovimientoId and
											tm.EsEntrada=0												
	where (m.Activo =1 OR m.Cancelado = 1) and
	m.Autorizado = 1 and
	m.SucursalId = @pSucursalId and
	md.MovimientoDetalleId <= @pMovimientoDetalleId

	/*OBTENER TODAS LAS COMPRAS*/

	select @comprasAcumuladas = sum(isnull(md.Importe,0))
	from doc_inv_movimiento m
	inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId
	where m.Activo =1  and
	m.Autorizado = 1 and
	m.TipoMovimientoId in (2) and
	md.ProductoId = @pProductoId
	

	set @salidasTot = isnull(@salidasInv,0) 
	set @existencia = isnull(@entradas,0) - isnull(@salidasTot,0)
	set @existenciaAnt = isnull(@entradasAnt,0) - isnull(@salidasAnt,0)

	--select TOP 1 @costoUltimaCompra =  ISNULL(PrecioUnitario,0)
	--from doc_productos_compra pc
	--inner join doc_productos_compra_detalle pcd on pcd.ProductoCompraId = pc.ProductoCompraId
	--WHERE PC.Activo = 1 AND
	--PC.SucursalId = @pSucursalId and
	--pcd.ProductoId = @pProductoId
	--ORDER BY PC.FechaRegistro DESC

	select top 1 @costoUltimaCompra = isnull(md.PrecioUnitario,0)
	from doc_inv_movimiento m
	inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId
	where m.Activo = 1 and
	isnull(m.Cancelado,0) = 0 and
	m.Autorizado = 1 and
	m.TipoMovimientoId in (2,3,7) and
	md.ProductoId = @pProductoId
	order by md.CreadoEl desc	
	
	IF(ISNULL(@costoUltimaCompra,0)=0)
	BEGIN
		SELECT @costoUltimaCompra = CostoCapturaUsuario
		FROM cat_productos_existencias
		WHERE ProductoId = @pProductoId AND
		SucursalId = @pSucursalId
	END

	
	set @valuadoCostoUCompra = ISNULL(isnull(@costoUltimaCompra,0) * isnull(@existencia,0),0)
								/*CASE WHEN  @esMatriz = 1 THEN  
									ISNULL(isnull(@costoUltimaCompra,0) * isnull(@existencia,0),0)
									ELSE ISNULL(isnull(@costoUltCompraMatriz,0) * isnull(@existencia,0),0)
								END*/


	/***********Calcular valor inventario******************/
	if(
		@tipoMovimiento in (2,3,7)
	)
	begin

		select top 1 @ultimoValorCtoProm =md.ValCostoPromedio
		from doc_inv_movimiento m
		inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId
		left join cat_productos_existencias pe on pe.ProductoId = md.ProductoId and
											pe.SucursalId = m.SucursalId
		where md.MovimientoDetalleId <> @pMovimientoDetalleId and
		m.Activo = 1 and
		md.ProductoId = @pProductoId
		order by  md.MovimientoDetalleId desc

		select @actualValorMov = (isnull(PrecioUnitario,0) * isnull(Cantidad,0)) + isnull(Flete,0) +  isnull(Comisiones,0)
		from doc_inv_movimiento_detalle
		where MovimientoDetalleId = @pMovimientoDetalleId		

		set @costoPromedio = cast((@ultimoValorCtoProm + @actualValorMov) / @existencia as decimal(15,2))

			
		select @ultimoValorCtoProm,@actualValorMov,@costoPromedio

	end
	Else
	Begin
		SELECT top 1 @costoPromedio = isnull(CostoPromedio,0)
		from doc_inv_movimiento_detalle md
		inner join doc_inv_movimiento m on m.MovimientoId = md.MovimientoId
		where ProductoId = @pProductoId  and
		m.Sucursalid = @pSucursalId and
		md.MovimientoDetalleId < @pMovimientoDetalleId and
		m.Activo = 1
		order by md.MovimientoDetalleId desc

	End

	/****VALOR COSTO PROMEDIO*****/
	set @valuadoCostoPromedio = ISNULL(isnull(@costoPromedio,0) * isnull(@existencia,0),0)
								/*CASE WHEN @esMatriz = 1 THEN 
										ISNULL(isnull(@costoPromedio,0) * isnull(@existencia,0),0)
									ELSE ISNULL(isnull(@costoPromedioMatriz,0) * isnull(@existencia,0),0)
								END*/



	/**********************************APARTADOS***************************/
	SELECT @apartado = isnull(sum(ap.Cantidad),0)
	FROM doc_apartados a
	inner join doc_apartados_productos ap on ap.ApartadoId = a.ApartadoId
	where ap.ProductoId = @pProductoId
	and a.VentaId is null 
	and a.Activo = 1
	/***********************************************************************/



	update doc_inv_movimiento_detalle
		set Disponible = ISNULL(@existencia,0),
			CostoPromedio = cast(case when ISNULL(@costoPromedio,0) =0 then isnull(pe.CostoPromedio,0)
										  else ISNULL(@costoPromedio,0) 
									end as money)			
							/*CASE WHEN @esMatriz = 1 then 
									cast(case when ISNULL(@costoPromedio,0) =0 then isnull(pe.CostoPromedio,0)
										  else ISNULL(@costoPromedio,0) 
									end as money)
								  else isnull(@costoPromedioMatriz,0) 
							END*/,
			CostoUltimaCompra = ISNULL(@costoUltimaCompra,0),
							/*CASE WHEN @esMatriz = 1 THEN
										cast(case when ISNULL(@costoUltimaCompra,0) =0 then isnull(pe.CostoUltimaCompra,0)
											  else ISNULL(@costoUltimaCompra,0) 
										end as money)
									ELSE isnull(@costoUltCompraMatriz,0) 
								END*/		
			ValorMovimiento = ISNULL(Cantidad,0) * ISNULL(PrecioUnitario,0)
		from doc_inv_movimiento_detalle md
		left join cat_productos_existencias pe on pe.ProductoId = md.ProductoId and
								pe.SucursalId = @pSucursalId
		where MovimientoDetalleId = @pMovimientoDetalleId 

		update doc_inv_movimiento_detalle
		set 		
			ValCostoPromedio = cast(isnull(CostoPromedio,0) * isnull(Disponible,0) as money),
			ValCostoUltimaCompra = cast(isnull(CostoUltimaCompra,0) * isnull(Disponible,0) as money)
		from doc_inv_movimiento_detalle md		
		where MovimientoDetalleId = @pMovimientoDetalleId 

		/*****SI SON NEGATIVOS PONER CERO*****/
		update doc_inv_movimiento_detalle
		set 		
			ValCostoPromedio =case when isnull(ValCostoPromedio,0) <0 then 0 else ValCostoPromedio end,
			ValCostoUltimaCompra = case when isnull(ValCostoUltimaCompra,0) <0 then 0 else ValCostoUltimaCompra end,
			ValorMovimiento = case when isnull(ValorMovimiento,0) <0 then 0 else ValorMovimiento end
		from doc_inv_movimiento_detalle md		
		where MovimientoDetalleId = @pMovimientoDetalleId 

	/********************************************************/

	IF NOT EXISTS(
		SELECT 1
		FROM cat_productos_existencias
		WHERE productoid = @pProductoId
		and SucursalId = @pSucursalId
	)
	BEGIN
		INSERT INTO cat_productos_existencias(
			ProductoId,				SucursalId,				ExistenciaTeorica,		CostoUltimaCompra,		
			CostoPromedio,			ValCostoUltimaCompra,	ValCostoPromedio,		ModificadoEl,			
			CreadoEl,				Apartado,				Disponible
		)
		VALUES(
			@pProductoId,			@pSucursalId,		isnull(@existencia,0),		
			cast(isnull(@costoUltimaCompra,0) as money),
			---CASE WHEN @esMatriz = 1 THEN cast(isnull(@costoUltimaCompra,0) as money) ELSE @costoUltCompraMatriz END,
			cast(
						case when isnull(@costoPromedio,0) = 0 and isnull(@costoUltimaCompra,0) > 0 then 
									isnull(@costoUltimaCompra,0) 
							 else ISNULL(@costoPromedio,0) end as money
						)
			
			/*CASE WHEN @esMatriz = 1 THEN
					cast(
						case when isnull(@costoPromedio,0) = 0 and isnull(@costoUltimaCompra,0) > 0 then 
									isnull(@costoUltimaCompra,0) 
							 else @costoPromedio end as money
						)
				ELSE @costoPromedioMatriz
			END*/,
			cast(ISNULL(@valuadoCostoUCompra,0) as money),	
			cast(ISNULL(@valuadoCostoPromedio,0) as money),
			getdate(),					getdate(),
			isnull(@apartado,0),		isnull(@existencia,0) - isnull(@apartado,0)
		
		)
	END
	Else
	Begin
		update cat_productos_existencias
		SET ExistenciaTeorica = ISNULL(@existencia,0),
			CostoPromedio = CAST(case when isnull(@costoPromedio,0) = 0  
										then ISNULL(CostoPromedio,0) else isnull(@costoPromedio,0) 
								
									end AS MONEY)
			
							/*CASE WHEN @esMatriz = 1 THEN
									CAST(case when isnull(@costoPromedio,0) = 0  
										then ISNULL(CostoPromedio,0) else isnull(@costoPromedio,0) 
								
									end AS MONEY)
								ELSE isnull(@costoPromedioMatriz,0)
							END*/,
			CostoUltimaCompra = 
							cast(case when isnull(@costoUltimaCompra,0) = 0  
										then ISNULL(CostoUltimaCompra,0) else isnull(@costoUltimaCompra,0) 
								
									end as money)
							/*CASE WHEN @esMatriz = 1 THEN
									cast(case when isnull(@costoUltimaCompra,0) = 0  
										then ISNULL(CostoUltimaCompra,0) else isnull(@costoUltimaCompra,0) 
								
									end as money)
									ELSE isnull(@costoUltCompraMatriz,0)
							END*/,
			
			Apartado = isnull(@apartado,0),
			Disponible = isnull(@existencia,0) - isnull(@apartado,0)
		where ProductoId = @pProductoId and
		SucursalId = @pSucursalId

		update cat_productos_existencias
		SET ValCostoUltimaCompra = cast(CostoUltimaCompra * Disponible as money),
		ValCostoPromedio = cast(CostoPromedio * Disponible as money)
		where ProductoId = @pProductoId and
		SucursalId = @pSucursalId
	End

	/****SI SON NEGATIVOS PONER CERO ***/
	update cat_productos_existencias
	SET ValCostoUltimaCompra = case when isnull(ValCostoUltimaCompra,0) <0 then 0 else ValCostoUltimaCompra end,
		ValCostoPromedio = case when isnull(ValCostoPromedio,0) <0 then 0 else ValCostoPromedio end
	where ProductoId = @pProductoId and
	SucursalId = @pSucursalId

END

	

		
	
	











