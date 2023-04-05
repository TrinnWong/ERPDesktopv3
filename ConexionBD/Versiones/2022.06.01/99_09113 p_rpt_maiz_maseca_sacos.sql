IF EXISTS (

	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_rpt_maiz_maseca_sacos'
)
DROP PROC p_rpt_maiz_maseca_sacos
GO

-- p_rpt_maiz_maseca_sacos 31
CREATE PROC p_rpt_maiz_maseca_sacos
@pSucursalId INT
AS

	SELECT MM.Id,
			S.NombreSucursal,
			MM.SucursalId,
			MM.Fecha,
			MM.MaizSacos,
			MM.MasecaSacos,
			MM.TortillaMaizRendimiento,
			MM.TortillaMasecaRendimiento,
			MM.TortillaTotalRendimiento,
			MM.CreadoEl,
			MM.CreadoPor,
			MM.ModificadoEl,
			MM.ModificadoPor
	FROM doc_maiz_maseca_rendimiento MM
	INNER JOIN cat_sucursales S ON S.Clave = MM.SucursalId
	WHERE MM.SucursalId = @pSucursalId
