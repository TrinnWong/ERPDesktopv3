if exists (
	select 1
	from sysobjects
	where name = 'p_productos_existencia_sel'
)
drop proc p_productos_existencia_sel
go
-- p_productos_existencia_sel 1,0,0,0,0
create Proc [dbo].[p_productos_existencia_sel]
@pSucursal int,
@pLineaId int,
@pFamiliaId int,
@pSubfamiliaId int,
@pProductoId int,
@pSoloConExistencias bit
as
	/**********Obtener existencias de todas las sucursales************/
	select PE.SucursalId,
	PE.ProductoId,
	P.ClaveLinea,
	ClaveFamilia=isnull(P.ClaveFamilia,0),
	ClaveSubFamilia=isnull(P.ClaveSubFamilia,0),
	PE.ExistenciaTeorica
	INTO #tmpExistencias
	from cat_productos_existencias PE
	INNER JOIN cat_productos p on p.ProductoId = pe.ProductoId
	where @pLineaId in (0,isnull(p.ClaveLinea,0)) and
	@pFamiliaId in (0,isnull(p.ClaveFamilia,0)) and
	@pSubfamiliaId in (0,isnull(p.ClaveSubFamilia,0)) and
	@pProductoId in (0,isnull(p.ProductoId,0))

	select tmp.SucursalId,
		  tmp.ClaveLinea,
		  Linea = l.Descripcion,
		  tmp.ClaveFamilia,
		  Familia = f.Descripcion,
		  tmp.ClaveSubFamilia,
		  SubFamilia = sf.Descripcion,
		  tmp.ProductoId,
		  ClaveProducto = p.clave,
		  Producto = p.Descripcion,
		  ExistenciaSucursal = tmp.ExistenciaTeorica,
		  ExistenciaTotal = (select sum(s1.ExistenciaTeorica)  from #tmpExistencias s1 where s1.ProductoId = p.ProductoId),
		  p.Clave,
		  tmp.ExistenciaTeorica,
		  p.Descripcion,
		  SUC.NombreSucursal
	from #tmpExistencias tmp
	INNER JOIN cat_productos P ON P.ProductoId = tmp.ProductoId and p.Inventariable = 1
	inner join cat_sucursales suc on suc.Clave = tmp.SucursalId
	left JOIN cat_familias f on f.Clave = p.ClaveFamilia
	left join cat_subfamilias sf on sf.Clave = p.ClaveSubFamilia
	left join cat_lineas l on l.Clave = p.ClaveLinea
	where tmp.SucursalId = @pSucursal and
	(
		(
			tmp.ExistenciaTeorica <> 0
			and @pSoloConExistencias = 1
		)
		OR
		(
			@pSoloConExistencias = 0
		)
	)
	














