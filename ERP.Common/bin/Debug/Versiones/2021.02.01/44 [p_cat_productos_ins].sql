----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

alter PROC [dbo].[p_cat_productos_ins]
@pProductoId	int out,
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
@pFechaCaducidad DATETIME,
@pMinimoInventario DECIMAL(14,2),
@pMaximoInventario DECIMAL(14,2),
@pPorcUtilidad decimal(5,2),
@pTalla varchar(5),
@pColor varchar(10),
@pColor2 varchar(10),
@pEspecificaciones varchar(500),
@pSobrePedido bit
as


SELECT @pProductoId = ISNULL(MAX(ProductoId),0) + 1
FROM dbo.cat_productos


INSERT INTO dbo.cat_productos
(
    ProductoId,
    Clave,
    Descripcion,
    DescripcionCorta,
    FechaAlta,
    ClaveMarca,
    ClaveFamilia,
    ClaveSubFamilia,
    ClaveLinea,
    ClaveUnidadMedida,
    ClaveInventariadoPor,
    ClaveVendidaPor,
    Estatus,
    ProductoTerminado,
    Inventariable,
    MateriaPrima,
    ProdParaVenta,
    ProdVtaBascula,
    Seriado,
    NumeroDecimales,
    PorcDescuentoEmpleado,
    ContenidoCaja,
    Empresa,
    Sucursal,
    Foto,
	ClaveAlmacen,
	ClaveAnden,
	ClaveLote,
	FechaCaducidad,
	MinimoInventario,
	MaximoInventario,
	PorcUtilidad,
	Talla,
	Color,
	Color2,
	Especificaciones,
	SobrePedido,
	CodigoBarras
)
VALUES
(	@pProductoId,
    @pClave,
    @pDescripcion,
    @pDescripcionCorta,
    @pFechaAlta,
    @pClaveMarca,
    @pClaveFamilia,
    @pClaveSubFamilia,
    @pClaveLinea,
    @pClaveUnidadMedida,
    @pClaveInventariadoPor,
    @pClaveVendidaPor,
    @pEstatus,
    @pProductoTerminado,
    @pInventariable,
    @pMateriaPrima,
    @pProdParaVenta,
    @pProdVtaBascula,
    @pSeriado,
    @pNumeroDecimales,
    @pPorcDescuentoEmpleado,
    @pContenidoCaja,
    @pEmpresa,
    @pSucursal,
    @pFoto,
	@pClaveAlmacen,
	@pClaveAnden,
	@pClaveLote,
	@pFechaCaducidad,
	@pMinimoInventario,
	@pMaximoInventario,
	@pPorcUtilidad,
	@pTalla,
	@pColor,
	@pColor2,
	@pEspecificaciones,
	@pSobrePedido,
	@pClave
    )	


insert into cat_productos_existencias(
	ProductoId,	SucursalId,	ExistenciaTeorica,	CostoUltimaCompra,
	CostoPromedio,	ValCostoUltimaCompra,	ValCostoPromedio,
	ModificadoEl,	CreadoEl
)
select @pProductoId,@pSucursal,0,0,0,0,0,getdate(),getdate()

















