IF  EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_rpt_estado_cuenta_detalle'
)
DROP PROC p_rpt_estado_cuenta_detalle
GO

-- p_rpt_estado_cuenta_detalle 0,'all','20210101','20220228'
CREATE proc p_rpt_estado_cuenta_detalle
@pSucursalId INT,
@pTipo varchar(50),
@pDel DATETIME,
@pAl DATETIME
AS

	--GASTOS
	SELECT Fecha = PC.FechaRegistro,
			Sucursal = SUC.NombreSucursal,
		   Movimiento = 'Compras a Proveedores',
		   DetalleMovimiento = 'Proveedor:'+ISNULL(PROV.Nombre,''),
		   Total = (PC.Total) * -1,
		   CargoAbono=CAST(0 AS BIT)
	FROM doc_productos_compra PC
	INNER JOIN doc_inv_movimiento I ON I.ProductoCompraId = PC.ProductoCompraId
	INNER JOIN cat_proveedores PROV ON PROV.ProveedorId = PC.ProveedorId
	INNER JOIN cat_sucursales SUC ON SUC.Clave = PC.SucursalId
	WHERE PC.Activo = 1 AND
	I.Activo = 1	AND
	@pSucursalId IN(	PC.SucursalId,0) AND
	CONVERT(VARCHAR,PC.FechaRegistro,112) BETWEEN CONVERT(VARCHAR,@pDel,112) AND CONVERT(VARCHAR,@pAl,112)
	AND @pTipo IN ('ALL','GAS')

	UNION

	SELECT G.CreadoEl,
			Sucursal = SUC.NombreSucursal,
			Movimiento='Gastos Caja Chica',
			DetalleMovimiento = G.Obervaciones,
			Total = G.Monto * -1,
			CargoAbono=CAST(0 AS BIT)
	FROM doc_gastos G
	INNER JOIN cat_sucursales SUC ON SUC.Clave = G.SucursalId
	WHERE G.Activo = 1 AND
	@pSucursalId IN(G.SucursalId,0)AND
	CONVERT(VARCHAR,G.CreadoEl,112) BETWEEN CONVERT(VARCHAR,@pDel,112) AND CONVERT(VARCHAR,@pAl,112)
	AND @pTipo IN ('ALL','GAS')

	UNION 

	--VENTAS

	SELECT
		V.Fecha,
		SucursalId = SUC.NombreSucursal,
		Movimiento='Venta',
		DetalleMovimiento = ISNULL(V.Serie,'') + ISNULL(V.Folio,''),
		Total = V.TotalVenta,
			CargoAbono=CAST(1 AS bit)
	FROM doc_ventas V
	INNER JOIN cat_sucursales SUC ON SUC.Clave = V.SucursalId
	WHERE V.Activo = 1 AND
	@pSucursalId IN(v.SucursalId,0)AND
	CONVERT(VARCHAR,V.Fecha,112) BETWEEN CONVERT(VARCHAR,@pDel,112) AND CONVERT(VARCHAR,@pAl,112)
	AND @pTipo IN ('ALL','VEN')
	order by 1 desc
	