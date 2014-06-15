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
PRINT N'4.  '

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

create table Estado(
Id numeric(5,0) primary key,
descripcion varchar(20)
)
go

create table Usuario(
Id numeric(5,0) primary key,
Nombre varchar(100),
Apellido varchar(100),
NickUsuario varchar(25),
PassUsuario varchar(50), --usar ENCRYPTBYPASSPHRASE
FechaCreacion datetime,
FechaEditado datetime,
IdEstado numeric(5,0),

foreign key(IdEstado)references Estado
)
go

create table Telefono(
Id numeric(5,0) primary key,
CodigoArea numeric(3,0),
Discado numeric(3,0),
NumeroTelefono varchar(15) not null,
Extension varchar(5)
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
IdTelefono numeric(5,0),
IdEstado numeric(5,0),

foreign key(IdDireccion)references Direccion,
foreign key(IdEstado)references Estado,
foreign key(IdTelefono)references Telefono
)
go

create table Cliente(
Id numeric(5,0) identity(1,1) primary key,
Nombre varchar(100),
Apellido varchar(100),
TipoIdentificacion varchar(20),
NumeroIdentificacion varchar(20),
Ecorreo varchar(50),
FechaNacimiento datetime, --de q sirve?

Estado numeric(5,0), --si no es tabla nos jode

--IdDireccion numeric(5,0),
--IdTelefono numeric(5,0),

FechaCreacion datetime,
FechaEdicion datetime,
UsuarioCreacion varchar(25),
UsuarioEdicion varchar(25),

foreign key(Estado) references Estado,
--foreign key(IdDireccion)references Direccion,
--foreign key(IdTelefono)references Telefono
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
Id numeric(5,0) primary key,
Descripcion varchar(30) not null,
DescripcionDetallada varchar(100),
FechaProduccion date,
FechaCaducidad date,
CantidadMax numeric(5,0),
Existencias numeric(5,0), --stock
UnidadMedida varchar(20), --otra tabla?
Categoria varchar(20), --FK ?
Precio smallmoney,
PorcentajeDescuento numeric(4,2),
Impuesto numeric(4,2), --no va??
Observacion varchar(100),
IdEstado numeric(5,0),

FechaCreacion datetime,
FechaEdicion datetime,
UserCreador varchar(25),
UserEdicion varchar(25),

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
Id int primary key,--numero
IdSucursal numeric(5,0),
Fecha date not null,
IdCliente numeric(5,0) not null,
IdFormaPago numeric(5,0) not null,
--Comisiones?

FechaCreacion datetime,
UserCreador varchar(25),

foreign key(IdCliente)references Cliente,
foreign key(IdFormaPago)references FormaPago,
foreign key(IdSucursal)references Sucursal,
)
go

create table FacturaDetalle(
IdFacturaCab int not null, --Pk y FK
linea numeric(5,0) not null, --Pk

IdProducto numeric(5,0),
Cantidad numeric(9,0),
TotalPagar smallmoney, --SubTotal campo calculado
Iva numeric(4,2), --el porcentaje max 99,99
Descuento numeric(4,2),--el porcentaje

primary key(IdFacturaCab,linea),
foreign key(IdFacturaCab)references FacturaCab,
foreign key(IdProducto)references Producto
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

CREATE TABLE [Kardex]( --?
	[KardexId] [int] IDENTITY(1,1) primary key,
	[Source] [nvarchar](2) NOT NULL,
	[Reference] [nvarchar](10) NOT NULL,
	[StockCode] [nvarchar](30) NOT NULL,
	[Stock] [decimal](8, 2) NOT NULL,
	[Qty] [decimal](8, 2) NOT NULL,
	[NewStock]  AS ([Stock]+[Qty]) PERSISTED,
	[TransferType] [nvarchar](25) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedUser] [nvarchar](25) NOT NULL
)
go

create table ProcesoError(
Id int primary key,
Tipo varchar(50),
NombreProceso varchar(50),
Descripcion varchar(200),
Fecha date,
Hora time
)
go

insert into Estado(Id,descripcion) values(1,'Activo')
go

