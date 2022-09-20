alter PROC [dbo].[p_doc_productos_compra_ins]
@pProductoCompraId	int out,
@pProveedorId	int,
@pSucursalId int,
@pFechaRegistro	datetime,
@pNumeroRemision	varchar(50),
@pFechaRemision datetime,
@pDescuento	money,
@pSubtotal	money,
@pImpuestos	money,
@pTotal	MONEY,
@pCreadoPor	int,
@pPrecioConImpuestos bit,
@pFlete bit,
@pFleteFecha DateTime,
@pFleteRemision varchar(20),
@pFleteTotal money,
@pFleteProveedorId int,
@pComision bit,
@pComisionFecha DateTime,
@pComisionRemision varchar(20),
@pComisionTotal money,
@pComisionProveedorId int,
@pError varchar(250) out
AS

	begin try

	begin tran

	declare @fletePonderacion float,
		@comisionPonderacion float


	SELECT @pProductoCompraId = ISNULL(MAX(ProductoCompraId),0)+1
	FROM doc_productos_compra

	INSERT INTO doc_productos_compra(ProductoCompraId,	ProveedorId,	FechaRegistro,	NumeroRemision,		
	Descuento,		Subtotal,	Impuestos,		Total,	CreadoPor,	CreadoEl,	ModificadoPor,
	ModificadoEl,	Activo,		FechaRemision,	PrecioConImpuestos,	SucursalId)		
	VALUES(
		@pProductoCompraId,		@pProveedorId,		getdate(),		@pNumeroRemision,		
	@pDescuento,		@pSubtotal,		@pImpuestos,		@pTotal,	@pCreadoPor,	GETDATE(),	null,
	null,			1,			@pFechaRemision,@pPrecioConImpuestos,@pSucursalId
	)


	/****Fletes****/
	insert into doc_productos_compra_cargos(ProductoCompraId,
		ProductoId,
		Remision,
		Fecha,
		ProveedorId,
		Total,
		CreadoPor)
	select @pProductoCompraId,-2/*Fletes*/,@pFleteRemision,@pFleteFecha,
	@pFleteProveedorId,@pFleteTotal,@pCreadoPor

	/****Comisiones***/
	insert into doc_productos_compra_cargos(ProductoCompraId,
		ProductoId,
		Remision,
		Fecha,
		ProveedorId,
		Total,
		CreadoPor)
	select @pProductoCompraId,-3/*Comisiones*/,@pComisionRemision,@pComisionFecha,
	@pComisionProveedorId,@pComisionTotal,@pCreadoPor

	select @fletePonderacion = @pFleteTotal / sum(Cantidad),
		@comisionPonderacion = @pComisionTotal /sum(Cantidad)
	from doc_productos_compra_detalle
	where ProductoCompraId = @pProductoCompraId

	UPDATE doc_productos_compra_detalle
	SET Flete = isnull(@fletePonderacion,0) * Cantidad,
	Comisiones = isnull(@comisionPonderacion,0) * Cantidad
	where ProductoCompraId = @pProductoCompraId

	commit tran
	end try
	begin catch
		rollback tran
		set @pError=error_message()

	end catch



