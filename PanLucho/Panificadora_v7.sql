use master
if exists(select * from sys.databases where name='PanLucho')-- solo existen los objetos sys.databases y sys.sysdatabases
drop database PanLucho
PRINT N'1.base PanLucho eliminada'
go

create database PanLucho
PRINT N'2.base PanLucho creada '
go

use PanLucho
go

create schema seg --seguridad
go
create schema aud --auditoria
go 
create schema fac --facturacion
go
create schema inv --inventario
go
create schema con --contabilidad
go
create schema msj --mensajes
go
create schema err --errores
go
create schema rh --recursos humanos
go

PRINT N'3.Falta agregar tablas a schema correspondiente '
PRINT N'4. PanLucho v9 '
go
--create table Historial(
--IdHistorial int primary key,
--IdUsuario numeric(5,0),
--NickUsuario varchar(25),
--NombreFormulario varchar(255),
--TipoAccion varchar(50),--CRUD
--Fecha date,
--Hora time,
--Estacion varchar(20), --nombre Pc

--foreign key(IdUsuario)references Usuario
--)
--go
create table Estado(
Id numeric(5,0) primary key,
descripcion varchar(20)
)
go
create table ModuloCategoria(
	Id numeric(5, 0) not null primary key,
	Nombre varchar(20) null,
	Descripcion nchar(20) null,
	FechaCreacion DateTime null,
	FechaEdicion DateTime null,
	IdEstado numeric(5, 0) null,
	UsuarioEdicion varchar(20) null,
	foreign key(IdEstado)references Estado
)
go
create table Modulo(
	Id numeric(5, 0) identity primary key ,
	IdModuloCategoria numeric(5, 0) null,
	Nombre varchar(20) null,
	Descripcion varchar(50) null,
	Assembler varchar(20) null,
	LibreriaClase varchar(20) null,
	NombreFormulario varchar(20) null,
	Imagen varchar(100) null,
	FechaCreacion datetime null,
	FechaEdicion datetime null,
	IdEstado numeric(5,0) null,
	UsuarioEdicion varchar(20) null,
	foreign key(IdModuloCategoria)references ModuloCategoria,
	foreign key(IdEstado) references Estado
)
go

go
create table Rol(
	Id numeric(5, 0) identity primary key,
	Nombre varchar(20) null,
	Descripcion varchar(20) null,
	IdEstado numeric(5, 0) null,
	foreign key(IdEstado)references Estado
)
go
create table ModulosXRol(
	Id numeric(5,0) identity primary key ,
	IdRol numeric(5, 0) null,
	IdModulo numeric(5, 0) null,
	Parametros nvarchar(10) null, --ej: c|r|u|d
	foreign key(IdRol)references Rol,
	foreign key(IdModulo)references Modulo
)
go
create table TipoMensaje(
Id numeric(5,0) primary key,
descripcion varchar(20)
)
go

create table Mensaje(
Id numeric(5,0) primary key,
leyenda varchar(50),
IdTipoMensaje numeric(5,0)
foreign key(IdTipoMensaje)references TipoMensaje
)
go

create table TipoError(
Id numeric(5,0) primary key,
descripcion varchar(20)
)
go

create table Error(
Id numeric(5,0) primary key,
leyenda varchar(50),
IdTipoError numeric(5,0)
foreign key(IdTipoError)references TipoError
)
go
create table Usuario(
	Id numeric(5, 0) identity(1,1) primary key,
	IdRol numeric(5, 0) null,
	Nombre varchar(100) null,
	Apellido varchar(100) null,
	Ecorreo varchar(50) null,
	Identificacion varchar(25) null,
	Contrasena varchar(255) null, --usar ENCRYPTBYPASSPHRASE
	FechaCreacion datetime null,
	FechaEdicion datetime null,
	IdEstado numeric(5, 0) null,
foreign key(IdEstado)references Estado,
foreign key(IdRol)references Rol
)
go

create table Cliente(
	Id numeric(5,0) identity(1,1) primary key,
	Nombre nvarchar(30) null,
	Apellido nvarchar(30) null,
	TipoIdentificacion nchar(1) null,
	NumeroIdentificacion varchar(13) null,
	Ecorreo nvarchar(50) null,
	FechaNacimiento date null, --de q sirve?
	Estado numeric(5, 0) null, --si no es tabla nos jode
	--IdDireccion numeric(5,0),
    --IdTelefono numeric(5,0),
	FechaCreacion datetime null,
	FechaEdicion datetime null,
	UsuarioCreacion nvarchar(25) null,
	UsuarioEdicion nvarchar(25) null
foreign key(Estado) references Estado
--foreign key(IdDireccion)references Direccion,
--foreign key(IdTelefono)references Telefono
)
go
create table Direccion(
Id numeric(5,0) primary key,
Zona varchar(20),
CallePrincipal varchar(50),
CalleTransversal varchar(50),
NumeroDomicilio varchar(20),
Descripcion varchar(100)
)
go
create table Sucursal(
Id numeric(5,0) primary key,
Descripcion varchar(50),
IdDireccion numeric(5,0),
IdEstado numeric(5,0),

foreign key(IdDireccion)references Direccion,
foreign key(IdEstado)references Estado,
)
go
create table Telefono(
Id numeric(5,0) primary key,
IdTabla numeric(5, 0) null,
CodigoArea numeric(3,0),
Discado numeric(3,0),
NumeroTelefono varchar(15) not null,
Extension varchar(5),
foreign key(IdTabla)references Cliente,
foreign key(IdTabla)references Sucursal
)
go
CREATE TABLE Evento(
Id numeric(5,0) PRIMARY KEY,
Descripcion VARCHAR(50),
IdEstado numeric(5,0),
FOREIGN KEY(IdEstado)REFERENCES Estado
)
go
create table Promocion(
Id numeric(5,0) primary key,
Descripcion varchar(100) not null,
DiaInicio date not null,
DiaFin date not null,
TipoPromocion varchar(50),
PrctDescuento numeric(4,2), --porcentaje max 99.99

FechaCreacion datetime,
FechaEdicion datetime,
UserCreador varchar(25),
UserEdicion varchar(25),
)
go
create table Producto(
	Id numeric(5, 0) IDENTITY(1,1) NOT null primary key,
	Descripcion nvarchar(30) NOT null,
	DescripcionDetallada nvarchar(50) null,
	ClaseProducto nvarchar(4) null,
	UnidadMedida nvarchar(3) NOT null,
	Existencias decimal(8, 4) NOT null,
	Precio smallmoney NOT null,
	IdEstado numeric(5,0),
	EsGrabado bit NOT null,
	FechaCreacion datetime NOT null,
	FechaEdicion datetime NOT null,
	UsuarioCreacion nvarchar(25) NOT null,
	UsuarioEdicion nvarchar(25) NOT null,
foreign key(IdEstado)references Estado
)
go
create table FormaPago(
Id numeric(5,0) primary key,
Descripcion varchar(30) not null,
IdEstado numeric(5,0),

FechaCreacion datetime,
FechaEdicion datetime,
UserCreador varchar(25),
UserEdicion varchar(25),

foreign key(IdEstado)references Estado
)
go

create table FacturaCab(
Id numeric(5, 0) IDENTITY(1,1) primary key,--numero
IdCliente numeric(5,0) not null,
FechaFacturacion datetime,
FacturaSRI varchar(max),
SubTotal money,
IVA money,
Descuento money,
TotalPagar money,

FechaCreacion datetime,
UserCreador varchar(25),
Procesado bit,
EsCancelado bit,
IdSucursal numeric(5,0),
foreign key(IdCliente)references Cliente,
foreign key(IdSucursal)references Sucursal,
)
go
create table FacturaDetalle(
IdFacturaCab numeric(5, 0), --Pk y FK
linea numeric(5,0) not null, --Pk cambia por producto
IdProducto numeric(5,0),
Cantidad numeric(9,0),
TotalLinea smallmoney, --SubTotal campo calculado
Iva numeric(4,2), --el porcentaje max 99,99
DescuentoPorcentaje numeric(4,2),--el porcentaje
DescuentoValor numeric(4,2)

primary key(IdFacturaCab,linea),
foreign key(IdFacturaCab)references FacturaCab,
foreign key(IdProducto)references Producto
)
go
create table FacturaDetallePago(
	IdFormaPago numeric(5, 0) IDENTITY(1,1),
	IdFactura numeric(5, 0) not null,
	Cantidad smallmoney
)
go

CREATE TABLE OrdenEspecialCab(
Id INT PRIMARY KEY,
IdCliente numeric(5,0),
IdSucursal numeric(5,0),
IdEvento numeric(5,0),
Leyenda varchar(50),
Imagen bit,
FechaEntrega date,
Observaciones varchar(100),

FechaCreacion datetime,
UserCreador varchar(25),
IdEstado numeric(5,0),

FOREIGN KEY(IdEstado)REFERENCES Estado,
FOREIGN KEY(IdCliente)REFERENCES Cliente,
FOREIGN KEY(IdSucursal)REFERENCES Sucursal,
FOREIGN KEY(IdEvento)REFERENCES Evento
)
go

create table OrdenEspecialDetalle(
IdOrdenEspecialCab int not null, --Pk y FK
linea int not null, --Pk

IdProducto numeric(5,0),
Cantidad numeric(9,0),
TotalPagar smallmoney, --SubTotal campo calculado
Iva numeric(4,2), --el porcentaje max 99,99
Descuento numeric(4,2),--el porcentaje

primary key(IdOrdenEspecialCab,linea),
foreign key(IdOrdenEspecialCab)references OrdenEspecialCab,
foreign key(IdProducto)references Producto
)
go
create table Kardex(
	KardexId int IDENTITY(1,1) not null primary key,
	Source nvarchar(2) not null,
	Reference nvarchar(10) not null,
	StockCode nvarchar(30) not null,
	Stock decimal(8, 2) not null,
	Qty decimal(8, 2) not null,
	NewStock  AS (Stock+Qty) PERSISTED,
	TransferType nvarchar(25) not null,
	CreatedDate datetime not null,
	CreatedUser nvarchar(25) not null,
)
go
create table Configuracion(
	Tipo nchar(10) null,
	Valor nchar(10) null,
	Descripcion nchar(10) null
)
go

PRINT N'5.creando vistas'
go

create view vwUsuarioPermisos as
select distinct row_number() over(order by Usuario.Id) as id, Usuario.Id as IdUsuario, Usuario.Ecorreo as Nick, Rol.Nombre as Descripcion, 
	Modulo.NombreFormulario as NombreFormulario, Modulo.LibreriaClase as LibreriaClase, ModuloCategoria.Nombre as Menu, ModulosXRol.Parametros as Permisos 
from	Usuario, Rol, Modulo, ModuloCategoria, ModulosXRol, Estado
where	Modulo.IdModuloCategoria=ModuloCategoria.Id
	and Usuario.IdRol=Rol.Id
	and	ModulosXRol.IdRol=Usuario.IdRol --lo mismo al reves
	and ModulosXRol.IdModulo=Modulo.Id	 
	and Usuario.IdEstado= Estado.Id
go
