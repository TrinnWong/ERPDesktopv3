


ALTER Proc [dbo].[p_inv_movimiento_detalle_ins]
@pMovimientoDetalleId	int out,
@pMovimientoId	int,
@pProductoId	int,
@pConsecutivo	smallint,
@pCantidad	decimal(14,3),
@pPrecioUnitario	money,
@pImporte	money,
@pDisponible	decimal(14,3),
@pCreadoPor	int,
@pCostoUltimaCompra money,
@pCostoPromedio money,
@pSubTotal money,
@pPrecioNeto money
as

	declare @ValCostoUltimaCompra money,
		   @ValCostoPromedio money

select @pMovimientoDetalleId = isnull(max(MovimientoDetalleId),0) + 1
from [doc_inv_movimiento_detalle]

select @pConsecutivo = isnull(max(Consecutivo),0)
from [doc_inv_movimiento_detalle]
where MovimientoId = @pMovimientoId

set @pImporte = @pCantidad * @pPrecioUnitario
set @ValCostoUltimaCompra = @pCantidad *@pCostoUltimaCompra
set @ValCostoPromedio = @pCantidad * @pCostoPromedio

INSERT INTO [dbo].[doc_inv_movimiento_detalle]
           ([MovimientoDetalleId]
           ,[MovimientoId]
           ,[ProductoId]
           ,[Consecutivo]
           ,[Cantidad]
           ,[PrecioUnitario]
           ,[Importe]
           ,[Disponible]
           ,[CreadoPor]
           ,[CreadoEl]
		   ,CostoUltimaCompra
			,CostoPromedio
			,ValCostoUltimaCompra
			,ValCostoPromedio
			,SubTotal
			,PrecioNeto)
     VALUES
           (@pMovimientoDetalleId,
           @pMovimientoId,
           @pProductoId, 
           @pConsecutivo, 
           @pCantidad, 
           @pPrecioUnitario, 
           @pImporte, 
           @pDisponible, 
           @pCreadoPor, 
           getdate() 
		   ,null
		   ,null
		   ,null
		   ,null
		   ,@pSubTotal
		   ,@pPrecioNeto)








