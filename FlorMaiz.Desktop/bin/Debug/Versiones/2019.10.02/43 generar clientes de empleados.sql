select NumEmpleado
into #tmpEmpleados
from rh_empleados

declare @id int

select @id=min(NumEmpleado)
from #tmpEmpleados

while @id is not null
begin

exec p_rh_empleado_cliente_gen @id

select @id=min(NumEmpleado)
from #tmpEmpleados
where NumEmpleado > @id

end

