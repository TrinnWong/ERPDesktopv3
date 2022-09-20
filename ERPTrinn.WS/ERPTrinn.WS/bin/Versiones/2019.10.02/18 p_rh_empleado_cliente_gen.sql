if exists (

	select 1
	from sysobjects
	where name = 'p_rh_empleado_cliente_gen'
)
drop proc p_rh_empleado_cliente_gen
go

create proc p_rh_empleado_cliente_gen
@pEmpleadoId int
as

	declare @clienteId int

	if not exists (
		select 1
		from cat_clientes
		where empleadoId = @pEmpleadoId
	)
	begin

		select @clienteId = isnull(max(ClienteId),0) +1
		from cat_clientes

		insert into cat_clientes(ClienteId,ApellidoPaterno,ApellidoMaterno,Nombre,
		Activo,EmpleadoId)
		select @clienteId,'','',Nombre,1,NumEmpleado
		from rh_empleados e
		where e.NumEmpleado = @pEmpleadoId

	end


	