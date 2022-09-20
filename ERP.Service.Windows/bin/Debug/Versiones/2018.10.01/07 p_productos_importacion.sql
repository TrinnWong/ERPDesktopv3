if exists(
	select 1
	from sysobjects
	where name = 'p_productos_importacion'
)
drop proc p_productos_importacion
go

-- p_productos_importacion 1,1,'BLING','JUEGO SENCILOO','ECO2J1-66','JUEGO BLING PLATEADO ROSA','JUEGO BLING PLATEADO ROSA',132,12,0
CREATE Proc [dbo].[p_productos_importacion]
@pEmpresa int,
@pSucursalId int,
@pLinea varchar(100),
@pFamilia varchar(100),
@pClaveProducto varchar(50),
@pDescripcionCorta varchar(30),
@pDescripcionLarga varchar(60),
@pPrecio money,
@pExistencias decimal(6,2),
@pInsertado bit out,
@pIVA int,
@pUnidad varchar(100),
@pMarca varchar(100),
@pSubfamilia varchar(100),
@pTalla varchar(5),
@pParaSexo varchar(1),
@pColor varchar(10),
@pColor2 varchar(10),
@pSobrePedido bit,
@pCreadoPor int
as
BEGIN

	declare @familiaId int,
			@lineaId int,
			@subfamiliaId int,
			@productoId int,
			@marcaId int,
			@unidadId int


	SET @pInsertado = 0

	select @lineaId = Clave
	from cat_lineas f
	where rtrim(f.Descripcion) = rtrim(@pLinea)

	select @familiaId = Clave
	from cat_familias f
	where rtrim(f.Descripcion) = rtrim(@pFamilia)

	select @subfamiliaid = Clave
	from cat_subfamilias f
	where rtrim(f.Descripcion) = rtrim(@pSubFamilia)

	SELECT @productoId = ProductoId
	from cat_productos
	where RTRIM(Clave) = RTRIM(@pClaveProducto)

	SELECT @marcaId = Clave
	from cat_marcas
	where upper(RTRIM(Descripcion)) = upper(RTRIM(@pMarca))

	SELECT @unidadId = Clave
	from cat_unidadesmed
	where upper(RTRIM(Descripcion)) = upper(RTRIM(@pUnidad))

	BEGIN TRAN

	

	if(
		isnull(@lineaId,0) = 0
	)
	begin 
		select @lineaId = isnull(max(Clave),0) +1
		from cat_lineas

		insert into cat_lineas(Empresa,Sucursal,Clave,Descripcion,Estatus)
		select @pEmpresa,@pSucursalId, @lineaId,@pLinea,1
	end

	IF @@ERROR <> 0
	BEGIN
		ROLLBACK TRAN
		GOTO FIN
	END

	if(
		isnull(@familiaId,0) = 0
	)
	begin 
		select @familiaId = isnull(max(Clave),0) +1
		from cat_familias

		insert into cat_familias(Empresa,Sucursal,Clave,Descripcion,Estatus)
		select @pEmpresa,@pSucursalId,@familiaId,@pFamilia,1
	end

	IF @@ERROR <> 0
	BEGIN
		ROLLBACK TRAN
		GOTO FIN
	END

	if(
		isnull(@subfamiliaId,0) = 0
	)
	begin 
		select @subfamiliaId = isnull(max(Clave),0) +1
		from cat_subfamilias

		insert into cat_subfamilias(Clave,Descripcion,Familia,Estatus,
		Empresa,Sucursal)
		select @subfamiliaId,@pSubfamilia,@familiaiD,1,
		@pEmpresa,@pSucursalId
	end

	IF @@ERROR <> 0
	BEGIN
		ROLLBACK TRAN
		GOTO FIN
	END


	if(
		isnull(@marcaId,0) = 0
	)
	begin 
		select @marcaId = isnull(max(Clave),0) +1
		from cat_marcas

		insert into cat_marcas(Clave,Descripcion,Estatus,Empresa,Sucursal)
		select @marcaId,@pMarca,1,1,1
	end

	IF @@ERROR <> 0
	BEGIN
		ROLLBACK TRAN
		GOTO FIN
	END

	if(
		isnull(@unidadId,0) = 0
	)
	begin 
		select @unidadId = isnull(max(Clave),0) +1
		from cat_unidadesmed

		insert into cat_unidadesmed(
			Clave,		Descripcion,	DescripcionCorta,Decimales,
			Estatus,	Empresa,		Sucursal,		IdCodigoSAT
		)
		select @unidadId,@pUnidad,@pUnidad,0,
		1,@pEmpresa,1,null
	end

	

	IF @@ERROR <> 0
	BEGIN
		ROLLBACK TRAN
		GOTO FIN
	END

	
	if(ISNULL(@productoId,0) = 0 and isnull(@pClaveProducto,'') != '')
	begin

		SELECT @productoId = isnull(max(ProductoId),0)+1
		FROM cat_productos

		insert into cat_productos(
		Empresa,			Sucursal,
			ProductoId,		ClaveLinea,		ClaveFamilia,		Descripcion,
			DescripcionCorta,Estatus,		Clave,				NumeroDecimales,
			PorcDescuentoEmpleado,ContenidoCaja,ProductoTerminado,Inventariable,
			MateriaPrima,	ProdParaVenta,	ProdVtaBascula,		Seriado,
			FechaAlta	,	ClaveMarca,		ClaveSubfamilia,
			--
			Talla,			ParaSexo,		Color,				Color2,
			SobrePedido,	ClaveUnidadMedida,ClaveInventariadoPor
			)
		select 
			@pEmpresa,@pSucursalId,
			@productoId,@lineaId,@familiaId,@pDescripcionLarga,
			@pDescripcionCorta,1,@pClaveProducto,				0,
			0,				0,				1,					1,
			0,				1,				0,					0,
			GETDATE(),		@marcaId,		@subfamiliaId,
			@pTalla,		@pParaSexo,		@pColor,			@pColor2,
			@pSobrePedido,	@unidadId,		@unidadId
			
		IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRAN
			GOTO FIN
		END

		declare @IdProductoPrecio int

		select @IdProductoPrecio = isnull(max(IdProductoPrecio),0) + 1
		from cat_productos_precios

		--
		insert into cat_productos_precios(
			IdProductoPrecio,IdProducto,IdPrecio,
			PorcDescuento,MontoDescuento,Precio)
		select @IdProductoPrecio + IdPrecio,@productoId,
		IdPrecio,0,0, case when IdPrecio = 1 then @pPrecio else 0 end
		from cat_precios

		IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRAN
			GOTO FIN
		END

		insert into cat_productos_existencias(
			ProductoId,		SucursalId,		ExistenciaTeorica,		CostoUltimaCompra,
			CostoPromedio,	ValCostoUltimaCompra,ValCostoPromedio,	ModificadoEl,
			CreadoEl
		)
		select @productoId,clave,isnull(@pExistencias,0),0,
		0,0,0,getdate(),
		getdate()
		from cat_sucursales
		where estatus =1 
		
		
		IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRAN
			GOTO FIN
		END

		/**********Insertar carga inicial***********/
		declare @cargainventarioId int

		if not exists(
			select 1
			from [doc_inv_carga_inicial]
			where productoId = @productoId and
			SucursalId = @pSucursalId
		)
		begin
				select @cargainventarioId = isnull(max(cargainventarioId),0)+1
				from [doc_inv_carga_inicial]

				insert into [doc_inv_carga_inicial](
					CargaInventarioId,	SucursalId,		ProductoId,		Cantidad,
					CostoPromedio,		UltimoCosto,		CreadoEl,	CreadoPor
				)
				select @cargainventarioId,@pSucursalId,	@productoId,	@pExistencias,
				0,					0,					getdate(),		@pCreadoPor

				IF @@ERROR <> 0
				BEGIN
					ROLLBACK TRAN
					GOTO FIN
				END
		End

		/***Insertar movimiento de inventario*****/
		declare @movimiento int,
			@folio int,
			@movimientoDetalle int

		select @movimiento = isnull(max(MovimientoId),0) + 1
		from [dbo].[doc_inv_movimiento]

		select @folio = isnull(max(Consecutivo),0) + 1
		from [dbo].[doc_inv_movimiento]
		where TipoMovimientoId = 1 --CargaInicial


		insert into [dbo].[doc_inv_movimiento](
			MovimientoId,	SucursalId,		FolioMovimiento,	TipoMovimientoId,
			FechaMovimiento,HoraMovimiento,	Comentarios,		ImporteTotal,
			Activo,			CreadoPor,		CreadoEl,			Autorizado,
			FechaAutoriza,	SucursalDestinoId,AutorizadoPor,	FechaCancelacion,
			ProductoCompraId,Consecutivo,	SucursalOrigenId,	VentaId,
			MovimientoRefId,Cancelado
		)
		select @movimiento,@pSucursalId,cast(@folio as varchar),	1,
		getdate(),			getdate(),		'Importación Productos Excel',isnull(@pPrecio,0)*isnull(@pExistencias,0),
		1,					@pCreadoPor,	getdate(),			1,
		getdate(),			null,			@pCreadoPor,		null,
		null,				@folio,			null,				null,
		null,				null


		IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRAN
			GOTO FIN
		END

		select @movimientoDetalle = isnull(max(MovimientoDetalleId),0) +1
		from [doc_inv_movimiento_detalle]

		insert into [dbo].[doc_inv_movimiento_detalle](
			MovimientoDetalleId,	MovimientoId,	ProductoId,		Consecutivo,
			Cantidad,				PrecioUnitario,	Importe,		Disponible,
			CreadoPor,				CreadoEl,		CostoUltimaCompra,CostoPromedio,
			ValCostoUltimaCompra,	ValCostoPromedio,ValorMovimiento
		)
		select @movimientoDetalle,	@movimiento,	@productoId,	1,
			isnull(@pExistencias,0),isnull(@pPrecio,0),isnull(@pPrecio,0)*isnull(@pExistencias,0),isnull(@pExistencias,0),
			@pCreadoPor,			GETDATE(),		0,			0,
			0,						0,				0
			
				
		IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRAN
			GOTO FIN
		END



		if @pIVA > 0
		begin
			declare @ProductoImpuestoId int

			select @ProductoImpuestoId = isnull(max(ProductoImpuestoId),0)+1
			from cat_productos_impuestos

			insert into cat_productos_impuestos(
				ProductoImpuestoId,ProductoId,ImpuestoId
			)
			select @ProductoImpuestoId,@productoId,1 --IVA
			
		end

		

		SET @pInsertado = 1

	end

	

	

	COMMIT TRAN

	FIN:


END




