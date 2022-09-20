
-- p_calcular_existencias 1,1,6
alter Proc [dbo].[p_calcular_existencias]
@pSucursalId int,
@pProductoId int,
@pMovimientoDetalleId int = 0
as


	declare @entradas float,
			@salidasInv float,
			@salidasVentas float,
			@salidasTot float,
			@existencia float,
			@costoUltimaCompra money,
			@costoPromedio money,
			@valuadoCostoUCompra money,
			@valuadoCostoPromedio money,
			@comprasAcumuladas money,
			@tipoMovimiento int,
			@ultimoValorCtoProm money,
			@actualValorMov money,
			@disopnible decimal(14,2),
			@apartado decimal(14,2)

	select @tipoMovimiento = m.TipoMovimientoId
	from doc_inv_movimiento m
	inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId
	where md.MovimientoDetalleId = @pMovimientoDetalleId

	select @entradas = ISNULL(SUM(MD.Cantidad),0)
	from doc_inv_movimiento m
	inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId and
												md.ProductoId = @pProductoId	
	INNER JOIN cat_tipos_movimiento_inventario 	tm on tm.TipoMovimientoInventarioId = m.TipoMovimientoId and
											tm.EsEntrada=1												
	where m.Activo = 1 and
	m.Autorizado = 1 and
	m.SucursalId = @pSucursalId


	select @salidasInv = ISNULL(SUM(MD.Cantidad),0)
	from doc_inv_movimiento m
	inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId and
												md.ProductoId = @pProductoId	
	INNER JOIN cat_tipos_movimiento_inventario 	tm on tm.TipoMovimientoInventarioId = m.TipoMovimientoId and
											tm.EsEntrada=0												
	where m.Activo = 1 and
	m.Autorizado = 1 and
	m.SucursalId = @pSucursalId

	/*OBTENER TODAS LAS COMPRAS*/

	select @comprasAcumuladas = sum(isnull(md.Importe,0))
	from doc_inv_movimiento m
	inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId
	where m.Activo = 1 and
	m.Autorizado = 1 and
	m.TipoMovimientoId in (2) and
	md.ProductoId = @pProductoId
	

	set @salidasTot = isnull(@salidasInv,0) 
	set @existencia = isnull(@entradas,0) - isnull(@salidasTot,0)

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
	m.TipoMovimientoId in (2,3) and
	md.ProductoId = @pProductoId
	order by md.CreadoEl desc

	--if(isnull(@costoUltimaCompra,0) = 0)
	--begin 
	--	select TOP 1 @costoUltimaCompra = MD.CostoUltimaCompra
	--	from doc_inv_movimiento_detalle md
	--	inner join doc_inv_movimiento m on m.MovimientoId = md.MovimientoId
	--	where m.Activo = 1 and
	--	m.Autorizado = 1 and
	--	md.ProductoId = @pProductoId and
	--	m.SucursalId = @pSucursalId
	--	ORDER BY  MovimientoDetalleId DESC
	--end

	

	set @costoPromedio = case when  ISNULL(@existencia,0) = 0 then 0 else isnull(@comprasAcumuladas,0)/ISNULL(@existencia,0) end

	set @valuadoCostoPromedio = ISNULL(isnull(@costoPromedio,0) * isnull(@existencia,0),0)
	set @valuadoCostoUCompra = ISNULL(isnull(@costoUltimaCompra,0) * isnull(@existencia,0),0)


	/***********Calcular valor inventario******************/
	if(
		@tipoMovimiento in (2,7)
	)
	begin

		select top 1 @ultimoValorCtoProm = isnull(ValCostoPromedio,0)
		from doc_inv_movimiento m
		inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId
		where md.MovimientoDetalleId <> @pMovimientoDetalleId and
		m.Activo = 1
		order by  md.MovimientoDetalleId desc

		select @actualValorMov = isnull(PrecioUnitario,0) * isnull(Cantidad,0)
		from doc_inv_movimiento_detalle
		where MovimientoDetalleId = @pMovimientoDetalleId		

		SELECT @costoPromedio = case when ISNULL(@existencia,0) = 0 then 
										(isnull(@actualValorMov,0)+ isnull(@ultimoValorCtoProm,0)) 
										else
										(isnull(@actualValorMov,0)+ isnull(@ultimoValorCtoProm,0)) /  ISNULL(@existencia,0)
								End

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

	/**********************************APARTADOS***************************/
	SELECT @apartado = isnull(sum(ap.Cantidad),0)
	FROM doc_apartados a
	inner join doc_apartados_productos ap on ap.ApartadoId = a.ApartadoId
	where ap.ProductoId = @pProductoId
	and a.VentaId is null 
	and a.Activo = 1
	
	IF NOT EXISTS(
		SELECT 1
		FROM cat_productos_existencias
		WHERE productoid = @pProductoId
		and SucursalId = @pSucursalId
	)
	BEGIN
		INSERT INTO cat_productos_existencias(
			ProductoId,				SucursalId,			ExistenciaTeorica,		CostoUltimaCompra,		CostoPromedio,
			ValCostoUltimaCompra,	ValCostoPromedio,	ModificadoEl,			CreadoEl,
			Apartado,				Disponible
		)
		VALUES(
			@pProductoId,			@pSucursalId,		isnull(@existencia,0),			isnull(@costoUltimaCompra,0),		
			case when isnull(@costoPromedio,0) = 0 and isnull(@costoUltimaCompra,0) > 0 then isnull(@costoUltimaCompra,0) else @costoPromedio end ,
			ISNULL(@valuadoCostoUCompra,0),	ISNULL(@valuadoCostoPromedio,0),getdate(),					getdate(),
			isnull(@apartado,0),				isnull(@existencia,0) - isnull(@apartado,0)
		
		)
	END
	Else
	Begin
		update cat_productos_existencias
		SET ExistenciaTeorica = ISNULL(@existencia,0),
			CostoPromedio = case when isnull(CostoPromedio,0) = 0 and ISNULL(@costoUltimaCompra,0) > 0 
								then ISNULL(@costoUltimaCompra,0) else isnull(CostoPromedio,0) 
							end,
			CostoUltimaCompra = ISNULL(@costoUltimaCompra,0),
			ValCostoPromedio = ISNULL(@valuadoCostoPromedio,0),
			ValCostoUltimaCompra = ISNULL(@valuadoCostoUCompra,0),
			Apartado = isnull(@apartado,0),
			Disponible = isnull(@existencia,0) - isnull(@apartado,0)
		where ProductoId = @pProductoId and
		SucursalId = @pSucursalId
	End

	
	

		
	
	







