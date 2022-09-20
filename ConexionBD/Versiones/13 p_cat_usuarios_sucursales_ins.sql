if exists (
	select 1
	from sysobjects
	where name = 'p_cat_usuarios_sucursales_ins'
)
drop proc p_cat_usuarios_sucursales_ins
go

create proc p_cat_usuarios_sucursales_ins
@pUsuarioId int,
@pSucursalId int
as

	insert into cat_usuarios_sucursales(
		UsuarioId,SucursalId,CreadoEl
	)
	select @pUsuarioId,@pSucursalId,getdate()