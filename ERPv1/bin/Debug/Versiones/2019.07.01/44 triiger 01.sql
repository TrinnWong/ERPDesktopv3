if exists (
	select 1
	from sysobjects
	where name = 'tr_doc_inv_movimiento_upd'
)
drop trigger tr_doc_inv_movimiento_upd
go
CREATE TRIGGER [dbo].[tr_doc_inv_movimiento_upd] ON  [dbo].[doc_inv_movimiento]
AFTER UPDATE
AS

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

	if exists (
		select 1
		from inserted
		where FechaCancelacion is not null
	)
	begin
	
		exec p_inv_genera_mov_cancel @movimientoId
	end 
	Else
	Begin

	
			insert into #tmpProdExs(SucursalId,ProductoId,Activo,Autorizado,MovimientoDetalleId)
			select m.SucursalId,md.ProductoId,m.Activo,m.Autorizado,md.MovimientoDetalleId
			from inserted m
			inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId
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

	END






	go








