
ALTER PROC [dbo].[p_InsertarVenta]
@pVentaId	BIGINT out,
@pFolio	varchar(20),
@pFecha	datetime,
@pClienteId	int,
@pDescuentoVentaSiNo	bit,
@pPorcDescuentoVenta	decimal(5,2),
@pMontoDescuentoVenta	money,
@pDescuentoEnPartidas	money,
@pTotalDescuento	money,
@pImpuestos	money,
@pSubTotal	money,
@pTotalVenta	money,
@pTotalRecibido MONEY,
@pCambio MONEY,
@pActivo	bit,
@pUsuarioCreacionId	int,
@pFechaCreacion	datetime,
@pUsuarioCancelacionId	int,
@pFechaCancelacion	datetime,
@pSucursalId int,
@pCajaId int,
@pPedidoId int,
@pFacturar BIT,
@pEmpleadoId INT=NULL
AS

 SET NOCOUNT ON;
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

	declare @serie varchar(5) = ''

	select @serie = isnull(Serie,'')
	from [dbo].[cat_configuracion_ticket_venta]
	where sucursalId = @pSucursalId


	

	select @pFolio = isnull(max(CAST(Folio AS int)),0) + 1
	from doc_ventas 
	where Serie = @serie

	
	SELECT @pVentaId = ISNULL(MAX(VentaId),0) + 1
	FROM [doc_ventas]
		

		INSERT INTO [dbo].[doc_ventas](
			VentaId,
			Folio,
			Fecha,
			ClienteId,
			DescuentoVentaSiNo,
			PorcDescuentoVenta,
			MontoDescuentoVenta,
			DescuentoEnPartidas,
			TotalDescuento,
			Impuestos,
			SubTotal,
			TotalVenta,
			TotalRecibido,
			Cambio,
			Activo,
			UsuarioCreacionId,
			FechaCreacion,
			UsuarioCancelacionId,
			FechaCancelacion,
			SucursalId,
			CajaId,
			Serie,
			Facturar,
			EmpleadoId
		)
		VALUES( @pVentaId,
			@pFolio,
			dbo.fn_GetDateTimeServer(),
			@pClienteId,
			@pDescuentoVentaSiNo,
			@pPorcDescuentoVenta,
			@pMontoDescuentoVenta,
			@pDescuentoEnPartidas,
			@pTotalDescuento,
			@pImpuestos,
			@pSubTotal,
			@pTotalVenta,
			@pTotalRecibido,
			@pCambio,
			@pActivo,
			@pUsuarioCreacionId,
			dbo.fn_GetDateTimeServer(),
			@pUsuarioCancelacionId,
			@pFechaCancelacion,
			@pSucursalId,
			@pCajaId,
			@serie,
			@pFacturar,
			@pEmpleadoId
			)



			update doc_pedidos_orden
			set VentaId = @pVentaId,
				Activo = 0
			where PedidoId = @pPedidoId






