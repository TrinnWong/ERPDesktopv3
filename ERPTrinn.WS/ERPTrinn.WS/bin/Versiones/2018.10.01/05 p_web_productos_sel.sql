if  exists(
	select 1
	from sysobjects
	where name = 'p_web_productos_sel'
)
drop proc p_web_productos_sel
go

create proc p_web_productos_sel
@pSucursalId int
as

	select *
	from cat_productos_agrupados pa
	inner join cat_productos_agrupados_detalle pad on pad.ProductoAgrupadoId = pa.ProductoAgrupadoId
	inner join cat_productos p on p.ProductoId = pad.ProductoId
	inner join cat_productos_existencias pe on pe.ProductoId = p.ProductoId
	where pe.SucursalId = @pSucursalId
	