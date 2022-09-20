
create table cat_empresas
(
	Clave int primary key not null,
	Nombre varchar(100) not null,
	NombreComercial varchar(100),
	RegimenFiscal varchar(100),
	RFC	varchar(20),
	Calle varchar(100),
	Colonia varchar(100),
	NoExt varchar(20),
	NoInt varchar(20),
	CP varchar(20),
	Ciudad varchar(50),
	Estado varchar(50),
	Pais varchar(50),
	Telefono1 varchar(40),
	Telefono2 varchar(40),
	Email varchar(60),
	FechaAlta date,
	Estatus	bit
)
go
create table cat_sucursales
(
	Clave int,
	Empresa int,
	Calle varchar(50),
	Colonia varchar(50),
	NoExt nchar(20),
	NoInt nchar(20),
	Ciudad varchar(60),
	Estado varchar(60),
	Pais varchar(60),
	Telefono1 varchar(40),
	Telefono2 varchar(40),
	Email varchar(60),
	Estatus bit,
	NombreSucursal varchar(60)
)
go
create table cat_familias
(
	Clave int primary key not null,
	Descripcion varchar(60) not null,
	Estatus	bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_subfamilias
(
	Clave int primary key not null,
	Descripcion varchar(60) not null,
	Familia int not null foreign key references cat_familias (Clave),
	Estatus	bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_divisiones_sat
(
	Clave int primary key not null,
	Descripcion varchar(2) not null,
	Estatus bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_grupos_sat
(
	Clave int primary key not null,
	Descripcion varchar(2) not null,
	Estatus bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_clases_sat
(
	Clave int primary key not null,
	Descripcion varchar(2) not null,
	Estatus bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_subclases_sat
(
	Clave int primary key not null,
	Descripcion varchar(2) not null,
	Estatus bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_almacenes
(
	Clave int primary key not null,
	Descripcion varchar(60) not null,
	Ubicacion varchar(60),
	Estatus	bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_anaqueles
(
	Clave int primary key not null,
	Descripcion varchar(60) not null,
	Estatus	bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_andenes
(
	Clave int primary key  not null,
	Descripcion varchar(60) not null,
	Estatus	bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_centro_costos
(
	Clave int primary key  not null,
	Descripcion varchar(60) not null,
	Estatus	bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_denominaciones
(
	Clave int primary key  not null, 
	Descripcion	varchar(60) not null,
	Valor money,
	Orden int,
	Estatus bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_giros_neg
(
	Clave int primary key not null,
	Descripcion varchar(60) not null,
	Estatus	bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_lotes
(
	Clave int primary key not null,
	Descripcion varchar(60) not null,
	Estatus	bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_marcas
(
	Clave int primary key not null,
	Descripcion varchar(60) not null,
	Estatus	bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_monedas
(
	Clave int primary key not null, 
	Descripcion	varchar(60) not null,
	Abreviacion varchar(20),
	TipoCambio decimal,
	Estatus bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_unidadesmed
(
	Clave int primary key not null,
	Descripcion varchar(60) not null,
	DescripcionCorta varchar(20),
	Decimales int,
	Estatus	bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_est_productos
(
	Clave int primary key not null,
	Descripcion varchar(60) not null,
	Estatus	bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table rh_formaspagonom
(
	Clave int primary key not null,
	Descripcion varchar(60) null,
	NumDias int null,
	HrasDia int null,
	Estatus int null,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table rh_departamentos 
(
	Clave int primary key not null,
	Descripcion varchar(60) null,
	Estatus bit null,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table rh_tipos_contrato
(
	Clave int primary key not null,
	Descripcion varchar(60),
	Estatus	bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table rh_puestos
(
	Clave int primary key not null,
	Descripcion varchar(60),
	Estatus	bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table rh_empleados
(
	NumEmpleado	int primary key not null,
	Nombre varchar(150) not null,
	SueldoNeto money not null,
	SueldoDiario money,
	SueldoHra money,
	FormaPago int null foreign key references rh_formaspagonom (Clave),
	TipoContrato int null foreign key references rh_tipos_contrato (Clave),
	Puesto int not null foreign key references rh_puestos (Clave),
	Departamento int not null foreign key references rh_departamentos (Clave),
	FechaIngreso date,
	FechaInicioLab date,
	Estatus	int,
	Foto image,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
create table cat_rubros
(
	Clave int primary key not null,
	Descripcion varchar(60),
	Estatus	bit,
	Empresa	int null foreign key references cat_empresas (Clave),
	Sucursal int null foreign key references cat_empresas (Clave)
)
go
