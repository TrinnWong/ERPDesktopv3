if not exists (
	select 1
	from cat_lineas
	where clave = 0
)
begin

insert into cat_lineas(Clave,Descripcion,Estatus,Empresa,Sucursal)
select 0,'SIN DEFINIR',1,1,1

end

if not exists (
	select 1
	from cat_familias
	where clave = 0
)
begin

insert into cat_familias(Clave,Descripcion,Estatus,Empresa,Sucursal)
select 0,'SIN DEFINIR',1,1,1

end


if not exists (
	select 1
	from cat_subfamilias
	where clave = 0
)
begin

insert into cat_subfamilias(Clave,Descripcion,familia,Estatus,Empresa,Sucursal)
select 0,'SIN DEFINIR',0,1,1,1

end


