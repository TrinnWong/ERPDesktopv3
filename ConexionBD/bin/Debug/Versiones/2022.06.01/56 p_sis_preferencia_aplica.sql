IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_sis_preferencia_aplica'
)
DROP PROC p_sis_preferencia_aplica
GO

create proc p_sis_preferencia_aplica
@pEmpresaId INT,
@pSucursalId INT,
@pPreferencia VARCHAR(50)
AS


	DECLARE @Result BIT=0

	IF EXISTS(
		SELECT 1
		FROM sis_preferencias_sucursales		
	)
	BEGIN

		
		SELECT p.Id,P.Preferencia,PS.Valor
		FROM sis_preferencias_sucursales PS
		INNER JOIN sis_preferencias P ON P.Id = PS.PreferenciaId
		WHERE SucursalId = @pSucursalId

	END
	ELSE
	BEGIN
		SELECT p.Id,P.Preferencia,PE.Valor
		FROM sis_preferencias_empresa PE
		INNER JOIN sis_preferencias P ON P.Id = PE.PreferenciaId
		WHERE PE.EmpresaId = @pEmpresaId

	END

