IF NOT EXISTS (
	select * 
	from [sis_usuarios_roles] ur
	inner join cat_usuarios u on u.IdUsuario = ur.UsuarioId
	where u.NombreUsuario = 'ADMIN' and
	ur.RolId = 1 --ADMINISTRADOR
)
BEGIN

	insert into [sis_usuarios_roles]
	select IdUsuario,1,getdate()
	from cat_usuarios
	where NombreUsuario= 'ADMIN' 
END
