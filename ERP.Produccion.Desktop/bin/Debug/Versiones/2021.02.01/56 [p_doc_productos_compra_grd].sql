IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'p_doc_productos_compra_grd'
)
DROP PROC p_doc_productos_compra_grd
GO
-- p_doc_productos_compra_grd 1, '20210101','20210801'
CREATE proc [dbo].[p_doc_productos_compra_grd]
@pSucursalId int,
@pDel DateTime ,
@pAl DateTime
as

	SELECT 
		pcd.ProductoCompraDetId,
		Sucursal = suc.NombreSucursal,
		pc.ProductoCompraId,
		pc.ProveedorId,
		Proveedor = prov.Nombre,
		RFC = prov.RFC,
	    pc.NumeroRemision,
		pc.FechaRegistro,
		TotalCompra = pc.Total,
		prod.Clave,
		prod.Descripcion,
		pcd.PrecioNeto,
		pcd.Cantidad,
		pcd.Subtotal,
		Impuestos = pcd.Total-pcd.Subtotal,
		TotalPartida=pcd.Total
		
	FROM doc_productos_compra pc
	INNER JOIN doc_productos_compra_detalle pcd  ON pcd.ProductoCompraId = pc.ProductoCompraId
	INNER JOIN cat_proveedores prov on prov.ProveedorId = pc.ProveedorId
	INNER JOIN cat_productos prod on prod.ProductoId = pcd.ProductoId
	INNER JOIN cat_sucursales suc on suc.Clave = pc.SucursalId
	WHERE pc.FechaRegistro BETWEEN @pDel AND @pAl and
	@pSucursalId in (0,pc.SucursalId) AND
	pc.Activo = 1
	ORDER BY prov.Nombre,pc.NumeroRemision