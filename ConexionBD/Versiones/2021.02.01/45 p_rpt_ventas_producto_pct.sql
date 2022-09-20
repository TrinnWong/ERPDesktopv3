if exists (
SELECT 1
FROM sysobjects
where name = 'p_rpt_ventas_producto_pct'
)
drop proc p_rpt_ventas_producto_pct
go

-- p_rpt_ventas_producto_pct '20210126','20210625',0
create proc p_rpt_ventas_producto_pct
@pFechaIni DateTime,
@pFechaFin DateTime,
@pSucursalId int
as

	SELECT P.ProductoId,
		   Impuestos = isnull(SUM(id.Porcentaje),0)
	into #tmpProductosImpuestos
	FROM cat_productos P
	INNER JOIN cat_productos_impuestos i on i.ProductoId = p.ProductoId
	INNER JOIN cat_impuestos id on id.Clave = i.ImpuestoId
	GROUP BY P.ProductoId

	SELECT productoId = vd.ProductoId,
			sucursal = CASE WHEN @pSucursalId = 0 THEN 'TODOS' ELSE max(suc.NombreSucursal) END,
			claveProducto = p.Clave,
			descripcion = p.Descripcion,
			unidad = u.Descripcion,
			cantidad = cast(SUM(vd.Cantidad) as decimal(10,4)),			
			subTotal = cast(ISNULL(sum(VD.Total),0) / (1+(ISNULL(max(PI.Impuestos),0)/100)) as decimal(10,2)),
			impuestos = cast(ISNULL(sum(VD.Total),0) - ISNULL(sum(VD.Total),0) / (1+(ISNULL(max(PI.Impuestos),0)/100)) as decimal(10,2)),
			
			total = cast(sum(VD.Total) as decimal(10,2)),
			porcentajeVenta = cast(0 as decimal(10,2))
	into #tmpResult
	FROM doc_ventas_detalle vd
	INNER JOIN doc_ventas v on v.VentaId = vd.VentaId
	INNER JOIN cat_sucursales suc on suc.Clave = v.SucursalId
	INNER JOIN cat_productos p on p.ProductoId = vd.ProductoId
	INNER JOIN cat_unidadesmed u on u.Clave = p.ClaveUnidadMedida
	LEFT JOIN #tmpProductosImpuestos PI ON PI.ProductoId = p.ProductoId
	where @pSucursalId in (0,v.SucursalId) AND
	v.Activo = 1 AND
	CONVERT(VARCHAR,v.Fecha,112) >= CONVERT(VARCHAR,@pFechaIni,112) AND
	CONVERT(VARCHAR,v.Fecha,112) <= CONVERT(VARCHAR,@pFechaFin,112)
	GROUP BY vd.ProductoId,
			p.Clave,
			p.Descripcion,
			u.Descripcion

			

	DECLARE @TotalVentas float

	SELECT @TotalVentas = SUM(Total)
	FROM #tmpResult

	IF @TotalVentas > 0

		UPDATE #tmpResult
		set porcentajeVenta = ISNULL(Total,0) * 100 / @TotalVentas
		FROM #tmpResult TMP

	SELECT ProductoId ,
			sucursal,
			claveProducto ,
			Descripcion ,
			Unidad ,
			Cantidad ,			
			Impuestos ,
			Subtotal ,
			Total ,
			porcentajeVenta 
	FROM #tmpResult


	


