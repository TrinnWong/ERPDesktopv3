if exists (
	select 1
	from sysobjects
	where name = 'p_doc_ventas_rec'
)
drop proc p_doc_ventas_rec
go


create proc p_doc_ventas_rec
@pSucursalId int,
@pError varchar(250)='' out
as

		declare @aplica_rec bit,
			@porc_rec decimal(5,2),
			@fechaInicioRec datetime,
			@ventaIni int,@ventaFin int,
			@totalMaxRec money,
			@folio_new varchar(5),
			@serie_new varchar(5),
			@totalVenta money


	

	create table #tmpVentasRec
	(
		VentaId int,
		Total money
	)

	select @aplica_rec = TieneRec,
		@porc_rec = PorcRec
	from cat_configuracion 
	

	if(
		isnull(@aplica_rec,0) = 1 and
		isnull(@porc_rec,0) > 0
	)
	begin

		
		BEGIN TRY	

			BEGIN TRANSACTION


			--Sincornizar info con temp
			exec p_doc_ventas_rec_sinc @pSucursalId,@pError out

			select @fechaInicioRec = isnull(max(FechaCorte),'19000101')
			from doc_corte_caja cc
			inner join  cat_cajas c on c.Clave = cc.CajaId
			where c.Sucursal = @pSucursalId

			select v.VentaId,v.TotalVenta, rec = cast(0 as bit),v.Activo,v.FechaCancelacion
			into #tmpVentasTot
			from doc_ventas v
			where SucursalId = @pSucursalId and
			v.FechaCreacion >= @fechaInicioRec and
			isnull(v.Rec,0) = 0

			select @totalVenta = sum(TotalVenta) 
			from #tmpVentasTot
			where activo = 1 and
			fechacancelacion is null

			select @porc_rec = PorcDeclarar
			from ERPTemp..cat_rec_configuracion_rangos
			where @totalVenta between RangoInicial and RangoFinal 
			

			select @totalMaxRec = sum(TotalVenta) * (isnull(@porc_rec,0) / 100)
			from #tmpVentasTot
			where activo = 1 and
			fechacancelacion is null


			select @ventaFin = max(VentaId)
			from #tmpVentasTot

			while @ventaFin is not null
			begin
				declare @total_i money,
					@totalVenta_i money

					
			
				if exists(
					select 1
					from doc_ventas v
					inner join doc_ventas_formas_pago vfp on vfp.VentaId = v.VentaId and
																vfp.FormaPagoId = 1 --EFECTIVO
					left join doc_ventas_formas_pago vfp2 on vfp2.VentaId = v.VentaId and
																vfp2.FormaPagoId <> 1
					where v.VentaId = @ventaFin and
					v.Activo = 1 and
					v.FechaCancelacion is null and
					isnull(v.Impuestos,0) > 0 and
					vfp2.VentaId is null
				)
				begin
					
					
					select @total_i = isnull(sum(tmp.Total),0) 
					from #tmpVentasRec tmp
				

					select @totalVenta_i = isnull(TotalVenta,0)
					from #tmpVentasTot tmp2 
					where tmp2.VentaId = @ventaFin

					if((@total_i + @totalVenta_i) < @totalMaxRec)
					begin

						insert into #tmpVentasRec
						select @ventaFin,@totalVenta_i
					end
				
				end


				select @ventaFin = max(VentaId)
				from #tmpVentasTot
				where VentaId < @ventaFin

				

			end

			
			--Desligar las ventas a recortar del inventario
			update doc_inv_movimiento
			set VentaId = null
			from doc_inv_movimiento m
			inner join #tmpVentasRec tmp on tmp.VentaId = m.VentaId

			--MArcar las ventas como rec
			update doc_ventas
			set rec=1
			where isnull(rec,0)= 0

			--BORRAR PEDIDOS
			delete doc_pedidos_orden_adicional
			from doc_pedidos_orden_adicional pa
			inner join doc_pedidos_orden_detalle pd on pd.PedidoDetalleId = pa.PedidoDetalleId
			inner join doc_pedidos_orden p on p.PedidoId = pd.PedidoId
			inner join #tmpVentasRec b on b.VentaId = p.VentaId

			delete doc_pedidos_orden_ingre
			from doc_pedidos_orden_ingre pi 
			inner join doc_pedidos_orden_detalle pd on pd.PedidoDetalleId = pi.PedidoDetalleId
			inner join doc_pedidos_orden p on p.PedidoId = pd.PedidoId
			inner join #tmpVentasRec b on b.VentaId = p.VentaId

			delete doc_pedidos_orden_mesa
			from doc_pedidos_orden_mesa pom 
			inner join doc_pedidos_orden p on p.PedidoId = pom.PedidoOrdenId
			inner join #tmpVentasRec b on b.VentaId = p.VentaId

			delete doc_pedidos_orden_mesero
			from doc_pedidos_orden_mesero pom 
			inner join doc_pedidos_orden p on p.PedidoId = pom.PedidoOrdenId
			inner join #tmpVentasRec b on b.VentaId = p.VentaId


			delete doc_pedidos_orden_detalle
			from doc_pedidos_orden_detalle a
			inner join doc_pedidos_orden p on p.PedidoId = a.PedidoId
			inner join #tmpVentasRec b on b.VentaId = p.VentaId

			delete doc_pedidos_orden
			from doc_pedidos_orden po
			inner join #tmpVentasRec b on b.VentaId = po.VentaId

			--BORRAR DOC_VEN
			delete [doc_ventas_temp]
			from [doc_ventas_temp] a
			inner join #tmpVentasRec b on b.VentaId = a.VentaId
			

			delete [doc_ventas_formas_pago_vale]
			from [doc_ventas_formas_pago_vale] a
			inner join #tmpVentasRec b on b.VentaId = a.VentaId
			
			

			delete [doc_ventas_formas_pago]
			from [doc_ventas_formas_pago]  a
			inner join #tmpVentasRec b on b.VentaId = a.VentaId
			
			
			
			delete [doc_ventas_detalle]
			from [doc_ventas_detalle] a
			inner join #tmpVentasRec b on b.VentaId = a.VentaId

			delete [doc_ventas]
			from [doc_ventas] a
			inner join #tmpVentasRec b on b.VentaId = a.VentaId

			
			select
				@folio_new = isnull(max(Folio),0)
			from doc_ventas v
			where ventaId < (
				select min(VentaId)
				from #tmpVentasTot
			)

					

			select tmp1.VentaId,
			Folio = ROW_NUMBER() OVER(ORDER BY tmp1.VentaId ASC) + cast(@folio_new as int)
			into #tmpVentasFolios
			from #tmpVentasTot tmp1
			inner join doc_ventas v on v.VentaId = tmp1.VentaId
			

			
			update doc_ventas
			set Folio = f.Folio
			from doc_ventas v
			inner join #tmpVentasTot tmp1 on tmp1.VentaId = v.VentaId
			inner join #tmpVentasFolios f on f.VentaId = v.VentaId

		
		--select sum(TotalVenta) from #tmpVentasTot
		--	select @totalMaxRec
		--	SELECT * FROM DOC_VENTAS
		--	SELECT * FROM ERPTemp..DOC_VENTAS
			

			COMMIT TRAN

		END TRY  
		BEGIN CATCH  
			set @pError = ERROR_MESSAGE()
		
			 ROLLBACK TRAN
			
		END CATCH;  

	end