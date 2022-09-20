if not exists (
	select 1
	from sis_menu	
)
begin



insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo)
select 1,'Comandas','Comandas',2,'rbComanda',1

insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo)
select 2,'Cuentas','Cuentas',2,'rbCuenta',1

insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo)
select 3,'Ticket','Ticket',2,'rbTicket',1

insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo)
select 4,'Caja','Caja',2,'rbCaja',1

insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo)
select 5,'Impresoras','Impresoras',2,'rbImpresora',1


insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo,MenuPadreId)
select 6,'Nueva Comanda','Nueva Comanda',2,'uiMenuNuevaComanda',1,1



insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo,MenuPadreId)
select 7,'Imprimir Comanda','Imprirmi Comanda',2,'uiMenuImprimirComanda',1,1


insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo,MenuPadreId)
select 8,'Imprimir Cuenta','Imprirmir Cuenta',2,'uiMenuImprimirCuenta',1,2


insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo,MenuPadreId)
select 9,'Cancelar Cuenta','Cancelar Cuenta',2,'uiMenuCancelarCuenta',1,2


insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo,MenuPadreId)
select 10,'Ver Cuentas','Ver Cuentas',2,'uiMenuCuentaList',1,2


insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo,MenuPadreId)
select 11,'Pagar','Pagar',2,'uiMenuPagar',1,2


insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo,MenuPadreId)
select 12,'Buscar Ticket','Buscar Ticket',2,'uiMenuBuscarTicket',1,3


insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo,MenuPadreId)
select 13,'Reimprimir Ticket','Reimprimir Ticket',2,'uiMenuReimprimirTicket',1,3


insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo,MenuPadreId)
select 14,'Cancelar Ticket','Cancelar Ticket',2,'uiCancelarTicket',1,3

insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo,MenuPadreId)
select 15,'Retiros','Retiros',2,'uiRetiros',1,4

insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo,MenuPadreId)
select 16,'Gastos','Gastos',2,'uiGastos',1,4


insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo,MenuPadreId)
select 17,'Corte Caja','Corte Caja',2,'uiCorteCaja',1,4


insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo,MenuPadreId)
select 18,'Abrir Cajón','Abrir Cajón',2,'uiAbrirCajon',1,4


insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo,MenuPadreId)
select 19,'Impresoras','Impresoras',2,'uiImpresoras',1,5


insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo,MenuPadreId)
select 20,'Impresora Tickets','Impresora Tickets',2,'uiImpresoraTicketPV',1,5


insert into sis_menu(MenuId,Titulo,Descripcion,Tipo,
MenuWinBarNameId,Activo,MenuPadreId)
select 21,'Impresora Comanda','Impresora Comanda',2,'uiImpresoraComanda',1,5



end



go