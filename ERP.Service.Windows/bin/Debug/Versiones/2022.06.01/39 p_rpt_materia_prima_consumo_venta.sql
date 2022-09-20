IF  EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME ='p_rpt_materia_prima_consumo_venta'
)
DROP PROC p_rpt_materia_prima_consumo_venta
GO

CREATE PROC p_rpt_materia_prima_consumo_venta
@pSucursalId INT,
@pDel DATETIME='20220801',
@pAl DATETIME='20220815'
AS


	SELECT 
			ID = CAST(ROW_NUMBER() OVER(ORDER BY P.Descripcion ASC)  AS INT),
			Insumo = P.Descripcion,
			ProductoVenta = p2.Descripcion,
			CantidadInsumo = SUM(VD.Cantidad * PB.Cantidad),
			CantidadProductoVenta = SUM(VD.Cantidad)
	FROM cat_productos_base PB
	INNER JOIN doc_ventas_detalle VD ON VD.ProductoId = PB.ProductoId
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND V.Activo = 1
	INNER JOIN cat_productos P ON P.ProductoId = PB.ProductoBaseId
	INNER JOIN cat_productos P2 ON P2.ProductoId = PB.ProductoId
	WHERE V.SucursalId = @pSucursalId AND
	CONVERT(VARCHAR,V.Fecha,112) BETWEEN CONVERT(VARCHAR,@pDel,112) AND CONVERT(VARCHAR,@pAl,112)
	GROUP BY P.Descripcion,p2.Descripcion