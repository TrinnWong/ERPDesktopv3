if exists (
	select 1
	from sysobjects 
	where name = 'p_pv_cargos_adicionales_grd'
)
drop proc p_pv_cargos_adicionales_grd
go

-- p_pv_cargos_adicionales_grd 1
create proc p_pv_cargos_adicionales_grd
@pSucursalId int
as

	select
		a.CargoAdicionalId,
		a.Descripcion,
		Detalle = case when isnull(b.PorcentajeVenta,0) > 0 then cast(isnull(b.PorcentajeVenta,0) as varchar)+' % '
						when isnull(b.MontoFijo,0) > 0 then '$' + cast(isnull(b.MontoFijo,0) as varchar)
				end,
		Seleccion = cast(0 as bit)
	from cat_cargos_adicionales a
	inner join doc_cargo_adicional_config b on b.CargoAdicionalId = a.CargoAdicionalId
	where b.SucursalId = @pSucursalId and
	b.Activo = 1 
	