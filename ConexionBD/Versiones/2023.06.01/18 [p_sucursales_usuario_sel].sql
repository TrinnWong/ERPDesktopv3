

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER proc [dbo].[p_sucursales_usuario_sel]
@pUsuario varchar(20)
as

	declare @esSupervisor bit

	select @esSupervisor = u.EsSupervisor
	from cat_usuarios u
	where rtrim(u.NombreUsuario) = rtrim(@pUsuario)


	if(@esSupervisor = 1 AND UPPER(ISNULL(@pUsuario,'')) = 'ADMIN')
	begin

		select s.Clave,
				s.NombreSucursal
		from cat_sucursales s
		
	end
	else
	begin
		select s.Clave,
				s.NombreSucursal
		from cat_sucursales s
		inner join cat_usuarios u on rtrim(u.NombreUsuario) = rtrim(@pUsuario) 
		INNER JOIN cat_usuarios_sucursales us on us.UsuarioId = u.IdUsuario AND
										us.SucursalId = s.Clave
	end




