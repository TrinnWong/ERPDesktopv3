if  EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_cat_usuarios_sel'
)
DROP PROC p_cat_usuarios_sel
GO
-- p_cat_usuarios_sel 1
Create proc p_cat_usuarios_sel
@pUsuarioId INT
AS

	SELECT u.IdUsuario,
		u.NombreUsuario,
		rh.Nombre,
		rh.NumEmpleado
	FROM cat_usuarios u
	LEFT JOIN rh_empleados RH ON RH.NumEmpleado = u.IdEmpleado