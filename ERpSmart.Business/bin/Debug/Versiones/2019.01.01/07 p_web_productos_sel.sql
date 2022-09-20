if exists (
	select 1
	from sysobjects
	where name = 'p_web_productos_sel'
)
drop proc p_web_productos_sel
go

-- [p_web_productos_sel] 1,'',0,1,0
CREATE proc [dbo].[p_web_productos_sel]
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
		Clave = (
			select min(s1.clave)
			from cat_productos s1
			inner join cat_productos_agrupados s2 on s2.productoid=s1.productoId
			inner join cat_productos_imagenes si on si.productoId = s1.ProductoId
			where s2.ProductoAgrupadoId = pa.ProductoAgrupadoId
		)
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
		OR
		(
			@pFamilia = 9999 --Liquidacion
			and 
			p.Liquidacion = 1
		)
	)
	group by pa.ProductoAgrupadoId,
		pa.Descripcion,
		pa.DescripcionCorta,
		pre.Precio
	
	



