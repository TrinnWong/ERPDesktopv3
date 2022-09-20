if not exists (
	select 1
	from sis_menu
	where MenuWinBarNameId in (
	'frmAltaPersonal',
	'frmUsuarios',
	'CargaInicialUpd',
	'frmProductosCompra',
	'frmEntradaTraspasoList',
	'frmEntradaDirectaList',
	'frmAjusteEntradaList',
	'frmSalidaTraspasoList',
	'frmAjusteSalidaList',
	'frmMaximosMinimos'
	)
)
BEGIN


declare @id int

select @id = isnull(max(MenuId),0)+1
from sis_menu

--Alta Personal
insert into sis_menu(
	MenuId,Titulo,Descripcion,Tipo,MenuWinBarNameId,MenuPadreId,Activo
)
select @id,'Alta Personal','Alta Personal',1,'frmAltaPersonal',null,1

set @id = @id +1

insert into sis_menu(
	MenuId,Titulo,Descripcion,Tipo,MenuWinBarNameId,MenuPadreId,Activo
)
select @id,'Usuarios del Sistema','Usuarios del Sistema',1,'frmUsuarios',null,1


set @id = @id +1

insert into sis_menu(
	MenuId,Titulo,Descripcion,Tipo,MenuWinBarNameId,MenuPadreId,Activo
)
select @id,'Carga Inicial','Carga Inicial',1,'CargaInicialUpd',null,1


set @id = @id +1

insert into sis_menu(
	MenuId,Titulo,Descripcion,Tipo,MenuWinBarNameId,MenuPadreId,Activo
)
select @id,'Entrada por Compra','Entrada por Compra',1,'frmProductosCompra',null,1


set @id = @id +1

insert into sis_menu(
	MenuId,Titulo,Descripcion,Tipo,MenuWinBarNameId,MenuPadreId,Activo
)
select @id,'Entrada por Traspaso','Entrada por Traspaso',1,'frmEntradaTraspasoList',null,1


set @id = @id +1

insert into sis_menu(
	MenuId,Titulo,Descripcion,Tipo,MenuWinBarNameId,MenuPadreId,Activo
)
select @id,'Entrada Directa','Entrada Directa',1,'frmEntradaDirectaList',null,1



set @id = @id +1

insert into sis_menu(
	MenuId,Titulo,Descripcion,Tipo,MenuWinBarNameId,MenuPadreId,Activo
)
select @id,'Entrada Por Ajuste','Entrada Por Ajuste',1,'frmAjusteEntradaList',null,1



set @id = @id +1

insert into sis_menu(
	MenuId,Titulo,Descripcion,Tipo,MenuWinBarNameId,MenuPadreId,Activo
)
select @id,'Salida Por Traspaso','Salida Por Traspaso',1,'frmSalidaTraspasoList',null,1



set @id = @id +1

insert into sis_menu(
	MenuId,Titulo,Descripcion,Tipo,MenuWinBarNameId,MenuPadreId,Activo
)
select @id,'Salida Por Ajuste','Salida Por Ajuste',1,'frmAjusteSalidaList',null,1


set @id = @id +1

insert into sis_menu(
	MenuId,Titulo,Descripcion,Tipo,MenuWinBarNameId,MenuPadreId,Activo
)
select @id,'Máximos y Mínimos','Máximos y Mínimos',1,'frmMaximosMinimos',null,1

END