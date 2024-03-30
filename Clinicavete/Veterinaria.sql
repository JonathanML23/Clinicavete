-- Crear la base de datos "Veterinaria"
CREATE DATABASE Veterinaria;
GO

-- Usar la base de datos recién creada
USE Veterinaria;
GO

-- Crear la tabla "Usuarios"
CREATE TABLE Usuarios (
    Login_Usuario VARCHAR(50) PRIMARY KEY,
    Clave_Usuario VARCHAR(50),
    Nombre_Usuario VARCHAR(100)
	Activo VARCHAR (50),
	FechaRegistro VARCHAR 50,
);
GO

-- Crear la tabla "Mascotas"
CREATE TABLE Mascotas (
    ID_Mascota INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Mascota VARCHAR(100),
    Tipo_Mascota VARCHAR(50),
    Comida_Favorita VARCHAR(100)
);
GO

-- Crear la tabla "Citas"
CREATE TABLE Citas (
    ID_Cita INT IDENTITY(1,1) PRIMARY KEY,
    ID_Mascota INT,
    Proxima_fecha DATE,
    Medico_Asignado VARCHAR(100),
    FOREIGN KEY (ID_Mascota) REFERENCES Mascotas(ID_Mascota)
);
GO

INSERT INTO Usuarios (Login_Usuario, Clave_Usuario, Nombre_Usuario)
VALUES ('ID1', '123', 'Jonathan'),
       ('ID12', '123', 'David'),
       ('ID3', '123', 'Yeiner');

ALTER TABLE Usuarios
ADD Activo BIT NOT NULL DEFAULT 1; -- Por defecto, estableceremos todos los usuarios como activos
go

ALTER TABLE Usuarios
ADD FechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
go
 
CREATE PROCEDURE ObtenerUsuariosPorFechaRegistro
    @FechaInicio DATETIME,
    @FechaFin DATETIME
AS
BEGIN
    SELECT [Login_Usuario], [Clave_Usuario], [Nombre_Usuario]
    FROM [dbo].[Usuarios]
    WHERE FechaRegistro BETWEEN @FechaInicio AND @FechaFin;
END
GO

INSERT INTO Usuarios (Activo, FechaRegistro)
VALUES ('', '')

INSERT INTO Mascotas (Nombre_Mascota, Tipo_Mascota, Comida_Favorita)
VALUES ('Fanta', 'Gato', 'Atun'),
		('Peppsy', 'Perro', 'Carne'),
		('Coca', 'Perico', 'Banano');

INSERT INTO Citas (ID_Mascota, Proxima_fecha, Medico_Asignado)
VALUES 
    (1, '2024-04-01', 'Dr. Smith'),
    (3, '2024-04-03', 'Dr. Johnson'),
    (4, '2024-04-05', 'Dr. Brown');

--SP Reporte Usuarios
CREATE PROCEDURE ObtenerUsuarios
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Login_Usuario, Nombre_Usuario FROM Usuarios;
END
--Usuarios
CREATE PROCEDURE AgregarUsuario
    @LoginUsuario NVARCHAR(50),
    @ClaveUsuario NVARCHAR(50),
    @NombreUsuario NVARCHAR(100)
AS
BEGIN
    INSERT INTO Usuarios (Login_Usuario, Clave_Usuario, Nombre_Usuario)
    VALUES (@LoginUsuario, @ClaveUsuario, @NombreUsuario);
END

CREATE PROCEDURE ModificarUsuario
    @LoginUsuario NVARCHAR(50),
    @ClaveUsuario NVARCHAR(50),
    @NombreUsuario NVARCHAR(100)
AS
BEGIN
    UPDATE Usuarios
    SET Clave_Usuario = @ClaveUsuario,
        Nombre_Usuario = @NombreUsuario
    WHERE Login_Usuario = @LoginUsuario;
END

CREATE PROCEDURE EliminarUsuario
    @LoginUsuario NVARCHAR(50)
AS
BEGIN
    DELETE FROM Usuarios
    WHERE Login_Usuario = @LoginUsuario;
END
--Mascotas
CREATE PROCEDURE AgregarMascota
    @NombreMascota NVARCHAR(100),
    @TipoMascota NVARCHAR(100),
    @ComidaFavorita NVARCHAR(100)
AS
BEGIN
    INSERT INTO Mascotas (Nombre_Mascota, Tipo_Mascota, Comida_Favorita)
    VALUES (@NombreMascota, @TipoMascota, @ComidaFavorita);
END

CREATE PROCEDURE ModificarMascota
    @IDMascota INT,
    @NombreMascota NVARCHAR(100),
    @TipoMascota NVARCHAR(100),
    @ComidaFavorita NVARCHAR(100)
AS
BEGIN
    UPDATE Mascotas
    SET Nombre_Mascota = @NombreMascota,
        Tipo_Mascota = @TipoMascota,
        Comida_Favorita = @ComidaFavorita
    WHERE ID_Mascota = @IDMascota;
END

CREATE PROCEDURE EliminarMascota
    @IDMascota INT
AS
BEGIN
    DELETE FROM Mascotas
    WHERE ID_Mascota = @IDMascota;
END
--Citas
CREATE PROCEDURE AgregarCita
    @ID_Mascota INT,
    @Proxima_fecha DATE,
    @Medico_Asignado VARCHAR(100)
AS
BEGIN
    INSERT INTO Citas (ID_Mascota, Proxima_fecha, Medico_Asignado)
    VALUES (@ID_Mascota, @Proxima_fecha, @Medico_Asignado);
END

CREATE PROCEDURE ModificarCita
    @ID_Cita INT,
    @ID_Mascota INT,
    @Proxima_fecha DATE,
    @Medico_Asignado VARCHAR(100)
AS
BEGIN
    UPDATE Citas
    SET ID_Mascota = @ID_Mascota,
        Proxima_fecha = @Proxima_fecha,
        Medico_Asignado = @Medico_Asignado
    WHERE ID_Cita = @ID_Cita;
END;

CREATE PROCEDURE EliminarCita
    @ID_Cita INT
AS
BEGIN
    DELETE FROM Citas WHERE ID_Cita = @ID_Cita;
END


select * from Citas
-------------------------------------------------------

CREATE PROCEDURE ObtenerReporteCitasPorFechas
    @FechaInicio DATE,
    @FechaFin DATE
AS
BEGIN
    SELECT ID_Mascota, Proxima_fecha, Medico_Asignado
    FROM Citas
    WHERE Proxima_fecha BETWEEN @FechaInicio AND @FechaFin
END
go
 
-- SP para crear un nuevo usuario
CREATE PROCEDURE CrearUsuario
    @LoginUsuario NVARCHAR(50),
    @ClaveUsuario NVARCHAR(50),
    @NombreUsuario NVARCHAR(100)
AS
BEGIN
    INSERT INTO Usuarios (Login_Usuario, Clave_Usuario, Nombre_Usuario)
    VALUES (@LoginUsuario, @ClaveUsuario, @NombreUsuario)
END
GO
 
-- SP para leer información de usuario por nombre de usuario
CREATE PROCEDURE ObtenerUsuarioPorNombre
    @NombreUsuario NVARCHAR(100)
AS
BEGIN
    SELECT Login_Usuario, Clave_Usuario, Nombre_Usuario
    FROM Usuarios
    WHERE Nombre_Usuario = @NombreUsuario
END
GO
 
-- SP para actualizar la información de un usuario
CREATE PROCEDURE ActualizarUsuario
    @LoginUsuario NVARCHAR(50),
    @ClaveUsuario NVARCHAR(50),
    @NombreUsuario NVARCHAR(100)
AS
BEGIN
    UPDATE Usuarios
    SET Clave_Usuario = @ClaveUsuario, Nombre_Usuario = @NombreUsuario
    WHERE Login_Usuario = @LoginUsuario
END
GO
 
-- SP para eliminar un usuario
CREATE PROCEDURE EliminarUsuario
    @LoginUsuario NVARCHAR(50)
AS
BEGIN
    DELETE FROM Usuarios
    WHERE Login_Usuario = @LoginUsuario
END
GO
 
-- SP para crear una nueva mascota
CREATE PROCEDURE CrearMascota
    @NombreMascota NVARCHAR(100),
    @TipoMascota NVARCHAR(50),
    @ComidaFavorita NVARCHAR(100)
AS
BEGIN
    INSERT INTO Mascotas (Nombre_Mascota, Tipo_Mascota, Comida_Favorita)
    VALUES (@NombreMascota, @TipoMascota, @ComidaFavorita)
END
GO
 
-- SP para leer información de todas las mascotas
CREATE PROCEDURE ObtenerTodasLasMascotas
AS
BEGIN
    SELECT ID_Mascota, Nombre_Mascota, Tipo_Mascota, Comida_Favorita
    FROM Mascotas
END
GO
 
-- SP para actualizar información de una mascota
CREATE PROCEDURE ActualizarMascota
    @IDMascota INT,
    @NombreMascota NVARCHAR(100),
    @TipoMascota NVARCHAR(50),
    @ComidaFavorita NVARCHAR(100)
AS
BEGIN
    UPDATE Mascotas
    SET Nombre_Mascota = @NombreMascota, Tipo_Mascota = @TipoMascota, Comida_Favorita = @ComidaFavorita
    WHERE ID_Mascota = @IDMascota
END
GO
 
-- SP para eliminar una mascota
CREATE PROCEDURE EliminarMascota
    @IDMascota INT
AS
BEGIN
    DELETE FROM Mascotas
    WHERE ID_Mascota = @IDMascota
END
GO
 
-- SP para programar una nueva cita
CREATE PROCEDURE ProgramarCita
    @IDMascota INT,
    @ProximaFecha DATE,
    @MedicoAsignado NVARCHAR(100)
AS
BEGIN
    INSERT INTO Citas (ID_Mascota, Proxima_fecha, Medico_Asignado)
    VALUES (@IDMascota, @ProximaFecha, @MedicoAsignado)
END
GO
 
-- SP para obtener información detallada de una mascota y su cita asociada
CREATE PROCEDURE ObtenerInfoMascotaYCita
    @IDMascota INT
AS
BEGIN
    SELECT M.ID_Mascota, M.Nombre_Mascota, M.Tipo_Mascota, M.Comida_Favorita,
           C.Proxima_fecha, C.Medico_Asignado
    FROM Mascotas M
    INNER JOIN Citas C ON M.ID_Mascota = C.ID_Mascota
    WHERE M.ID_Mascota = @IDMascota
END
GO
-----------------------------------------------------------------------
CREATE PROCEDURE ObtenerTodosUsuarios
AS
BEGIN
    SELECT * FROM Usuarios;
END
 
 
CREATE PROCEDURE ObtenerUsuariosPorFechaRegistro
    @FechaInicio DATETIME,
    @FechaFin DATETIME
AS
BEGIN
    SELECT [Login_Usuario], [Clave_Usuario], [Nombre_Usuario]
    FROM [dbo].[Usuarios]
    WHERE FechaRegistro BETWEEN @FechaInicio AND @FechaFin;
END
GO
 
 
ALTER TABLE Usuarios
ADD FechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
go
 
CREATE PROCEDURE ObtenerUsuariosPorFechaRegistro
    @FechaInicio DATETIME,
    @FechaFin DATETIME
AS
BEGIN
    SELECT [Login_Usuario], [Clave_Usuario], [Nombre_Usuario]
    FROM [dbo].[Usuarios]
    WHERE FechaRegistro BETWEEN @FechaInicio AND @FechaFin;
END
GO
 
 
 
ALTER TABLE Usuarios
ADD Activo BIT NOT NULL DEFAULT 1; -- Por defecto, estableceremos todos los usuarios como activos
go
 
CREATE PROCEDURE ObtenerUsuariosActivosInactivos
AS
BEGIN
    -- Usuarios Activos
    SELECT [Login_Usuario], [Clave_Usuario], [Nombre_Usuario]
    FROM [dbo].[Usuarios]
    WHERE Activo = 1;
 
    -- Separador entre conjuntos de resultados
    PRINT '-------------------------';
 
    -- Usuarios Inactivos
    SELECT [Login_Usuario], [Clave_Usuario], [Nombre_Usuario]
    FROM [dbo].[Usuarios]
    WHERE Activo = 0;
END
GO
 
 
 
CREATE PROCEDURE ObtenerUsuariosRegistrados
AS
BEGIN
    SELECT [Login_Usuario], [Clave_Usuario], [Nombre_Usuario]
    FROM [dbo].[Usuarios];
END
GO

-------------------------------------------
use Veterinaria
go
 
 
SELECT name
FROM sys.procedures;
go
--------------------------------------------
CREATE PROCEDURE ObtenerUsuariosPorFechaRegistro
    @FechaInicio DATETIME,
    @FechaFin DATETIME
AS
BEGIN
    SELECT [Login_Usuario], [Clave_Usuario], [Nombre_Usuario]
    FROM [dbo].[Usuarios]
    WHERE FechaRegistro BETWEEN @FechaInicio AND @FechaFin;
END
GO

drop procedure ObtenerUsuariosPorFechaRegistro

---------------------------------------------
ALTER TABLE Usuarios
ADD FechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
go
 
CREATE PROCEDURE ObtenerUsuariosPorFechaRegistro
    @FechaInicio DATETIME,
    @FechaFin DATETIME
AS
BEGIN
    SELECT [Login_Usuario], [Clave_Usuario], [Nombre_Usuario]
    FROM [dbo].[Usuarios]
    WHERE FechaRegistro BETWEEN @FechaInicio AND @FechaFin;
END
GO

---------------------------------------------
