ALTER proc [dbo].[p_rpt_productos_existencias]
@pSucursalId int,
@pClaveLinea int,
@pClaveFamilia int,
@pClaveSubfamilia int,
@pSoloConExistencia bit,
@pFechaHasta DateTime=null
as

	CREATE TABLE #tmpExistencias
	(
		ProductoId int,
		SucursalId int,
		ExistenciaTeorica Decimal(14,2)
	)

	IF(@pFechaHasta IS NULL)
	BEGIN

		INSERT INTO #tmpExistencias(ProductoId,SucursalId,ExistenciaTeorica)
		SELECT ProductoId,SucursalId,ExistenciaTeorica
		FROM cat_productos_existencias
		WHERE SucursalId = @pSucursalId
	END
	ELSE
	BEGIN
		INSERT INTO #tmpExistencias(ProductoId,SucursalId,ExistenciaTeorica)
		SELECT MD.ProductoId,M.SucursalId,MD.Disponible
		FROM doc_inv_movimiento M
		INNER JOIN doc_inv_movimiento_detalle MD on MD.MovimientoId = M.MovimientoId
		where M.SucursalId = @pSucursalId AND
		MD.MovimientoDetalleId = (
									SELECT MAX(MD2.MovimientoDetalleId) 
									FROM doc_inv_movimiento_detalle MD2 
									INNER JOIN doc_inv_movimiento M2 ON M2.MovimientoId = MD2.MovimientoId
									WHERE M2.SucursalId = M.SucursalId AND
									MD2.ProductoId = MD.ProductoId AND M2.Activo = 1 
									AND CONVERT(VARCHAR,M2.FechaMovimiento,112) <= CONVERT(VARCHAR,@pFechaHasta,112)
								)
		
	END

	SET @pFechaHasta = CASE WHEN @pFechaHasta IS NULL THEN GETDATE() ELSE @pFechaHasta END
	
	select 
			p.ClaveLinea,
			ClaveFamilia=cast(cast(p.claveLinea as varchar) + cast(p.ClaveFamilia as varchar) as int),
			ClaveSubFamilia=cast(cast(p.claveLinea as varchar) + cast(p.ClaveFamilia as varchar) + cast(p.ClaveSubFamilia as varchar) as int),
			Linea = l.Descripcion,
			Familia = f.Descripcion,
			Subfamilia = sf.Descripcion,
			p.Clave,
			Descripcion = p.Clave+'-'+p.Descripcion,
			p.DescripcionCorta,
			pe.ExistenciaTeorica,
			Sucursal = suc.NombreSucursal,
			PrecioVenta = pp.Precio,
			FechaHasta = @pFechaHasta
	from #tmpExistencias pe
	inner join cat_productos p on p.ProductoId = pe.ProductoId and p.Inventariable = 1 AND
									p.ProductoId > 0
	inner join cat_productos_precios pp on pp.IdProducto = p.ProductoId and pp.IdPrecio = 1
	inner join cat_lineas l on l.Clave = p.ClaveLinea
	inner join cat_familias f on f.Clave = p.ClaveFamilia
	inner join cat_subfamilias sf on sf.Clave = p.ClaveSubFamilia
	INNER JOIN cat_sucursales suc on suc.Clave = pe.SucursalId
	where pe.SucursalId = @pSucursalId and
	(
		(isnull(pe.ExistenciaTeorica,0) <> 0 AND @pSoloConExistencia = 1) 
		or
		@pSoloConExistencia = 0
	)and @pClaveLinea in(0,p.ClaveLinea) and
	@pClaveFamilia in(0,p.ClaveFamilia) and
	@pClaveSubfamilia in(0,p.ClaveSubFamilia)
	
	ORDER BY p.ClaveLinea,P.ClaveFamilia,P.ClaveSubFamilia, p.Descripcion
	







