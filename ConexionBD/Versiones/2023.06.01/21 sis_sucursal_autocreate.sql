
-- sis_sucursal_autocreate 'VILLA HERMOSA (TAM)','caja1.vhermosa','admin.vhermosa','cajero1.vhermosa','miguelangeeel0111@gmail.com;jvg_2008_64@hotmail.com'
create PROC sis_sucursal_autocreate
@NombreSucursal varchar(250),
@caja varchar(250),
@usuarioAdmin varchar(250),
@usuarioCajero varchar(250),
@emailSupervisor varchar(250)
AS

DECLARE @SucursalId_Last INT=0 
DECLARE @SucursalId_New INT=0 
DECLARE @cajaId INT=0
DECLARE @BasculaId INT = 0
DECLARE @EmpleadoId INT =0
DECLARE @UsuarioId INT = 0
DECLARE @Password VARCHAR(250)
DECLARE @Id INT
DECLARE @ClienteId INT
DECLARE @ClienteProductoPrecioId INT
DECLARE @PrecioEspecialId INT
DECLARE @ImpresoraId INT
DECLARE @CajaImpresoraId INT

BEGIN TRAN


BEGIN TRY

	IF EXISTS (SELECT 1 FROM cat_sucursales WHERE NombreSucursal = @NombreSucursal) RETURN

	SELECT @SucursalId_Last = max(Clave)
	FROM cat_sucursales

	SET @SucursalId_New = @SucursalId_Last + 1 


	--CREAR SUCURSAL
	INSERT INTO cat_sucursales(Clave,Empresa,Calle,Colonia,NoExt,NoInt,
	Ciudad,Estado,Pais,Telefono1,Telefono2,Email,
	Estatus,NombreSucursal,CP,ServidorMailSMTP,ServidorMailFrom,
	ServidorMailPort,ServidorMailPassword)
	SELECT @SucursalId_New ,Empresa,'','','','',
	'','','','','','',
	1,@NombreSucursal,'',ServidorMailSMTP,ServidorMailFrom,
	ServidorMailPort,ServidorMailPassword
	FROM cat_sucursales
	WHERE Clave = @SucursalId_Last


	SELECT * FROM cat_sucursales
	WHERE Clave = @SucursalId_New

	SELECT @cajaId = ISNULL(MAX(Clave),0) + 1
	FROM cat_cajas
	--CREAR CAJA
	INSERT INTO cat_cajas(
		Clave,Descripcion,Ubicacion,Estatus,Empresa,Sucursal,TipoCajaId
	)
	SELECT @cajaId,@caja,@NombreSucursal,1,1,@SucursalId_New,1

	SELECT * FROM cat_cajas WHERE Clave = @cajaId


	--BASCULA

	SELECT @BasculaId = ISNULL(MAX(BasculaId),0) + 1
	FROM cat_basculas

	INSERT INTO cat_basculas(
		BasculaId,EmpresaId,Alias,Marca,Modelo,Serie,SucursalAsignadaId,Activo,CreadoEl,CreadoPor,ModificadoEl,ModificadoPor
	)
	SELECT @BasculaId,1,'BASCULA-' +@NombreSucursal,'','','',@SucursalId_New,1,getdate(),1,NULL,NULL

	SELECT * FROM cat_basculas WHERE BasculaId = @BasculaId


	--PERSONAL ADMIN

	SELECT @EmpleadoId = ISNULL(MAX(NumEmpleado),0) + 1
	FROM rh_empleados

	INSERT INTO rh_empleados(
		NumEmpleado,		Nombre,			SueldoNeto,		SueldoDiario,		SueldoHra,
		FormaPago,			TipoContrato,	Puesto,			Departamento,		FechaIngreso,
		FechaInicioLab,		Estatus,		Foto,			Empresa,			Sucursal
	)
	VALUES( @EmpleadoId,		@usuarioAdmin,	0,				0,					0,
	null,					null,			1,				NULL,				GETDATE(),
	GETDATE(),				1,				NULL,			NULL,					NULL)

	--USUARIO ADMIN
	SELECT @UsuarioId = MAX(ISNULL(IdUsuario,0)) + 1
	FROM cat_usuarios

	set @Password = CAST(FLOOR(RAND() * 90000 + 10000) AS VARCHAR);

	INSERT INTO cat_usuarios(
	IdUsuario,		IdEmpleado,		NombreUsuario,		Password,
	CreadoEl,		Activo,			EsSupervisor,		PasswordSupervisor,
	IdSucursal,		EsSupervisorCajero,PasswordSupervisorCajero,Email,
	CajaDefaultId)
	VALUES(@UsuarioId,@EmpleadoId,@usuarioAdmin,@Password,
	GETDATE(),		1,				1,					@Password,
	@SucursalId_New,1,				@Password,@emailSupervisor,
	NULL)

	INSERT INTO cat_usuarios_sucursales(UsuarioId,SucursalId,CreadoEl)
	VALUES(@UsuarioId,@SucursalId_New,GETDATE())


	SELECT * FROM rh_empleados WHERE NumEmpleado = @EmpleadoId

	SELECT * FROM cat_usuarios WHERE IdUsuario = @UsuarioId

	SELECT * FROM cat_usuarios_sucursales WHERE UsuarioId = @UsuarioId


	--PERSONAL CAJERO

	SELECT @EmpleadoId = ISNULL(MAX(NumEmpleado),0) + 1
	FROM rh_empleados
	INSERT INTO rh_empleados(
		NumEmpleado,		Nombre,			SueldoNeto,		SueldoDiario,		SueldoHra,
		FormaPago,			TipoContrato,	Puesto,			Departamento,		FechaIngreso,
		FechaInicioLab,		Estatus,		Foto,			Empresa,			Sucursal
	)
	SELECT @EmpleadoId,@usuarioCajero,0,0,0,
	null,					null,			2,				NULL,				GETDATE(),
	GETDATE(),				1,				NULL,			NULL,					NULL


	--USUARIO cajero
	SELECT @UsuarioId = MAX(ISNULL(IdUsuario,0)) + 1
	FROM cat_usuarios

	set @Password = CAST(FLOOR(RAND() * 90000 + 10000) AS VARCHAR);

	INSERT INTO cat_usuarios(
	IdUsuario,		IdEmpleado,		NombreUsuario,		Password,
	CreadoEl,		Activo,			EsSupervisor,		PasswordSupervisor,
	IdSucursal,		EsSupervisorCajero,PasswordSupervisorCajero,Email,
	CajaDefaultId)
	VALUES(@UsuarioId,@EmpleadoId,@usuarioCajero,@Password,
	GETDATE(),		1,				0,					NULL,
	@SucursalId_New,0,				NULL,'',
	@cajaId)

	INSERT INTO cat_usuarios_sucursales(UsuarioId,SucursalId,CreadoEl)
	VALUES(@UsuarioId,@SucursalId_New,GETDATE())

	SELECT * FROM rh_empleados WHERE NumEmpleado = @EmpleadoId
	SELECT * FROM cat_usuarios WHERE IdUsuario = @UsuarioId
	SELECT * FROM cat_usuarios_sucursales WHERE UsuarioId = @UsuarioId

	SELECT @Id = ISNULL(MAX(Id),0)+1
	FROM sis_preferencias_sucursales

	INSERT INTO sis_preferencias_sucursales(Id,SucursalId,PreferenciaId,Valor,CreadoEl)
	SELECT  @Id + ROW_NUMBER() OVER(ORDER BY iD ASC)  ,@SucursalId_New ,PreferenciaId,
		CASE WHEN PreferenciaId = 19 then @emailSupervisor ELSE Valor END
		,CreadoEl
	from sis_preferencias_sucursales
	WHERE SucursalId = @SucursalId_Last


	SELECT * FROM sis_preferencias_sucursales
	WHERE SucursalId = @SucursalId_New


	--REPARTOS
	SELECT @ClienteId = ISNULL(MAX(ClienteId),0) + 1
	FROM cat_clientes 
	INSERT INTO cat_clientes(ClienteId,Nombre,Telefono,SucursalBaseId,Activo)
	VALUES(@ClienteId,'REPARTOS ('+@NombreSucursal+')','(833) 000-00'+(CAST(@SucursalId_New AS VARCHAR)),@SucursalId_New,1 )

	SELECT * FROM cat_clientes WHERE ClienteId = @ClienteId


	SELECT @ClienteProductoPrecioId = ISNULL(MAX(ClienteProductoPrecioId),0) + 1
	FROM doc_clientes_productos_precios

	INSERT INTO doc_clientes_productos_precios(
		ClienteProductoPrecioId,ClienteId,ProductoId,Precio,CreadoEl
	)
	VALUES(@ClienteProductoPrecioId,@ClienteId,1,26,getdate())


	SELECT @ClienteProductoPrecioId = ISNULL(MAX(ClienteProductoPrecioId),0) + 1
	FROM doc_clientes_productos_precios

	INSERT INTO doc_clientes_productos_precios(
		ClienteProductoPrecioId,ClienteId,ProductoId,Precio,CreadoEl
	)
	VALUES(@ClienteProductoPrecioId,@ClienteId,2,20,getdate())

	SELECT *
	FROM doc_clientes_productos_precios
	WHERE ClienteId = @ClienteId

	--NUEVA SUCURSAL PARA ADMIN
	INSERT INTO cat_usuarios_sucursales(UsuarioId,SucursalId,CreadoEl)
	VALUES(1,@SucursalId_New,GETDATE())

	--PRECIOS SUCURSAL
	INSERT INTO doc_precios_especiales(
		Descripcion,FechaVigencia,HoraVigencia,CreadoEl,CreadoPor,SucursalId
	)
	VALUES('PRECIOS '+@NombreSucursal,'20501201','2050-12-01 11:59:00.000',getdate(),1,@SucursalId_New)

	SET @PrecioEspecialId = SCOPE_IDENTITY()

	SELECT * FROM doc_precios_especiales Where SucursalId = @SucursalId_New

	INSERT INTO doc_precios_especiales_detalle(
		PrecioEspeciaId,ProductoId,PrecioEspecial,MontoAdicional,CreadoEl,CreadoPor,ModificadoEl,ModificadoPor
	)
	SELECT @PrecioEspecialId,ProductoId,PP.Precio,0,GETDATE(),1,NULL,NULL
	FROM cat_productos P
	inner join cat_productos_precios pp on pp.IdProducto = p.ProductoId AND PP.IdPrecio = 1
	WHERE P.ProdParaVenta = 1

	SELECT *
	FROM doc_precios_especiales_detalle
	WHERE PrecioEspeciaId = @PrecioEspecialId


	INSERT INTO cat_sucursales_productos(
		SucursalId,ProductoId,CreadoEl
	)	
	SELECT @SucursalId_New,ProductoId,getdate()
	FROM doc_precios_especiales_detalle
	WHERE PrecioEspeciaId = @PrecioEspecialId

	select *
	from cat_sucursales_productos
	where SucursalId = @SucursalId_New


	--IMPRESORAS
	
		SELECT @ImpresoraId = ISNULL(MAX(ImpresoraId),0) + 1
		from cat_impresoras 

		INSERT INTO cat_impresoras(ImpresoraId,SucursalId,NombreRed,NombreImpresora,Activa,CreadoEl)
		VALUES(@ImpresoraId,@SucursalId_New,'POS-80C',@NombreSucursal,1,GETDATE())



		select @CajaImpresoraId = ISNULL(MAX(CajaImpresoraId),0) + 1
		FROM cat_cajas_impresora

		INSERT INTO cat_cajas_impresora(
		CajaImpresoraId,CajaId,ImpresoraId,CreadoEl
		)
		SELECT @CajaImpresoraId,Clave,@ImpresoraId, GETDATE()
		FROM cat_cajas
		WHERE Sucursal = @SucursalId_New
	
	COMMIT  TRAN
END TRY
BEGIN CATCH
	select ERROR_MESSAGE()
	ROLLBACK TRAN
END CATCH
