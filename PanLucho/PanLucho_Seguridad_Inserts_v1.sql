use PanLucho
go

--truncate table dbo.Usuario;
--truncate table dbo.Modulo
--truncate table dbo.ModuloCategoria;
--truncate table dbo.ModulosXRol;
--truncate table dbo.Rol;
--truncate table dbo.Estado;
--go

insert into dbo.Estado( Id, descripcion )values ( 1,'activo');
insert into dbo.Estado( Id, descripcion )values ( 2,'inactivo');

insert into Rol( Id, Nombre, Descripcion, IdEstado )values( 1,'ADMIN', 'admin',1);
insert into Rol( Id, Nombre, Descripcion, IdEstado )values( 2,'VENDEDOR', 'factura',1);
--insert into Rol( Id, Nombre, Descripcion, IdEstado )values( 3,'PEDIDOSESPECIALES', 'personal con acceso a pantallas de pedidos',1);

insert into dbo.ModuloCategoria( Id ,Nombre ,Descripcion ,FechaCreacion ,FechaEdicion ,IdEstado ,UsuarioEdicion)values( 1 ,'SEGURIDAD' , 'frm menu seguridad' , '2014-07-30 19:00:01' , '2014-07-30 20:07:53' , 1 , 'lquinter'  );
insert into dbo.ModuloCategoria( Id ,Nombre ,Descripcion ,FechaCreacion ,FechaEdicion ,IdEstado ,UsuarioEdicion)values( 2 ,'VENTAS' , 'frm menu ventas' , '2014-07-30 19:00:01' , '2014-07-30 20:07:53' , 1 , 'lquinter'  );
insert into dbo.ModuloCategoria( Id ,Nombre ,Descripcion ,FechaCreacion ,FechaEdicion ,IdEstado ,UsuarioEdicion)values( 3 ,'GASTOSyPAGOS' , 'frm menu ventas' , '2014-07-30 19:33:01' , '2014-07-30 20:07:53' , 1 , 'macastro'  );

insert into dbo.Usuario( Id ,IdRol ,Nombre ,Apellido ,Ecorreo ,Identificacion ,Contraseña ,FechaCreacion ,FechaEdicion ,IdEstado)values  ( 1 , 1 , 'Miguel' , 'Aspiazu' , 'lquinter@espol.edu.ec' , '0930456773' , '123' , '2014-07-29 22:33:28' , '2014-07-29 23:37:28' ,1);
insert into dbo.Usuario( Id ,IdRol ,Nombre ,Apellido ,Ecorreo ,Identificacion ,Contraseña ,FechaCreacion ,FechaEdicion ,IdEstado)values  ( 2 , 1 , 'Marco' , 'Castro' , 'macastro@espol.edu.ec' , '0989345662' , '1234' , '2014-07-29 22:33:15' , '2014-07-29 23:49:00' ,1);
insert into dbo.Usuario( Id ,IdRol ,Nombre ,Apellido ,Ecorreo ,Identificacion ,Contraseña ,FechaCreacion ,FechaEdicion ,IdEstado)values  ( 3 , 2 , 'Bruce' , 'Wayne' , 'wayne@gotik.uk' , '0938461123' , '1234' , '2014-07-29 21:11:10' , '2014-07-29 22:21:05' ,1);
insert into dbo.Usuario( Id ,IdRol ,Nombre ,Apellido ,Ecorreo ,Identificacion ,Contraseña ,FechaCreacion ,FechaEdicion ,IdEstado)values  ( 4 , 2 , 'Peter' , 'Parker' , 'petpar@dcomic.com' , '0989345662' , '1234' , '2014-07-29 22:33:15' , '2014-07-29 23:49:00' ,1);
