ALTER Proc [dbo].[p_doc_inv_movimiento_ins]
@pMovimientoId int out,
@pSucursalId int,
@pFolioMovimiento varchar(10),
@pTipoMovimientoId int,
@pFechaMovimiento datetime,
@pHoraMovimiento time(7),
@pComentarios varchar(250),
@pImporteTotal money,
@pCreadoPor int,
@pAutorizado	bit,
@pFechaAutoriza	datetime,
@pSucursalOrigenId	int,
@pSucursalDestinoId	int,
@pAutorizadoPor	int,
@pTipoMermaId int
as

	declare @consecutivo int

	select @pMovimientoId = isnull(max(MovimientoId),0) + 1
	from [doc_inv_movimiento]

	select @consecutivo = isnull(max(consecutivo),0)  + 1
	from [doc_inv_movimiento]
	where [TipoMovimientoId] = @pTipoMovimientoId
	and [SucursalId] = @pSucursalId

	set @pFolioMovimiento = cast(@consecutivo as varchar(20))



	INSERT INTO [dbo].[doc_inv_movimiento]
           ([MovimientoId]
           ,[SucursalId]
           ,[FolioMovimiento]
           ,[TipoMovimientoId]
           ,[FechaMovimiento]
           ,[HoraMovimiento]
           ,[Comentarios]
           ,[ImporteTotal]
           ,[Activo]
           ,[CreadoPor]
           ,[CreadoEl],
		   Autorizado,
		FechaAutoriza,
		SucursalDestinoId,
		AutorizadoPor,
		Consecutivo,
		SucursalOrigenId,
		TipoMermaId)
     VALUES
           (@pMovimientoId, 
           @pSucursalId,
           @pFolioMovimiento, 
           @pTipoMovimientoId,
           @pFechaMovimiento,
           @pHoraMovimiento,
           @pComentarios, 
           @pImporteTotal, 
           1,
           @pCreadoPor,
           getdate(),
		   @pAutorizado,
			@pFechaAutoriza,
			@pSucursalDestinoId,
			@pAutorizadoPor,
			@consecutivo,
			@pSucursalOrigenId,
			@pTipoMermaId
		   )







