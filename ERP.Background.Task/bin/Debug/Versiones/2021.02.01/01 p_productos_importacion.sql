alter Proc [dbo].[p_productos_importacion]
@pEmpresa int,
@pSucursalId int,
@pLinea varchar(100),
@pFamilia varchar(100),
@pClaveProducto varchar(50),
@pDescripcionCorta varchar(250),
@pDescripcionLarga varchar(500),
@pPrecio money,
@pExistencias decimal(6,2),
@pCostoPromedio float,
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
@pCreadoPor int,
@uuid uniqueidentifier,
@pMateriaPrima bit,
@pProdParaVenta bit,
@pUnidadLicencia varchar(1),
@pCantidadLlicencia smallint,
@pVersion varchar(20),
@pCostoUltimaCompra float,
@pProductoActivo bit,
@pProductoTerminado bit,
@pProductoInventariable bit,
@pProductoBascula bit,
@pProductoSeriado bit,
@pUnidadInventario varchar(100),
@pUnidadVenta varchar(100),
@pMinimoInventario float,
@pMaximoInventario float,
@pCantidadProductoCaja float,
@pCodigoBarras varchar(25),
@pError varchar(250) out
as
BEGIN

	declare @familiaId int,
			@lineaId int,
			@subfamiliaId int,
			@productoId int,
			@marcaId int,
			@unidadId int,
			 @movimiento int,
			@folio int,
			@movimientoDetalle int,
			@unidadInventario int,
			@unidadVenta int

	SET @pError = ''
	BEGIN TRY

	BEGIN TRAN

	/*COSTO PROMEDIO Y PRECIO ULT COMPRA SOLO SE ACTUALIZARÁN PARA MATRIZ*/
	if(@pSucursalId <> 1)
	BEGIN
		SET @pCostoPromedio = 0
		SET @pCostoUltimaCompra = 0
	END

	if(isnull(@pCodigoBarras,'') = '')
	BEGIN
		SET @pCodigoBarras = @pClaveProducto
	END

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

	SELECT @unidadInventario = Clave
	from cat_unidadesmed
	where upper(RTRIM(Descripcion)) = upper(RTRIM(@pUnidadInventario))

	SELECT @unidadVenta = Clave
	from cat_unidadesmed
	where upper(RTRIM(Descripcion)) = upper(RTRIM(@pUnidadVenta))
	
	

	if(
		isnull(@lineaId,0) = 0
	)
	begin 
		select @lineaId = isnull(max(Clave),0) +1
		from cat_lineas

		insert into cat_lineas(Empresa,Sucursal,Clave,Descripcion,Estatus)
		select @pEmpresa,@pSucursalId, @lineaId,@pLinea,1
	end

	

	if(
		isnull(@familiaId,0) = 0
	)
	begin 
		select @familiaId = isnull(max(Clave),0) +1
		from cat_familias

		insert into cat_familias(Empresa,Sucursal,Clave,Descripcion,Estatus)
		select @pEmpresa,@pSucursalId,@familiaId,@pFamilia,1
	end


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

	


	if(
		isnull(@marcaId,0) = 0
	)
	begin 
		select @marcaId = isnull(max(Clave),0) +1
		from cat_marcas

		insert into cat_marcas(Clave,Descripcion,Estatus,Empresa,Sucursal)
		select @marcaId,@pMarca,1,1,1
	end

	

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

	if(
		isnull(@unidadInventario,0) = 0
	)
	begin 
		select @unidadInventario = isnull(max(Clave),0) +1
		from cat_unidadesmed

		insert into cat_unidadesmed(
			Clave,		Descripcion,	DescripcionCorta,Decimales,
			Estatus,	Empresa,		Sucursal,		IdCodigoSAT
		)
		select @unidadInventario,@pUnidadInventario,@pUnidadInventario,0,
		1,@pEmpresa,1,null
	end

	
	if(
		isnull(@unidadVenta,0) = 0
	)
	begin 
		select @unidadVenta = isnull(max(Clave),0) +1
		from cat_unidadesmed

		insert into cat_unidadesmed(
			Clave,		Descripcion,	DescripcionCorta,Decimales,
			Estatus,	Empresa,		Sucursal,		IdCodigoSAT
		)
		select @unidadVenta,@pUnidadVenta,@pUnidadVenta,0,
		1,@pEmpresa,1,null
	end

	

	
	--Si el producto no existe
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
			SobrePedido,	ClaveUnidadMedida,ClaveInventariadoPor,ClaveVendidaPor,
			Version,		MaximoInventario, MinimoInventario, CodigoBarras
			)
		select 
			@pEmpresa,@pSucursalId,
			@productoId,@lineaId,@familiaId,@pDescripcionLarga,
			@pDescripcionCorta,@pProductoActivo,@pClaveProducto,				0,
			0,				@pCantidadProductoCaja,				isnull(@pProductoTerminado,0),					isnull(@pProductoInventariable,0),
			@pMateriaPrima,	@pProdParaVenta,@pProductoBascula,					@pProductoSeriado,
			GETDATE(),		@marcaId,		@subfamiliaId,
			@pTalla,		@pParaSexo,		@pColor,			@pColor2,
			@pSobrePedido,	@unidadId,		@unidadInventario, @unidadVenta,
			@pVersion,		@pMaximoInventario,	@pMinimoInventario,@pCodigoBarras

		if isnull(@pUnidadLicencia ,'')<> ''
		begin

			insert into cat_productos_licencias(ProductoId,TiempoLicencia,UnidadLicencia,CreadoEl)
			select @productoId,@pCantidadLlicencia,@pUnidadLicencia,getdate()
		end
		

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

		

		insert into cat_productos_existencias(
			ProductoId,		SucursalId,		ExistenciaTeorica,		CostoUltimaCompra,
			CostoPromedio,	ValCostoUltimaCompra,ValCostoPromedio,	ModificadoEl,
			CreadoEl,		CostoPromedioInicial
		)
		select @productoId,@pSucursalId,isnull(@pExistencias,0),isnull(@pCostoUltimaCompra,0),
		isnull(@pCostoPromedio,0),0,0,getdate(),
		getdate(),			isnull(@pCostoPromedio,0)		
		
		
		

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
				isnull(@pCostoPromedio,0),		isnull(@pCostoUltimaCompra,0),			getdate(),		@pCreadoPor

		
				/***Insertar movimiento de inventario*****/
		
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
				getdate(),			getdate(),		'Importaci�n Productos Excel',isnull(@pPrecio,0)*isnull(@pExistencias,0),
				1,					@pCreadoPor,	getdate(),			1,
				getdate(),			null,			@pCreadoPor,		null,
				null,				@folio,			null,				null,
				null,				null



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
					@pCreadoPor,			GETDATE(),		isnull(@pCostoUltimaCompra,0),isnull(@pCostoPromedio,0),
					isnull(@pCostoUltimaCompra,0) * @pExistencias,isnull(@pCostoPromedio,0) * @pExistencias,				isnull(@pCostoPromedio,0) * @pExistencias
			
		
				
		End

		



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

		
		--Guardar Bitacora
		insert into doc_productos_importacion_bitacora(
			UUID,		ProductoId,		TipoMovimientoInventarioId,		Cantidad,
			CreadoEl,	CreadoPor
		)
		select @uuid,	@productoId,	1,								@pExistencias,
		GETDATE(),		@pCreadoPor


		SET @pInsertado = 1

	end
	--si el producto no existe
	else
	begin

		/*Generar el movimiento de inventario solo si tiene existencias en 0 para la sucursal*/
		if not exists (
			select 1 
			from cat_productos_existencias
			where ProductoId = @productoId and
			SucursalId = @pSucursalId and
			isnull(ExistenciaTeorica,0) > 0
		)
		AND @productoId > 0
		BEGIN
			--generar entrada directa
			/***Insertar movimiento de inventario*****/
		
			select @movimiento = isnull(max(MovimientoId),0) + 1
			from [dbo].[doc_inv_movimiento]

			select @folio = isnull(max(Consecutivo),0) + 1
			from [dbo].[doc_inv_movimiento]
			where TipoMovimientoId = 7 --Entrada Directa


			insert into [dbo].[doc_inv_movimiento](
				MovimientoId,	SucursalId,		FolioMovimiento,	TipoMovimientoId,
				FechaMovimiento,HoraMovimiento,	Comentarios,		ImporteTotal,
				Activo,			CreadoPor,		CreadoEl,			Autorizado,
				FechaAutoriza,	SucursalDestinoId,AutorizadoPor,	FechaCancelacion,
				ProductoCompraId,Consecutivo,	SucursalOrigenId,	VentaId,
				MovimientoRefId,Cancelado
			)
			select @movimiento,@pSucursalId,cast(@folio as varchar),	7,
			getdate(),			getdate(),		'Importación Productos Excel',isnull(@pPrecio,0)*isnull(@pExistencias,0),
			1,					@pCreadoPor,	getdate(),			1,
			getdate(),			null,			@pCreadoPor,		null,
			null,				@folio,			null,				null,
			null,				null

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
				@pCreadoPor,			GETDATE(),		isnull(@pCostoUltimaCompra,0),			isnull(@pCostoPromedio,0),
				isnull(@pCostoUltimaCompra,0) * isnull(@pExistencias,0),						0,				0
			
		END	
		--Guardar Bitacora
		insert into doc_productos_importacion_bitacora(
			UUID,		ProductoId,		TipoMovimientoInventarioId,		Cantidad,
			CreadoEl,	CreadoPor
		)
		select @uuid,	@productoId,	7,								@pExistencias,
		GETDATE(),		@pCreadoPor


	end

	COMMIT TRAN
	
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SET @pError = ERROR_MESSAGE()
	END CATCH


END











