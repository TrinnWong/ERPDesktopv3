if EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_rh_empleado_sel'
)
DROP PROC p_rh_empleado_sel
GO

CREATE PROC p_rh_empleado_sel
@pUsuarioId INT
AS

	SELECT RH.*
	FROM rh_empleados RH
	INNER JOIN cat_usuarios U ON U.IdEmpleado = RH.NumEmpleado
	WHERE U.IdUsuario = @pUsuarioId