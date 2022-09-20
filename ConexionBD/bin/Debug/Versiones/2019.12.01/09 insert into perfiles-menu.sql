

if not exists (
	select 1
	from sis_perfiles_menu
	)
begin

--Capturar comandas
insert into sis_perfiles_menu(
PerfilId,MenuId,CreadoEl
)
select 1,1,getdate()
union
select 1,7,getdate()

--Ver Cuentas
insert into sis_perfiles_menu(
PerfilId,MenuId,CreadoEl
)
select 2,2,getdate()
union
select 2,8,getdate()
union
select 2,9,getdate()
union
select 2,10,getdate()


--Cobrar
insert into sis_perfiles_menu(
PerfilId,MenuId,CreadoEl
)
select 3,11,getdate()
union
select 3,18,getdate()

--Buscar y Reimprimir Tickets
insert into sis_perfiles_menu(
PerfilId,MenuId,CreadoEl
)
select 4,12,getdate()
union 
select 4,13,getdate()
union 
select 4,14,getdate()

--Registrar Retiros y Gastos
insert into sis_perfiles_menu(
PerfilId,MenuId,CreadoEl
)
select 5,15,getdate()
union 
select 5,16,getdate()

--Administrar Impresoras
insert into sis_perfiles_menu(
PerfilId,MenuId,CreadoEl
)
select 6,19,getdate()
union 
select 6,20,getdate()
union 
select 6,21,getdate()

--Generar Corte de Caja
insert into sis_perfiles_menu(
PerfilId,MenuId,CreadoEl
)
select 7,17,getdate()
union 
select 6,18,getdate()


end