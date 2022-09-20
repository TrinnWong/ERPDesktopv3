if not exists (
	select 1
	from sis_menu
	where MenuWinBarNameId in (
	'frmConfigurador',
	'ConfigInicial',
	'frmUsuariosRoles'
	)
)
BEGIN
	
declare @id int

select @id = isnull(max(MenuId),0)+1
from sis_menu


insert into sis_menu(
	MenuId,Titulo,Descripcion,Tipo,MenuWinBarNameId,MenuPadreId,Activo
)
select @id,'Configurador','Configurador',1,'frmConfigurador',null,1

set @id = @id +1

insert into sis_menu(
	MenuId,Titulo,Descripcion,Tipo,MenuWinBarNameId,MenuPadreId,Activo
)
select @id,'Configuración Inicial','Configuración Inicial',1,'ConfigInicial',null,1


set @id = @id +1

insert into sis_menu(
	MenuId,Titulo,Descripcion,Tipo,MenuWinBarNameId,MenuPadreId,Activo
)
select @id,'Usuarios y Roles','Usuarios y Roles',1,'frmUsuariosRoles',null,1


END