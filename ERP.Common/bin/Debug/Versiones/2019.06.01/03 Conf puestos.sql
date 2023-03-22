if exists(
select 1
from cat_configuracion
where Giro = 'REST'
)
and not exists (
	select 1
	from rh_puestos 
	where clave = 4
)
begin


	insert into rh_puestos(
	Clave,		Descripcion,		Estatus,	Empresa,
	Sucursal,		PermitirEliminar,	Mostrar
	)
	select 4,'Mesero', 1,1,1,0,1

end