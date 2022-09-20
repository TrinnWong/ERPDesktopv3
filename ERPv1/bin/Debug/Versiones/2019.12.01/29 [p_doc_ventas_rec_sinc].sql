
-- p_doc_ventas_rec_sinc 1,''
alter proc [dbo].[p_doc_ventas_rec_sinc]
@pSucursalId int,
@pError varchar(250)='' out
as

--	ERPJalisco.dbo.doc_apartados: FK_apartados_ventas
--ERPJalisco.dbo.doc_corte_caja: FK_doc_corte_caja_doc_ventas
--ERPJalisco.dbo.doc_corte_caja: FK_doc_corte_caja_doc_ventas1
--ERPJalisco.dbo.doc_devoluciones: FK_doc_devoluciones_doc_ventas1
--ERPJalisco.dbo.doc_devoluciones_detalle: FK_doc_devoluciones_cat_productos
--ERPJalisco.dbo.doc_devoluciones_detalle: FK_doc_devoluciones_doc_ventas
--ERPJalisco.dbo.doc_inv_movimiento: FK__doc_inv_m__Venta__7226EDCC
--ERPJalisco.dbo.doc_inv_movimiento: FK__doc_inv_m__Venta__731B1205
--ERPJalisco.dbo.doc_pedidos_orden: FK_Pedidos_Ventas
--ERPJalisco.dbo.doc_reimpresion_ticket: FK_doc_reimpresion_ticket_doc_ventas
--ERPJalisco.dbo.doc_ventas_detalle: FK_doc_ventas_detalle_doc_ventas
--ERPJalisco.dbo.doc_ventas_formas_pago: FK_doc_ventas_formas_pago_doc_ventas
--ERPJalisco.dbo.doc_web_carrito: FK_Carrito_Ventas

	declare @aplica_rec bit,
		@devolucionId int,
		@devolucionDetalleId int,
		@pedidoOrdenId int,
		@pedidoOrdenDetalleId int,
		@pventaId int,
		@ventaDetalleId int,
		@ventaFPValeId int,
		@ComandaId int

	select @aplica_rec = TieneRec
	from cat_configuracion 

	
	--BEGIN TRAN
	BEGIN TRY  
		
		if(@aplica_rec = 1)
		begin

			delete cat_rec_configuracion_rangos

			insert into cat_rec_configuracion_rangos
			select Id,RangoInicial,RangoFinal,PorcDeclarar,CreadoEl
			from ERPTemp..cat_rec_configuracion_rangos

				insert into ERPTemp..cat_lineas(
			Clave,Descripcion,Estatus,Empresa,Sucursal
			)
			select Clave,Descripcion,Estatus,Empresa,Sucursal
			from cat_lineas a
			where not exists (
				select 1
				from ERPTemp..cat_lineas b
				where b.Clave = a.Clave
			)

		
			insert into ERPTemp..cat_familias(
			Clave,	Descripcion,		Estatus,	Empresa,
			Sucursal,ProductoPortadaId,	Orden
			)
			select Clave,	Descripcion,		Estatus,	Empresa,
			Sucursal,ProductoPortadaId,	Orden
			from cat_familias a
			where not exists (
				select 1
				from ERPTemp..cat_familias b
				where b.Clave = a.Clave
			)


			insert into ERPTemp..cat_subfamilias(
			Clave,Descripcion,Familia,Estatus,Empresa,Sucursal
			)
			select Clave,Descripcion,Familia,Estatus,Empresa,Sucursal
			from cat_subfamilias a
			where not exists (
				select 1
				from ERPTemp..cat_subfamilias b
				where b.Clave = a.Clave
			)

		

			--update doc_ventas
			--set rec = 1
			--from doc_ventas v
			--inner join doc_corte_caja_ventas cc on cc.VentaId = v.VentaId
			--where isnull(rec,0) = 0

			--Sincornizar productos
			insert into ERPTemp..cat_productos(
				ProductoId,		Clave,		Descripcion,	DescripcionCorta,		FechaAlta,		ClaveMarca,
				ClaveFamilia,	ClaveSubFamilia,ClaveLinea,	ClaveUnidadMedida,		ClaveInventariadoPor,ClaveVendidaPor,
				Estatus,		ProductoTerminado,Inventariable,MateriaPrima,		ProdParaVenta,	ProdVtaBascula,
				Seriado,		NumeroDecimales,PorcDescuentoEmpleado,ContenidoCaja,Empresa,		Sucursal,
				Foto,			ClaveAlmacen,ClaveAnden,	ClaveLote,				FechaCaducidad,	MinimoInventario,
				MaximoInventario,PorcUtilidad,Talla,		ParaSexo,				Color,			Color2,
				SobrePedido,	Especificaciones,			Liquidacion
			)
			select ProductoId,		Clave,		Descripcion,	DescripcionCorta,		FechaAlta,		ClaveMarca,
				ClaveFamilia,	ClaveSubFamilia,ClaveLinea,	ClaveUnidadMedida,		ClaveInventariadoPor,ClaveVendidaPor,
				Estatus,		ProductoTerminado,Inventariable,MateriaPrima,		ProdParaVenta,	ProdVtaBascula,
				Seriado,		NumeroDecimales,PorcDescuentoEmpleado,ContenidoCaja,Empresa,		Sucursal,
				Foto,			ClaveAlmacen,ClaveAnden,	ClaveLote,				FechaCaducidad,	MinimoInventario,
				MaximoInventario,PorcUtilidad,Talla,		ParaSexo,				Color,			Color2,
				SobrePedido,	Especificaciones,			Liquidacion
			from cat_productos a
			where not exists(
				select 1
				from ERPTemp..cat_productos b
				where b.ProductoId = a.ProductoId
			)
			

			select @pventaId = isnull(max(VentaId ),0)
			from ERPTemp..doc_ventas

			/***Crear relaci�n antes de sincronizar****/
			INSERT INTO doc_ventas_temp(
				VentaId,VentaTempId,CreadoEl
			)
			select v.VentaId, ROW_NUMBER() OVER(ORDER BY v.VentaId ASC) + @pventaId,GETDATE()
			from doc_ventas v
			where isnull(v.Rec,0) = 0
			order by v.VentaId asc

			

			--VENTAS
			insert into ERPTemp..doc_ventas(
				VentaId,		Folio,			Fecha,			ClienteId,		DescuentoVentaSiNo,			PorcDescuentoVenta,
				MontoDescuentoVenta,DescuentoEnPartidas,TotalDescuento,			Impuestos,					SubTotal,
				TotalVenta,TotalRecibido,		Cambio,			Activo,			UsuarioCreacionId,			FechaCreacion,
				UsuarioCancelacionId,FechaCancelacion,SucursalId,CajaId,		Serie,						MotivoCancelacion,
				Rec
			)
			select ROW_NUMBER() OVER(ORDER BY VentaId ASC) + @pventaId,Folio,			Fecha,			ClienteId,		DescuentoVentaSiNo,			PorcDescuentoVenta,
				MontoDescuentoVenta,DescuentoEnPartidas,TotalDescuento,			Impuestos,					SubTotal,
				TotalVenta,TotalRecibido,		Cambio,			Activo,			UsuarioCreacionId,			FechaCreacion,
				UsuarioCancelacionId,FechaCancelacion,SucursalId,CajaId,		Serie,						MotivoCancelacion,
				Rec
			from doc_ventas v
			where isnull(v.Rec,0) = 0

			--VENTAS DETALLE
			select @ventaDetalleId= isnull(max(VentaDetalleId ),0)
			from ERPTemp..doc_ventas_detalle

			insert into ERPTemp..doc_ventas_detalle(
				VentaDetalleId,		VentaId,		ProductoId,		Cantidad,		PrecioUnitario,
				PorcDescuneto,		Descuento,		Impuestos,		Total,			UsuarioCreacionId,
				FechaCreacion,		TasaIVA
			)
			select ROW_NUMBER() OVER(ORDER BY VentaDetalleId ASC)  + @ventaDetalleId,vtemp.VentaTempId,ProductoId,		Cantidad,		PrecioUnitario,
				PorcDescuneto,		Descuento,		Impuestos,		Total,			UsuarioCreacionId,
				FechaCreacion,		TasaIVA
			from doc_ventas_detalle vd 
			inner join doc_ventas_temp vtemp on vtemp.ventaId = vd.VentaId

			--VENTAS FORMAS DE PAGO
			INSERT INTO ERPTemp..[doc_ventas_formas_pago](
				FormaPagoId,VentaId,Cantidad,FechaCreacion,UsuarioCreacionId,digitoVerificador
			)
			SELECT FormaPagoId,vtemp.VentaTempId,Cantidad,FechaCreacion,UsuarioCreacionId,digitoVerificador
			FROM [doc_ventas_formas_pago] FP
			inner join doc_ventas_temp vtemp on vtemp.ventaId = FP.VentaId
			where not exists (
				select 1
				from  ERPTemp..[doc_ventas_formas_pago] st
				where st.FormaPagoId = FP.FormaPagoId and
				VentaId = vtemp.VentaTempId
			)
			

			--VENTAS FORMAS PAGO VALE

			select @ventaFPValeId = isnull(max(Id),0)
			from ERPTemp..[doc_ventas_formas_pago_vale]

			INSERT INTO ERPTemp..[doc_ventas_formas_pago_vale](
				Id,VentaId,TipoValeId,Monto,DevolucionId,CreadoEl
			)
			select ROW_NUMBER() OVER(ORDER BY Id ASC) + @ventaFPValeId,VentaTempId,TipoValeId,Monto,DevolucionId,A.CreadoEl
			from [doc_ventas_formas_pago_vale] a
			inner join doc_ventas_temp vtemp on vtemp.ventaId = a.VentaId


			--DEVOLUCIONES
			select @devolucionId = isnull(max(devolucionId),0)
			from ERPTemp..doc_devoluciones


			insert into ERPTemp..doc_devoluciones(
				DevolucionId,	VentaId,			Total,	CreadoEl,
				CreadoPor,		TipoDevolucionId,	FechaVencimiento
			)
			select DevolucionId + @devolucionId,	dev.VentaId,			Total,	CreadoEl,
				CreadoPor,		TipoDevolucionId,	FechaVencimiento
			from doc_devoluciones dev
			inner join doc_ventas  v on v.VentaId = dev.VentaId
			where isnull(v.Rec,0) = 0
			order by DevolucionId

			--Sincornizar Devoluciones Detalle
			select @devolucionDetalleId = isnull(max(DevolucionDetId),0)
			from ERPTemp..doc_devoluciones_Detalle


			insert into ERPTemp..doc_devoluciones_Detalle(DevolucionDetId,DevolucionId,VentaId,ProductoId,Cantidad,
			Total,CreadoEl,CreadoPor)
			select ROW_NUMBER() OVER(ORDER BY DevolucionDetId ASC) + @devolucionDetalleId,dev.DevolucionId + @devolucionId,dev.VentaId,
			dd.ProductoId,dd.Cantidad,dd.Total,GETDATE(),dd.CreadoPor
			from doc_devoluciones dev
			inner join doc_ventas  v on v.VentaId = dev.VentaId
			inner join doc_devoluciones_detalle dd on dd.DevolucionId = dev.DevolucionId
			where isnull(v.Rec,0) = 0
			order by DevolucionDetId asc

			insert into ERPTemp..cat_rest_mesas(
				MesaId,SucursalId,Nombre,Descripcion,Activo,CreadoEl,
				CreadoPor,ModificadoEl,ModificadoPor
			)
			select MesaId,SucursalId,Nombre,Descripcion,Activo,CreadoEl,
				CreadoPor,ModificadoEl,ModificadoPor
			from cat_rest_mesas a
			where not exists (
				select 1
				from ERPTemp..cat_rest_mesas b
				where  a.MesaId = b.MesaId
			)

			insert into ERPTemp..cat_rest_comandas(
				ComandaId,SucursalId,Folio,Disponible,CreadoPor,CreadoEl
			)
			select ComandaId,SucursalId,Folio,Disponible,CreadoPor,CreadoEl
			from cat_rest_comandas a
			where not exists (
				select 1
				from ERPTemp..cat_rest_comandas b
				where a.ComandaId = b.ComandaId
			)


			--SINCRONIZAR 
			select @pedidoOrdenId = isnull(max(PedidoId),0)
			from ERPTemp..doc_pedidos_orden

			insert into  ERPTemp..doc_pedidos_orden(
				PedidoId,SucursalId,ComandaId,PorcDescuento,Subtotal,Descuento,Impuestos,Total,
				ClienteId,MotivoCancelacion,Activo,CreadoEl,CreadoPor,Personas,FechaApertura,FechaCierre,
				VentaId,Cancelada,FechaCancelacion,CanceladoPor
			)
			select dev.PedidoId + @pedidoOrdenId,dev.SucursalId,dev.ComandaId,dev.PorcDescuento,dev.Subtotal,dev.Descuento,
			dev.Impuestos,dev.Total,dev.ClienteId,dev.MotivoCancelacion,dev.Activo,dev.CreadoEl,
			dev.CreadoPor,dev.Personas,dev.FechaApertura,dev.FechaCierre,dev.VentaId,dev.Cancelada,
			dev.FechaCancelacion,dev.CanceladoPor
			from doc_pedidos_orden dev
			inner join doc_ventas v on v.VentaId = dev.VentaId
			where isnull(v.Rec,0) = 0
			order by dev.PedidoId asc

			select @pedidoOrdenDetalleId = isnull(max(PedidoDetalleId),0)
			from ERPTemp..doc_pedidos_orden_detalle


			insert into  ERPTemp..doc_pedidos_orden_detalle(
				PedidoDetalleId,PedidoId,ProductoId,Cantidad,PrecioUnitario,
				PorcDescuento,Descuento,Impuestos,Notas,Total,
				CreadoPor,CreadoEl,TasaIVA,Impreso,ComandaId,
				Parallevar,Cancelado
			)
			select ROW_NUMBER() OVER(ORDER BY PedidoDetalleId ASC) + @pedidoOrdenDetalleId,dev.PedidoId + @pedidoOrdenId,pod.ProductoId,pod.Cantidad,
				pod.PrecioUnitario,	pod.PorcDescuento,pod.Descuento,pod.Impuestos,pod.Notas,pod.Total,
				pod.CreadoPor,pod.CreadoEl,pod.TasaIVA,pod.Impreso,pod.ComandaId,
				Parallevar,Cancelado
			from doc_pedidos_orden dev
			inner join doc_ventas v on v.VentaId = dev.VentaId
			inner join doc_pedidos_orden_detalle pod on pod.PedidoId = dev.PedidoId
			where isnull(v.Rec,0) = 0
			order by dev.PedidoId asc

			insert into ERPTemp..[doc_pedidos_orden_mesa](
				PedidoOrdenId,MesaId,CreadoEl
			)
			select pm.PedidoOrdenId +  @pedidoOrdenId,pm.MesaId,pm.CreadoEl
			from [doc_pedidos_orden_mesa] pm
			inner join doc_pedidos_orden dev on dev.PedidoId = pm.PedidoOrdenId
			inner join doc_ventas v on v.VentaId = dev.VentaId
			where isnull(v.Rec,0) = 0
			order by dev.PedidoId asc


			insert into ERPTemp..[doc_pedidos_orden_mesero](
				PedidoOrdenId,EmpleadoId,CreadoEl
			)
			select pom.PedidoOrdenId + @pedidoOrdenId,pom.EmpleadoId,pom.CreadoEl
			from [doc_pedidos_orden_mesero] pom 
			inner join doc_pedidos_orden dev on dev.PedidoId = pom.PedidoOrdenId
			inner join doc_ventas v on v.VentaId = dev.VentaId
			where isnull(v.Rec,0) = 0
			order by dev.PedidoId asc


			

		end

		--ROLLBACK TRAN
	END TRY  
	BEGIN CATCH  
		--ROLLBACK TRAN
		set @pError = 'Ocurrió un error al sincronizar tablas' + ERROR_MESSAGE()
	END CATCH;  

