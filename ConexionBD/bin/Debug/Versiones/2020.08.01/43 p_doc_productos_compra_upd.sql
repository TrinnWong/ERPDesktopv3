

alter PROC [dbo].[p_doc_productos_compra_upd]
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
	declare @fletePonderacion float,
		@comisionPonderacion float
	begin tran

	UPDATE doc_productos_compra
	SET 	
	ProveedorId = @pProveedorId,		
	NumeroRemision = @pNumeroRemision,		
	Descuento = @pDescuento,		
	Subtotal = @pSubtotal,	
	Impuestos = @pImpuestos,		
	Total = @pTotal,		
	ModificadoPor = @pCreadoPor,
	ModificadoEl = getdate(),		
	FechaRemision = @pFechaRemision,
	SucursalId = @pSucursalId
	WHERE ProductoCompraId = @pProductoCompraId

	

	if(@pFlete = 0)
	begin 
		delete doc_productos_compra_cargos
		where ProductoCompraId = @pProductoCompraId and
		ProductoId = -2--Flete
	end
	else
	begin

		if not exists (
			select 1
			from doc_productos_compra_cargos
			where ProductoCompraId = @pProductoCompraId and
			ProductoId = -2--Fletes
		)
		begin
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
		end
		else
			begin
				/***Fletes***/
				update doc_productos_compra_cargos
				set Remision = @pFleteRemision,
					 Fecha = @pFleteFecha,
					 ProveedorId = @pFleteProveedorId,
					 Total = @pFleteTotal
				where ProductoCompraId = @pProductoCompraId and
				ProductoId = -2--Fletes
			end
		
		
			
		
		
	end
	if(@pComision = 0)
	begin 
		delete doc_productos_compra_cargos
		where ProductoCompraId = @pProductoCompraId and
		ProductoId = -3--Comisiones
	end
	else
	begin

			if not exists (
			select 1
			from doc_productos_compra_cargos
			where ProductoCompraId = @pProductoCompraId and
			ProductoId = -3--Comisiones
			)
			begin

				insert into doc_productos_compra_cargos(ProductoCompraId,
					ProductoId,
					Remision,
					Fecha,
					ProveedorId,
					Total,
					CreadoPor)
				select @pProductoCompraId,-3/*Comisiones*/,@pComisionRemision,@pComisionFecha,
				@pComisionProveedorId,@pComisionTotal,@pCreadoPor
			end
			else
			begin
				/***Comisiones***/
				update doc_productos_compra_cargos
				set Remision = @pComisionRemision,
					 Fecha = @pComisionFecha,
					 ProveedorId = @pComisionProveedorId,
					 Total = @pComisionTotal
				where ProductoCompraId = @pProductoCompraId and
				ProductoId = -3--Comisiones
			end

	end

	
	

	commit tran

	end try
	begin catch
		rollback tran
		set @pError =ERROR_MESSAGE()
	end catch





