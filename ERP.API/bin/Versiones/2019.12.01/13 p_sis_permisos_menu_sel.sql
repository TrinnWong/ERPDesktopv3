if exists (
	select 1
	from sysobjects
	where name = 'p_sis_permisos_menu_sel'
)
drop proc p_sis_permisos_menu_sel
go
create proc p_sis_permisos_menu_sel
@pUsuarioId int,
@pSucursalId int
as

	select m.MenuId,m.Descripcion
	from sis_usuarios_roles ur
	inner join sis_roles_perfiles rp on rp.RolId = ur.RolId
	inner join sis_roles r on r.RolId = rp.RolId and r.Activo = 1
	inner join sis_perfiles_menu pm on pm.PerfilId = rp.PerfilId
	inner join sis_perfiles p on p.PerfilId = pm.PerfilId and p.Activo = 1
	inner join sis_menu m on m.MenuId = pm.MenuId and m.Activo = 1
	inner join cat_usuarios_sucursales us on us.UsuarioId = ur.UsuarioId
	where ur.UsuarioId = @pUsuarioId and
	us.SucursalId = @pSucursalId
	group by m.MenuId,m.Descripcion
