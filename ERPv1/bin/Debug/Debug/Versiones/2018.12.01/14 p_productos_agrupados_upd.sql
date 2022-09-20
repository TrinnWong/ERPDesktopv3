if exists (
	select 1
	from sysobjects
	where name = 'p_productos_agrupados_upd'
)
drop proc p_productos_agrupados_upd
go

create proc p_productos_agrupados_upd
@pProductoId int
as
	
	select pd2.ProductoId
	into #tmpProdutosRelacionados
	from cat_productos_agrupados_detalle pd
	INNER JOIN cat_productos_agrupados pa on pa.ProductoAgrupadoId = pd.ProductoAgrupadoId
	inner join cat_productos_agrupados_detalle pd2 on pd2.ProductoAgrupadoId = PA.ProductoAgrupadoId AND
											pd2.ProductoId <> @pProductoId
	where pd.ProductoId = @pProductoId

	select *
	into #tmpProducto
	from cat_productos 
	where ProductoId = @pProductoId

	select *
	into #tmpProductosPrecios
	from cat_productos_precios
	where IdProducto=@pProductoId
	

	--Generales
	--Revisar si es un producto agrupado
	update cat_productos
	set Descripcion = t2.Descripcion,
		DescripcionCorta=t2.DescripcionCorta,		
		ClaveMarca = t2.ClaveMarca,
		ClaveFamilia= t2.Clavefamilia,
		ClaveSubFamilia=t2.ClaveSubfamilia,
		ClaveLinea=t2.ClaveLinea,
		ClaveUnidadMedida=t2.ClaveUnidadMedida,
		ProductoTerminado=t2.ProductoTerminado,
		Inventariable=t2.Inventariable,
		MateriaPrima=t2.MateriaPrima,
		ProdParaVenta=t2.ProdParaVenta,
		ProdVtaBascula=t2.ProdVtaBascula,
		Seriado= t2.Seriado,
		NumeroDecimales= t2.NumeroDecimales,
		PorcDescuentoEmpleado=t2.PorcDescuentoEmpleado,
		ContenidoCaja=t2.ContenidoCaja,
		Empresa=t2.Empresa,
		Sucursal=t2.Sucursal,		
		ClaveAlmacen = t2.ClaveAlmacen,
		ClaveAnden=t2.ClaveAnden,
		ClaveLote=t2.ClaveLote,
		FechaCaducidad=t2.FechaCaducidad,
		MinimoInventario= t2.MinimoINventario,
		MaximoInventario= t2.MaximoInventario,
		PorcUtilidad=t2.PorcUtilidad,
		--Talla=t2.Talla,
		ParaSexo= t2.ParaSexo,
		Color=t2.Color,
		Color2=t2.Color2,
		SobrePedido= t2.SobrePedido,
		Especificaciones=t2.Especificaciones
	from cat_productos t1
	inner join #tmpProdutosRelacionados pr on pr.ProductoId = t1.ProductoId
	inner join #tmpProducto t2 on t2.ProductoId = @pProductoId

	--Precios
	UPDATE cat_productos_precios
	set 		
		PorcDescuento=tmp.PorcDescuento,
		MontoDescuento=tmp.MontoDescuento,
		Precio=tmp.Precio
	from cat_productos_precios pp
	inner join #tmpProdutosRelacionados pr on pr.ProductoId = pp.IdProducto 
	inner join #tmpProductosPrecios tmp on tmp.IdProducto = @pProductoId AND
										tmp.IdPrecio = pp.IdPrecio 
											
	
