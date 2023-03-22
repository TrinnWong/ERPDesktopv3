IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_rpt_ventas_caja_movil'
)
DROP PROC p_rpt_ventas_caja_movil
GO


-- p_rpt_ventas_caja_movil 10,'20221020','20221020'
CREATE PROC p_rpt_ventas_caja_movil
@pSucursalId INT,
@pDel DATETIME,
@pAl DATETIME
AS

	SELECT 
		P.ProductoId,
		Producto = ISNULL(P.Clave,'') +'-'+ ISNULL(p.DescripcionCorta,'') ,
		
		Cantidad = SUM(VD.Cantidad),
		vd.PrecioUnitario,
		Total = SUM(VD.total)
	FROM doc_pedidos_orden po
	INNER JOIN cat_usuarios u on u.IdUsuario = po.CreadoPor AND							
								PO.VentaId IS NOT NULL
	INNER JOIN cat_cajas caj on caj.Clave = po.CajaId 						
	INNER JOIN cat_tipos_cajas TC ON TC.TipoCajaId = CAJ.TipoCajaId AND
							TC.Nombre LIKE '%MOVIL%'
	INNER JOIN doc_ventas V ON V.VentaId = PO.VentaId AND
						V.FechaCancelacion IS NULL AND
						CONVERT(VARCHAR,V.FechaCreacion,112) BETWEEN CONVERT(VARCHAR,@pDel,112) AND CONVERT(VARCHAR,@pAl,112) AND
						V.SucursalId = @pSucursalId
	INNER JOIN doc_ventas_Detalle VD ON VD.VentaId = V.VentaId
	INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId
	GROUP BY P.ProductoId,P.Clave,p.DescripcionCorta,vd.PrecioUnitario
	