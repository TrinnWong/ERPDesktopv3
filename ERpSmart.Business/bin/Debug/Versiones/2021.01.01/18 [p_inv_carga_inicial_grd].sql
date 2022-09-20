
-- p_inv_carga_inicial_grd 1,1,2,0
ALTER Proc [dbo].[p_inv_carga_inicial_grd]
@pSucursaldId int,
@pFamiliaId int,
@pSubFamiliaId int,
@pVerListadoGeneral bit
as

	select 
		ci.CargaInventarioId,
		p.Clave,
		p.ProductoId,
		p.Descripcion,
		CostoPromedio = isnull(ci.CostoPromedio,0),
		UltimoCosto = isnull(ci.UltimoCosto,0),
		InventarioFisico = isnull(ci.Cantidad,0),
		TieneCargaInicial = cast(case when max(md.ProductoId) > 0 then 1 else 0 end as bit) 
	from [dbo].cat_productos p
	left join doc_inv_carga_inicial ci on ci.ProductoId = p.ProductoId and @pSucursaldId = ci.SucursalId
	left join doc_inv_movimiento m on m.SucursalId = @pSucursaldId and
							m.TipoMovimientoId = 1 and
							m.Autorizado = 1 and
							m.Activo = 1 --Carga Inicial
	left join doc_inv_movimiento_detalle md on md.MovimientoId  = m.MovimientoId and
									md.ProductoId = ci.ProductoId
										
	where p.ProductoId > 0 AND
	(
		(
			@pFamiliaId in( p.ClaveFamilia , 0)
			and @pSubFamiliaId in (p.ClaveSubFamilia ,0)
		)
		OR
		@pVerListadoGeneral = 1
	)
	GROUP BY ci.CargaInventarioId,
		p.Clave,
		p.ProductoId,
		p.Descripcion,
		ci.CostoPromedio,
		ci.UltimoCosto,
		ci.Cantidad
	
	

	






