

ALTER Proc [dbo].[p_doc_inv_movimiento_upd]
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
@pAutorizadoPor	int  ,
@pTipoMermaId int       
as

update [doc_inv_movimiento]
set
           [SucursalId] = @pSucursalId                                            
           ,[Comentarios]=@pComentarios
           ,[ImporteTotal]=@pImporteTotal
           ,[Activo]=1		   		
		   ,SucursalDestinoId = @pSucursalDestinoId	
		   ,SucursalOrigenId = @pSucursalOrigenId
		   ,TipoMermaId = @pTipoMermaId
where MovimientoId = @pMovimientoId







