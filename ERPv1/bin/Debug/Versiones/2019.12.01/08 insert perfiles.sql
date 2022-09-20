if not exists (
	select 1
	from sis_perfiles
)
begin

insert into sis_perfiles(
PerfilId,Nombre,Activo)
select 1,'Capturar Comandas',1

insert into sis_perfiles(
PerfilId,Nombre,Activo)
select 2,'Ver Cuentas',1

insert into sis_perfiles(
PerfilId,Nombre,Activo)
select 3,'Cobrar',1


insert into sis_perfiles(
PerfilId,Nombre,Activo)
select 4,'Buscar y Reimprimir Tickets',1


insert into sis_perfiles(
PerfilId,Nombre,Activo)
select 5,'Registrar Retiros y Gastos',1


insert into sis_perfiles(
PerfilId,Nombre,Activo)
select 6,'Administrar Impresoras',1


insert into sis_perfiles(
PerfilId,Nombre,Activo)
select 7,'Generar Cortes de Caja',1

END
go

