use PanLucho
go
--region Drop Existing Procedures

IF OBJECT_ID(N'[dbo].[spClienteInsertar]') IS NOT NULL
	DROP PROCEDURE [dbo].[spClienteInsertar]

--endregion

GO

--region [dbo].[spInsertCliente]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   kerberos using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[spInsertCliente]
-- Date Generated: lunes, 28 de julio de 2014
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[spClienteInsertar]
	@Id numeric(5, 0) output,
	@Nombre varchar(100),
	@Apellido varchar(100),
	@TipoIdentificacion varchar(20),
	@NumeroIdentificacion varchar(20),
	@Ecorreo varchar(50),
	@FechaNacimiento datetime,
	@Estado numeric(5, 0),
	@FechaCreacion datetime,
	@FechaEdicion datetime,
	@UsuarioCreacion varchar(25),
	@UsuarioEdicion varchar(25)
AS

SET NOCOUNT ON

INSERT INTO [dbo].[Cliente] (
	[Nombre],
	[Apellido],
	[TipoIdentificacion],
	[NumeroIdentificacion],
	[Ecorreo],
	[FechaNacimiento],
	[Estado],
	[FechaCreacion],
	[FechaEdicion],
	[UsuarioCreacion],
	[UsuarioEdicion]
) VALUES (
	@Nombre,
	@Apellido,
	@TipoIdentificacion,
	@NumeroIdentificacion,
	@Ecorreo,
	@FechaNacimiento,
	@Estado,
	@FechaCreacion,
	@FechaEdicion,
	@UsuarioCreacion,
	@UsuarioEdicion
)
set @Id = @@identity
--endregion

GO

/*
        Autor       :   Usuario
        Notas       :   Derechos de Autor 2013 ESPOL Todos los derechos reservados
        Historia    :   
                        29/07/2014
*/
CREATE PROCEDURE [dbo].spClienteEliminar
@Id numeric(5, 0)
AS

DELETE FROM
[dbo].[Cliente]
WHERE
[Id] = @Id
GO

/*
        Autor       :   Usuario
        Notas       :   Derechos de Autor 2013 ESPOL Todos los derechos reservados
        Historia    :   
                        29/07/2014
*/
CREATE PROCEDURE [dbo].spClienteObtener
@Id numeric(5, 0)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
[Id],
[Nombre],
[Apellido],
[TipoIdentificacion],
[NumeroIdentificacion],
[Ecorreo],
[FechaNacimiento],
[Estado],
[FechaCreacion],
[FechaEdicion],
[UsuarioCreacion],
[UsuarioEdicion]
FROM
[dbo].[Cliente]
WHERE
[Id] = @Id

GO

/*
        Autor       :   Usuario
        Notas       :   Derechos de Autor 2013 ESPOL Todos los derechos reservados
        Historia    :   
                        29/07/2014
*/

CREATE PROCEDURE [dbo].spClienteObtenerLista
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
[Id],
[Nombre],
[Apellido],
[TipoIdentificacion],
[NumeroIdentificacion],
[Ecorreo],
[FechaNacimiento],
[Estado],
[FechaCreacion],
[FechaEdicion],
[UsuarioCreacion],
[UsuarioEdicion]
FROM
[dbo].[Cliente]

GO




/*
        Autor       :   Usuario
        Notas       :   Derechos de Autor 2013 ESPOL Todos los derechos reservados
        Historia    :   
                        29/07/2014
*/

CREATE PROCEDURE [dbo].spClienteActualizar
@Id numeric(5, 0), 
@Nombre varchar(100), 
@Apellido varchar(100), 
@TipoIdentificacion varchar(20), 
@NumeroIdentificacion varchar(20), 
@Ecorreo varchar(50), 
@FechaNacimiento datetime, 
@Estado numeric(5, 0), 
@FechaCreacion datetime, 
@FechaEdicion datetime, 
@UsuarioCreacion varchar(25), 
@UsuarioEdicion varchar(25) 
AS

UPDATE [dbo].[Cliente] SET
[Nombre] = @Nombre,
[Apellido] = @Apellido,
[TipoIdentificacion] = @TipoIdentificacion,
[NumeroIdentificacion] = @NumeroIdentificacion,
[Ecorreo] = @Ecorreo,
[FechaNacimiento] = @FechaNacimiento,
[Estado] = @Estado,
[FechaCreacion] = @FechaCreacion,
[FechaEdicion] = @FechaEdicion,
[UsuarioCreacion] = @UsuarioCreacion,
[UsuarioEdicion] = @UsuarioEdicion
WHERE
[Id] = @Id

GO


------------------------------------------------------------------------------------------------------------------------
/*
        Autor       :   Usuario
        Notas       :   Derechos de Autor 2013 ESPOL Todos los derechos reservados
        Historia    :   
                        30/07/2014
*/
CREATE PROCEDURE [dbo].spUsuarioEliminar
@Id numeric(5, 0)
AS

DELETE FROM
[dbo].[Usuario]
WHERE
[Id] = @Id
GO

/*
        Autor       :   Usuario
        Notas       :   Derechos de Autor 2013 ESPOL Todos los derechos reservados
        Historia    :   
                        30/07/2014
*/
CREATE PROCEDURE [dbo].spUsuarioObtener
@Id numeric(5, 0)
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
[Id],
[IdRol],
[Nombre],
[Apellido],
[Ecorreo],
[Identificacion],
[Contraseņa],
[FechaCreacion],
[FechaEdicion],
[IdEstado]
FROM
[dbo].[Usuario]
WHERE
[Id] = @Id

GO

/*
        Autor       :   Usuario
        Notas       :   Derechos de Autor 2013 ESPOL Todos los derechos reservados
        Historia    :   
                        30/07/2014
*/

CREATE PROCEDURE [dbo].spUsuarioObtenerLista
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
[Id],
[IdRol],
[Nombre],
[Apellido],
[Ecorreo],
[Identificacion],
[Contraseņa],
[FechaCreacion],
[FechaEdicion],
[IdEstado]
FROM
[dbo].[Usuario]

GO


/*
        Autor       :   Usuario
        Notas       :   Derechos de Autor 2013 ESPOL Todos los derechos reservados
        Historia    :   
                        30/07/2014
*/

CREATE PROCEDURE [dbo].spUsuarioInsertar
@Id numeric(5, 0) output,
@IdRol numeric(5, 0),
@Nombre varchar(100),
@Apellido varchar(100),
@Ecorreo nchar(10),
@Identificacion varchar(25),
@Contraseņa varchar(50),
@FechaCreacion datetime,
@FechaEdicion datetime,
@IdEstado numeric(5, 0)
AS

INSERT INTO [dbo].[Usuario] (
[IdRol],
[Nombre],
[Apellido],
[Ecorreo],
[Identificacion],
[Contraseņa],
[FechaCreacion],
[FechaEdicion],
[IdEstado]
) VALUES (
@IdRol,
@Nombre,
@Apellido,
@Ecorreo,
@Identificacion,
@Contraseņa,
@FechaCreacion,
@FechaEdicion,
@IdEstado
)
set @Id = @@identity
GO

/*
        Autor       :   Usuario
        Notas       :   Derechos de Autor 2013 ESPOL Todos los derechos reservados
        Historia    :   
                        30/07/2014
*/

CREATE PROCEDURE [dbo].spUsuarioActualizar
@Id numeric(5, 0), 
@IdRol numeric(5, 0), 
@Nombre varchar(100), 
@Apellido varchar(100), 
@Ecorreo nchar(10), 
@Identificacion varchar(25), 
@Contraseņa varchar(50), 
@FechaCreacion datetime, 
@FechaEdicion datetime, 
@IdEstado numeric(5, 0) 
AS

UPDATE [dbo].[Usuario] SET
[IdRol] = @IdRol,
[Nombre] = @Nombre,
[Apellido] = @Apellido,
[Ecorreo] = @Ecorreo,
[Identificacion] = @Identificacion,
[Contraseņa] = @Contraseņa,
[FechaCreacion] = @FechaCreacion,
[FechaEdicion] = @FechaEdicion,
[IdEstado] = @IdEstado
WHERE
[Id] = @Id

GO


