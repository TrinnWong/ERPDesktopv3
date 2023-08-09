IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_doc_gastos_sel'
)
DROP PROC p_doc_gastos_sel
GO

CREATE PROC p_doc_gastos_sel
@SucursalId INT,
@FechaInicio DATETIME,
@FechaFin DATETIME,
@UsuarioId INT
AS


SELECT G.GastoId,
	G.CentroCostoId,
	G.GastoConceptoId,
	Concepto = c.Descripcion,
	Observaciones = G.Obervaciones,
	G.Monto,
	G.CajaId,
	G.CreadoEl,
	G.CreadoPor,
	G.SucursalId,
	G.Activo,
	Sucursal = S.NombreSucursal
FROM doc_gastos G
INNER JOIN cat_usuarios_sucursales US ON US.UsuarioId = @UsuarioId AND
									G.SucursalId = US.SucursalId
INNER JOIN cat_gastos C ON C.Clave = g.GastoConceptoId AND
@SucursalId IN (0,G.SucursalId) AND
CAST(G.CreadoEl AS DATE) BETWEEN CAST(@FechaInicio AS DATE) AND CAST(@FechaFin AS DATE)
INNER JOIN cat_sucursales S ON S.Clave = G.SucursalId
ORDER BY G.CreadoEl DESC