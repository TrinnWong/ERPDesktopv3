if exists (
	select 1
	from sysobjects
	where name = 'tr_doc_inv_movimiento_detalle_ins'
)
drop trigger tr_doc_inv_movimiento_detalle_ins
go

CREATE TRIGGER [dbo].[tr_doc_inv_movimiento_detalle_ins] ON  [dbo].[doc_inv_movimiento_detalle]
AFTER INSERT
AS
	--declare @productoId int,
	--		@sucursalId int,
	--		@movimientoDetalleId int

	--select @productoId = i.ProductoId,
	--	@sucursalId = m.SucursalId,
	--	@movimientoDetalleId = isnull(i.MovimientoDetalleId,0)
	--from inserted i
	--inner join doc_inv_movimiento m on m.MovimientoId = i.MovimientoId
	
	--exec p_calcular_existencias @sucursalId,@productoId,@movimientoDetalleId



	DECLARE @I INT
	declare @productoId int,
			@sucursalId int,
			@activo bit,
			@autorizado bit,
			@movimientoDetalleId int,
			@movimientoId int

	Create Table #tmpProdExs	
	(
		i int identity(1,1),
		MovimientoDetalleId int,
		SucursalId int,
		ProductoId int,
		Activo bit,
		Autorizado bit
	)

	select @movimientoId = MovimientoId
	from inserted

	

	
			insert into #tmpProdExs(SucursalId,ProductoId,Activo,Autorizado,MovimientoDetalleId)
			select m.SucursalId,md.ProductoId,m.Activo,m.Autorizado,md.MovimientoDetalleId
			from doc_inv_movimiento m
			inner join inserted md on md.MovimientoId = m.MovimientoId
			group by m.SucursalId,md.ProductoId,m.Activo,m.Autorizado,md.MovimientoDetalleId

			SELECT @I = MIN(I)
			FROM #tmpProdExs

			WHILE @I IS NOT NULL
			BEGIN


				SELECT @productoId = ProductoId,
					@sucursalId = SucursalId,
					@activo = Activo,
					@autorizado = Autorizado,
					@movimientoDetalleId = MovimientoDetalleId
				FROM #tmpProdExs
				WHERE I = @I	

		
					exec p_calcular_existencias @sucursalId,@productoId,@movimientoDetalleId
		

				SELECT @I = MIN(I)
				FROM #tmpProdExs
				WHERE I> @I

			END

	

GO

















