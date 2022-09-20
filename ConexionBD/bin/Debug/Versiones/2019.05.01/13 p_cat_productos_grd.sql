if exists (
	select 1
	from sysobjects
	where name = 'p_cat_productos_grd'
)
drop proc p_cat_productos_grd
go

-- p_cat_productos_grd 1
create proc p_cat_productos_grd
@pEmpresaId int
as

	select p.ProductoId,
			p.Clave,
			p.Descripcion,
			p.DescripcionCorta,
			p.FechaAlta,
			p.ClaveMarca,
			Marca =mar.Descripcion,
			p.ClaveFamilia,
			Familia = fam.Descripcion,
			p.ClaveSubFamilia,
			Subfamilia = sfam.Descripcion,
			p.ClaveLinea,
			Linea = li.Descripcion,
			p.ClaveUnidadMedida,
			Unidad = um.Descripcion,
			p.ClaveInventariadoPor,
			p.ClaveVendidaPor,
			p.Estatus,
			p.ProductoTerminado,
			p.Inventariable,
			p.MateriaPrima,
			p.ProdParaVenta,
			p.ProdVtaBascula,
			p.Seriado,
			p.NumeroDecimales,
			p.PorcDescuentoEmpleado,
			p.ContenidoCaja,
			p.Empresa,
			p.Sucursal,
			p.ClaveAlmacen,
			p.ClaveAnden,
			p.ClaveLote,
			p.FechaCaducidad,
			p.MinimoInventario,
			p.MaximoInventario,
			p.PorcUtilidad,
			p.Talla,
			p.ParaSexo,
			p.Color,
			p.Color2,
			p.SobrePedido,
			p.Especificaciones,
			p.Liquidacion ,
			Foto = FileByte
	from cat_productos p
	left join cat_productos_imagenes pi on pi.ProductoId = p.ProductoId and
									pi.Principal = 1
	inner join cat_familias fam on fam.Clave = p.ClaveFamilia
	inner join cat_subfamilias sfam on sfam.Clave = p.ClaveSubFamilia
	inner join cat_lineas li on li.Clave = p.ClaveLinea
	inner join cat_unidadesmed um on um.Clave = p.ClaveUnidadMedida
	left join cat_marcas mar on mar.Clave = p.ClaveMarca