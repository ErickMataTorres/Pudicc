CREATE DATABASE PudiccBD
--------------------------------------------
CREATE TABLE Usuario
(
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL,
	Usuario VARCHAR(100) NOT NULL,
	Contrasena VARCHAR(100) NOT NULL
)
CREATE PROCEDURE spLogin
@Usuario VARCHAR(100),
@Contrasena VARCHAR(100)
AS
BEGIN
	IF EXISTS(SELECT Usuario, Contrasena FROM Usuario WHERE Usuario=@Usuario AND Contrasena=@Contrasena)
	BEGIN
		SELECT 'Ok' AS [Respuesta]
	END
	ELSE
	BEGIN
		SELECT 'Usuario o contraseña incorrecto' AS [Respuesta]
	END
END
--------------------------------------------

CREATE TABLE Publicacion
(
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	Titulo VARCHAR(300) NOT NULL,
	Descripcion VARCHAR(1000) NOT NULL,
	Imagen VARCHAR(1000),
	IdTipo INT NOT NULL REFERENCES Tipo(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
)

ALTER PROCEDURE spCardsPublicacion
@IdTipo INT
AS
BEGIN
	SELECT Publicacion.*, Tipo.Nombre FROM Publicacion INNER JOIN Tipo ON Publicacion.IdTipo=Tipo.Id WHERE Publicacion.IdTipo=@IdTipo ORDER BY ID DESC
END

ALTER PROCEDURE spGuardarPublicacion
@Id INT,
@Titulo VARCHAR(300),
@Descripcion VARCHAR(1000),
@Imagen VARCHAR(1000),
@IdTipo INT
AS
BEGIN
	IF NOT EXISTS(SELECT Id FROM Publicacion WHERE Id=@Id)
	BEGIN
		INSERT INTO Publicacion (Titulo, Descripcion, Imagen, IdTipo) VALUES (@Titulo, @Descripcion, @Imagen, @IdTipo)
	END
	ELSE
	BEGIN
		UPDATE Publicacion SET Titulo=@Titulo, Descripcion=@Descripcion, Imagen=@Imagen, IdTipo=@IdTipo WHERE Id=@Id
	END
END


--------------------------------------------


CREATE TABLE Tipo
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Nombre VARCHAR(100) NOT NULL
)
CREATE PROCEDURE spListaTipos
AS
BEGIN
	SELECT * FROM Tipo ORDER BY Nombre
END
--------------------------------------------