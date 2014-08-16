use PanLucho
go

--truncate table dbo.Usuario;
--truncate table dbo.Modulo
--truncate table dbo.ModuloCategoria;
--truncate table dbo.ModulosXRol;
--truncate table dbo.Rol;
--truncate table dbo.Estado;
--go

insert into Estado( Id, descripcion )values ( 1,'activo');
insert into Estado( Id, descripcion )values ( 2,'inactivo');

insert into Rol( Id, Nombre, Descripcion, IdEstado )values( 1,'ADMIN', 'admin',1);
insert into Rol( Id, Nombre, Descripcion, IdEstado )values( 2,'VENDEDOR', 'factura',1);
--insert into Rol( Id, Nombre, Descripcion, IdEstado )values( 3,'PEDIDOSESPECIALES', 'personal con acceso a pantallas de pedidos',1);

insert into ModuloCategoria values( 1 ,'SEGURIDAD' , 'frm menu seguridad' , '2014-07-30 19:00:01' , '2014-07-30 20:07:53' , 1 , 'lquinter'  );
insert into ModuloCategoria values(2, 'VENTAS' , 'frm menu ventas' , '2014-07-30 19:00:01' , '2014-07-30 20:07:53' , 1 , 'lquinter'  );
insert into ModuloCategoria values( 3 ,'GASTOS-PAGOS' , 'frm menu ventas' , '2014-07-30 19:33:01' , '2014-07-30 20:07:53' , 1 , 'macastro'  );

insert into Modulo values  (
          1 , -- IdModuloCategoria - numeric
          'Usuarios' , -- Nombre - varchar(20)
          'Administracion usuarios' , -- Descripcion - varchar(50)
          '' , -- Assembler - varchar(20)
          'ClbUsuarios' , -- LibreriaClase - varchar(20)
          'FrmUsuarios' , -- NombreFormulario - varchar(20)
          '' , -- Imagen - varchar(100)
          '2014-07-30 09:16:09' , -- FechaCreacion - datetime
          '2014-07-30 09:16:09' , -- FechaEdicion - datetime
          1 , -- IdEstado - 
          'lquinter'  -- UsuarioEdicion - varchar(20)
        );

insert into Modulo values(
          1 , -- IdModuloCategoria - numeric
          'Roles' , -- Nombre - varchar(20)
          'Asignacion roles' , -- Descripcion - varchar(50)
          '' , -- Assembler - varchar(20)
          'ClbRoles' , -- LibreriaClase - varchar(20)
          'FrmRoles' , -- NombreFormulario - varchar(20)
          '' , -- Imagen - varchar(100)
          '2014-07-30 09:16:09' , -- FechaCreacion - datetime
          '2014-07-30 09:16:09' , -- FechaEdicion - datetime
          1 , -- IdEstado - 
          'lquinter'  -- UsuarioEdicion - varchar(20)
        );

insert into Modulo values(
          2 , -- IdModuloCategoria - numeric
          'Facturar' , -- Nombre - varchar(20)
          'facturas' , -- Descripcion - varchar(50)
          '' , -- Assembler - varchar(20)
          'ClbFacturas' , -- LibreriaClase - varchar(20)
          'FrmFactura' , -- NombreFormulario - varchar(20)
          '' , -- Imagen - varchar(100)
          '2014-07-30 09:16:09' , -- FechaCreacion - datetime
          '2014-07-30 09:16:09' , -- FechaEdicion - datetime
          1 , -- IdEstado - 
          'lquinter'  -- UsuarioEdicion - varchar(20)
        );

insert into Modulo values(
          2 , -- IdModuloCategoria - numeric
          'Facturar' , -- Nombre - varchar(20)
          'facturas emitidas' , -- Descripcion - varchar(50)
          '' , -- Assembler - varchar(20)
          'ClbFacturas' , -- LibreriaClase - varchar(20)
          'FrmReporteFactura' , -- NombreFormulario - varchar(20)
          '' , -- Imagen - varchar(100)
          '2014-07-30 09:16:09' , -- FechaCreacion - datetime
          '2014-07-30 09:16:09' , -- FechaEdicion - datetime
          1 , -- IdEstado - 
          'lquinter'  -- UsuarioEdicion - varchar(20)
        );

insert into Modulo values(
          2 , -- IdModuloCategoria - numeric
          'Clientes' , -- Nombre - varchar(20)
          'Administracion clientes' , -- Descripcion - varchar(50)
          '' , -- Assembler - varchar(20)
          'ClbClientes' , -- LibreriaClase - varchar(20)
          'FrmCliente' , -- NombreFormulario - varchar(20)
          '' , -- Imagen - varchar(100)
          '2014-07-30 09:16:09' , -- FechaCreacion - datetime
          '2014-07-30 09:16:09' , -- FechaEdicion - datetime
          1 , -- IdEstado - 
          'lquinter'  -- UsuarioEdicion - varchar(20)
        );
insert into Modulo values(
          2 , -- IdModuloCategoria - numeric
          'Pedido especial' , -- Nombre - varchar(20)
          'Pedidos especiales' , -- Descripcion - varchar(50)
          '' , -- Assembler - varchar(20)
          'ClbPedidosEspeciales' , -- LibreriaClase - varchar(20)
          'FrmPedidosEspeciales' , -- NombreFormulario - varchar(20)
          '' , -- Imagen - varchar(100)
          '2014-07-30 09:16:09' , -- FechaCreacion - datetime
          '2014-07-30 09:16:09' , -- FechaEdicion - datetime
          1 , -- IdEstado - 
          'lquinter'  -- UsuarioEdicion - varchar(20)
        );
insert into Modulo values(
          3 , -- IdModuloCategoria - numeric
          'Cierre caja' , -- Nombre - varchar(20)
          'Cierre de caja' , -- Descripcion - varchar(50)
          '' , -- Assembler - varchar(20)
          'ClbCierreCaja' , -- LibreriaClase - varchar(20)
          'FrmCierreCaja' , -- NombreFormulario - varchar(20)
          '' , -- Imagen - varchar(100)
          '2014-07-30 09:16:09' , -- FechaCreacion - datetime
          '2014-07-30 09:16:09' , -- FechaEdicion - datetime
          1 , -- IdEstado - 
          'lquinter'  -- UsuarioEdicion - varchar(20)
        );
insert into Usuario( IdRol ,Nombre ,Apellido ,Ecorreo ,Identificacion ,Contrasena ,FechaCreacion ,FechaEdicion ,IdEstado)values  ( 1 , 'Miguel' , 'Aspiazu' , 'lquinter@espol.edu.ec' , '0930456773' , '123' , '2014-07-29 22:33:28' , '2014-07-29 23:37:28' ,1);
insert into Usuario( IdRol ,Nombre ,Apellido ,Ecorreo ,Identificacion ,Contrasena ,FechaCreacion ,FechaEdicion ,IdEstado)values  ( 1 , 'Marco' , 'Castro' , 'macastro@espol.edu.ec' , '0989345662' , '1234' , '2014-07-29 22:33:15' , '2014-07-29 23:49:00' ,1);
insert into Usuario( IdRol ,Nombre ,Apellido ,Ecorreo ,Identificacion ,Contrasena ,FechaCreacion ,FechaEdicion ,IdEstado)values  ( 2 , 'Bruce' , 'Wayne' , 'wayne@gotik.uk' , '0938461123' , '1234' , '2014-07-29 21:11:10' , '2014-07-29 22:21:05' ,1);
insert into Usuario( IdRol ,Nombre ,Apellido ,Ecorreo ,Identificacion ,Contrasena ,FechaCreacion ,FechaEdicion ,IdEstado)values  ( 2 , 'Peter' , 'Parker' , 'petpar@dcomic.com' , '0989345662' , '1234' , '2014-07-29 22:33:15' , '2014-07-29 23:49:00' ,1);

set identity_insert [modulosxrol] on 
go
insert [modulosxrol] ([id], [idrol], [idmodulo], [parametros]) values (cast(1 as numeric(5, 0)), cast(1 as numeric(5, 0)), cast(1 as numeric(5, 0)), n'c|r|u|d')
go
insert [modulosxrol] ([id], [idrol], [idmodulo], [parametros]) values (cast(2 as numeric(5, 0)), cast(1 as numeric(5, 0)), cast(2 as numeric(5, 0)), n'c|r|u|d')
go
insert [modulosxrol] ([id], [idrol], [idmodulo], [parametros]) values (cast(3 as numeric(5, 0)), cast(1 as numeric(5, 0)), cast(3 as numeric(5, 0)), n'c|r|u|d')
go
insert [modulosxrol] ([id], [idrol], [idmodulo], [parametros]) values (cast(4 as numeric(5, 0)), cast(1 as numeric(5, 0)), cast(4 as numeric(5, 0)), n'c|r|u|d')
go
insert [modulosxrol] ([id], [idrol], [idmodulo], [parametros]) values (cast(5 as numeric(5, 0)), cast(1 as numeric(5, 0)), cast(5 as numeric(5, 0)), n'c|r|u|d')
go
insert [modulosxrol] ([id], [idrol], [idmodulo], [parametros]) values (cast(6 as numeric(5, 0)), cast(1 as numeric(5, 0)), cast(6 as numeric(5, 0)), n'c|r|u|d')
go
insert [modulosxrol] ([id], [idrol], [idmodulo], [parametros]) values (cast(7 as numeric(5, 0)), cast(1 as numeric(5, 0)), cast(7 as numeric(5, 0)), n'c|r|u|d')
go
insert [modulosxrol] ([id], [idrol], [idmodulo], [parametros]) values (cast(8 as numeric(5, 0)), cast(2 as numeric(5, 0)), cast(3 as numeric(5, 0)), n'c|r')
go
insert [modulosxrol] ([id], [idrol], [idmodulo], [parametros]) values (cast(9 as numeric(5, 0)), cast(2 as numeric(5, 0)), cast(4 as numeric(5, 0)), n'c|r')
go
insert [modulosxrol] ([id], [idrol], [idmodulo], [parametros]) values (cast(10 as numeric(5, 0)), cast(2 as numeric(5, 0)), cast(5 as numeric(5, 0)), n'c|r')
go
set identity_insert [modulosxrol] off
go
