

-- [p_web_productos_sel] 1,'',0,0,0
alter proc [dbo].[p_web_productos_sel]
@pSucursalId int,
@pTexto varchar(200),
@pLinea int,
@pFamilia int,
@pSubfamilia int
as

	select pa.ProductoAgrupadoId,
		pa.Descripcion,
		pa.DescripcionCorta,
		pre.Precio,
		Rating = 0,
		Clave = max(p.Clave)
	from cat_productos_agrupados pa
	inner join cat_productos_agrupados_detalle pad on pad.ProductoAgrupadoId = pa.ProductoAgrupadoId
	inner join cat_productos p on p.ProductoId = pad.ProductoId and p.Estatus = 1
	inner join cat_productos_existencias pe on pe.ProductoId = p.ProductoId
	inner join cat_productos_precios pre on pre.IdProducto = p.ProductoId and
									pre.IdPrecio = 1
	where pe.SucursalId = @pSucursalId and
	(
		pa.Descripcion like '%'+isnull(@pTexto,'')+'%'
	) and
	(
		@pFamilia in(0,p.ClaveFamilia)
	)
	group by pa.ProductoAgrupadoId,
		pa.Descripcion,
		pa.DescripcionCorta,
		pre.Precio
	


