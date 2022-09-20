
if not exists (
	select 1
	from sis_roles
)
begin

insert into sis_roles(
	RolId,Nombre,Activo)
select 1,'Administrador Sistema',1
union
select 2,'Gerente',1
union
select 3,'Cajero sin priv. para corte',1
union
select 4,'Cajero con priv. para corte',1
union
select 5,'Comandero',1

end