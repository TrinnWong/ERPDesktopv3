IF  EXISTS (SELECT 1
FROM SYSOBJECTS
WHERE NAME = 'p_cat_gatos_sel')
DROP PROC p_cat_gatos_sel
GO

CREATE PROC p_cat_gatos_sel
AS

	select Clave,
	Descripcion,
	ClaveCentroCosto,
	Estatus,
	Empresa,
	Sucursal,
	Monto,
	Observaciones,
	ConceptoId,
	CreadoPor,
	CreadoEl,
	CajaId
	from [dbo].[cat_gastos]