IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_cat_productos_upd'
)
DROP PROC p_cat_productos_upd
GO

CREATE PROC [dbo].[p_cat_productos_upd]
@pProductoId	int,
@pClave	varchar(30),
@pDescripcion	varchar(60),
@pDescripcionCorta	varchar(30),
@pFechaAlta	date,
@pClaveMarca	int,
@pClaveFamilia	int,
@pClaveSubFamilia	int,
@pClaveLinea	int,
@pClaveUnidadMedida	int,
@pClaveInventariadoPor	int,
@pClaveVendidaPor	int,
@pEstatus	bit,
@pProductoTerminado	bit,
@pInventariable	bit,
@pMateriaPrima	bit,
@pProdParaVenta	bit,
@pProdVtaBascula	bit,
@pSeriado	bit,
@pNumeroDecimales	tinyint,
@pPorcDescuentoEmpleado	numeric(19,2),
@pContenidoCaja	int,
@pEmpresa	int,
@pSucursal	INT,
@pFoto	IMAGE,
@pClaveAlmacen INT,
@pClaveAnden INT,
@pClaveLote INT,
@pFechaCaducidad datetime,
@pMinimoInventario DECIMAL(14,2),
@pMaximoInventario DECIMAL(14,2),
@pPorcUtilidad decimal(5,2),
@pTalla varchar(5),
@pColor varchar(10),
@pColor2 varchar(10),
@pEspecificaciones varchar(500),
@pSobrePedido bit
as

update dbo.cat_productos
set
    
    Clave = @pClave,
    Descripcion = @pDescripcion,
    DescripcionCorta = @pDescripcionCorta,
    --FechaAlta = @pFechaAlta,
    ClaveMarca = @pClaveMarca,
    ClaveFamilia = @pClaveFamilia,
    ClaveSubFamilia = @pClaveSubFamilia,
    ClaveLinea = @pClaveLinea,
    ClaveUnidadMedida = @pClaveUnidadMedida,
    ClaveInventariadoPor = @pClaveInventariadoPor,
    ClaveVendidaPor = @pClaveVendidaPor,
    Estatus = @pEstatus,
    ProductoTerminado = @pProductoTerminado,
    Inventariable = @pInventariable,
    MateriaPrima = @pMateriaPrima,
    ProdParaVenta = @pProdParaVenta,
    ProdVtaBascula = @pProdVtaBascula,
    Seriado = @pSeriado,
    NumeroDecimales = @pNumeroDecimales,
    PorcDescuentoEmpleado = @pPorcDescuentoEmpleado,
    ContenidoCaja = @pContenidoCaja,
    Empresa = @pEmpresa,
    Sucursal = @pSucursal,
    Foto = @pFoto,
	ClaveAlmacen = @pClaveAlmacen,
	ClaveAnden = @pClaveAnden,
	ClaveLote = @pClaveLote,
	FechaCaducidad = @pFechaCaducidad,
	MinimoInventario = @pMinimoInventario,
	MaximoInventario = @pMaximoInventario,
	PorcUtilidad = @pPorcUtilidad,
	TallA = @pTalla,
	Color = @pColor,
	Color2 = @pColor2,
	Especificaciones = @pEspecificaciones,
	SobrePedido = @pSobrePedido
	WHERE ProductoId = @pProductoId









