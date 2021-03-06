IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'SistemaColegioBD')
BEGIN
	CREATE DATABASE SistemaColegioBD
END
GO

USE SistemaColegioBD
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PERIODOS')
BEGIN
	CREATE TABLE PERIODOS
	(
		Id INT IDENTITY PRIMARY KEY NOT NULL,
		Nombre VARCHAR(50) NOT NULL
	)
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ASIGNATURAS')
BEGIN
	CREATE TABLE ASIGNATURAS
	(
		Id INT IDENTITY PRIMARY KEY NOT NULL,
		Nombre VARCHAR(50) NOT NULL
	)
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ESTUDIANTES')
BEGIN
	CREATE TABLE ESTUDIANTES
	(
		Id INT IDENTITY PRIMARY KEY NOT NULL,
		PrimerNombre VARCHAR(50) NOT NULL,
		SegundoNombre VARCHAR(50) NULL,
		PrimerApellido VARCHAR(50) NOT NULL,
		SegundoApellido VARCHAR(50) NULL,
		Direccion Varchar(100) NOT NULL,
		FechaNacimiento Date NOT NULL
	)
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'NOTAS')
BEGIN
	CREATE TABLE NOTAS
	(
		Id INT IDENTITY PRIMARY KEY NOT NULL,
		Nota INT NOT NULL,
		IdEstudiante INT NOT NULL,
		IdAsignatura INT NOT NULL,
		IdPeriodo INT NOT NULL,
		Fecha Date NOT NULL,
		CONSTRAINT FK_ESTUDIANTES FOREIGN KEY (IdEstudiante) REFERENCES ESTUDIANTES (Id),
		CONSTRAINT FK_ASIGNATURAS FOREIGN KEY (IdAsignatura) REFERENCES ASIGNATURAS (Id),
		CONSTRAINT FK_PERIODO FOREIGN KEY (IdPeriodo) REFERENCES PERIODOS (Id)
	)
END
GO

CREATE VIEW NOTAS_ESTUDIANTES_VIEW 
AS
SELECT NOTAS.Id, NOTAS.Nota, NOTAS.Fecha, IdEstudiante, ESTUDIANTES.PrimerNombre + ' ' + ESTUDIANTES.SegundoNombre + ' ' + ESTUDIANTES.PrimerApellido + ' ' + ESTUDIANTES.SegundoApellido Estudiante,
		IdAsignatura, ASIGNATURAS.Nombre Asignatura, IdPeriodo, PERIODOS.Nombre Periodo
FROM NOTAS INNER JOIN ESTUDIANTES ON NOTAS.IdEstudiante = ESTUDIANTES.Id
			INNER JOIN ASIGNATURAS ON NOTAS.IdAsignatura = ASIGNATURAS.Id
			INNER JOIN PERIODOS ON NOTAS.IdPeriodo = PERIODOS.Id
GO

CREATE VIEW ESTUDIANTES_VIEW
AS

SELECT Id, PrimerNombre + ' ' + SegundoNombre + ' ' + PrimerApellido + ' ' + SegundoApellido Nombre, Direccion, FechaNacimiento FROM ESTUDIANTES
GO
