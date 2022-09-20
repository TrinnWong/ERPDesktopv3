
alter proc [dbo].[p_rpt_productos_existencias]
@pSucursalId int,
@pClaveLinea int,
@pClaveFamilia int,
@pClaveSubfamilia int,
@pSoloConExistencia bit
as

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
			PrecioVenta = pp.Precio
	from cat_productos_existencias pe
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
	






