
IF  EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_rpt_produccion_molino'
)
DROP PROC p_rpt_produccion_molino
GO
create proc p_rpt_produccion_molino
@pSucursalId INT,
@pDel DATETIME,
@pAl DATETIME
as

	SELECT P.ProduccionId,
		ClaveProductoTerminado = PROD.Clave,
		Formula = PROD.DescripcionCorta,
		Tipo = 'Insumo',
		ProductoDetalle = PRODE.DescripcionCorta,
		Cantidad = SUM(PE.Cantidad),
		Unidad = U.DescripcionCorta,
		CreadoEl = P.CreadoEl,
		Inicio = P.FechaHoraInicio,
		Fin = P.FechaHoraFin
	FROM doc_produccion P
	INNER JOIN doc_produccion_entrada PE ON PE.ProduccionId = P.ProduccionId
	INNER JOIN cat_productos PROD ON PROD.ProductoId = p.ProductoId
	INNER JOIN  cat_productos PRODE ON PRODE.ProductoId = PE.ProductoId
	inner join cat_unidadesmed U ON U.Clave = PE.UnidadId
	GROUP BY  P.ProduccionId,
		PROD.Clave,
		PROD.DescripcionCorta,		
		PRODE.DescripcionCorta,
		U.DescripcionCorta,
		P.CreadoEl,
		P.FechaHoraInicio,
		P.FechaHoraFin
	
	UNION
	
	SELECT P.ProduccionId,
		ClaveProductoTerminado = PROD.Clave,
		Formula = PROD.DescripcionCorta,
		Tipo = 'Producto Terminado',
		ProductoDetalle = PRODE.DescripcionCorta,
		Cantidad = SUM(PE.Cantidad),
		Unidad = U.DescripcionCorta,
		CreadoEl = P.CreadoEl,
		Inicio = P.FechaHoraInicio,
		Fin = P.FechaHoraFin
	FROM doc_produccion P
	INNER JOIN doc_produccion_salida PE ON PE.ProduccionId = P.ProduccionId
	INNER JOIN cat_productos PROD ON PROD.ProductoId = p.ProductoId
	INNER JOIN  cat_productos PRODE ON PRODE.ProductoId = PE.ProductoId
	inner join cat_unidadesmed U ON U.Clave = PE.UnidadId
	
	GROUP BY  P.ProduccionId,
		PROD.Clave,
		PROD.DescripcionCorta,		
		PRODE.DescripcionCorta,
		U.DescripcionCorta,
		P.CreadoEl,
		P.FechaHoraInicio,
		P.FechaHoraFin
	



