if exists (
	select 1
	from sysobjects
	where name = 'p_productos_clonar'
)
drop proc p_productos_clonar
go
create proc p_productos_clonar
@pProductoId int,
@pProductoNuevoId int out
as

	declare @pIdProductoPrecio int,
		@pProductoImageId int

	select @pProductoNuevoId=isnull(max(ProductoId),0)+1
	from cat_productos

	begin tran

	insert into cat_productos(
		ProductoId,		Clave,		Descripcion,		DescripcionCorta,
		FechaAlta,		ClaveMarca,	ClaveFamilia,		ClaveSubFamilia,
		ClaveLinea,		ClaveUnidadMedida,ClaveInventariadoPor,ClaveVendidaPor,
		Estatus,		ProductoTerminado,Inventariable,MateriaPrima,
		ProdParaVenta,	ProdVtaBascula,Seriado,NumeroDecimales,
		PorcDescuentoEmpleado,	ContenidoCaja,	Empresa,	Sucursal,
		Foto,			ClaveAlmacen,	ClaveAnden,		ClaveLote,
		FechaCaducidad,	MinimoInventario,MaximoInventario,PorcUtilidad,
		Talla,			ParaSexo,	Color,				Color2,
		SobrePedido,		Especificaciones
	)
	select @pProductoNuevoId,@pProductoNuevoId,		Descripcion,		DescripcionCorta,
		FechaAlta,		ClaveMarca,	ClaveFamilia,		ClaveSubFamilia,
		ClaveLinea,		ClaveUnidadMedida,ClaveInventariadoPor,ClaveVendidaPor,
		Estatus,		ProductoTerminado,Inventariable,MateriaPrima,
		ProdParaVenta,	ProdVtaBascula,Seriado,NumeroDecimales,
		PorcDescuentoEmpleado,	ContenidoCaja,	Empresa,	Sucursal,
		Foto,			ClaveAlmacen,	ClaveAnden,		ClaveLote,
		FechaCaducidad,	MinimoInventario,MaximoInventario,PorcUtilidad,
		Talla,			ParaSexo,	Color,				Color2,
		SobrePedido,		Especificaciones
	from cat_productos
	where ProductoId = @pProductoId

	if @@error <> 0
	begin
		rollback tran
		goto fin
	end
	
	--Insertar Precios
	select @pIdProductoPrecio = isnull(max(IdProductoPrecio),0) 
	from cat_productos_precios

	insert into cat_productos_precios(
		IdProductoPrecio,IdProducto,IdPrecio,PorcDescuento,
		MontoDescuento,Precio
	)
	select ROW_NUMBER() OVER(ORDER BY IdPrecio ASC) + @pIdProductoPrecio,@pProductoNuevoId,IdPrecio,PorcDescuento,
	MontoDescuento,Precio
	from cat_productos_precios
	where IdProducto = @pProductoId

	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	--EXISTENCIAS
	insert into cat_productos_existencias(
			ProductoId,		SucursalId,		ExistenciaTeorica,		CostoUltimaCompra,
			CostoPromedio,	ValCostoUltimaCompra,ValCostoPromedio,	ModificadoEl,
			CreadoEl
		)
		select @pProductoNuevoId,clave,isnull(0,0),0,
		0,0,0,getdate(),
		getdate()
		from cat_sucursales
		where estatus =1 

	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	--IMAGENES
	--select @pProductoImageId =isnull(max(ProductoImageId),0)
	--from cat_productos_imagenes
	


	--insert into cat_productos_imagenes(
	--	ProductoImageId,	ProductoId,		FileName,		CreadoEl,
	--	FileByte,			Principal,		Miniatura
	--)
	--select ROW_NUMBER() OVER(ORDER BY ProductoImageId ASC) + @pProductoImageId,				@pProductoNuevoId,	FileName,	GETDATE(),
	--FileByte,				Principal,		Miniatura
	--from cat_productos_imagenes
	--where ProductoId = @pProductoId


	--if @@error <> 0
	--begin
	--	rollback tran
	--	goto fin
	--end

	commit tran

	fin: