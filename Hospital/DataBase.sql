/*==============================================================*/
/* Author name:    Josue Revolorio                    */
/* DBMS name:      SQL Server 2017 (RTM) 14.0.1000.169          */
/* Created on:     06/05/2019 09:47:09 a.m.                     */
/*==============================================================*/

/*------- Creando Base de Datos------- */
CREATE DATABASE HospitalUMG;
GO

USE HospitalUMG;
GO

/*------------------------------------ Tabla Pacientes -------------------------------------- */
CREATE TABLE Paciente
(
id_Paciente INT IDENTITY(101,1) primary Key,
Nombre VARCHAR(25) NOT NULL,
Apellido VARCHAR(25) NOT NULL,
Birthdate DATE NOT NULL,
DPI VARCHAR(14) NOT NULL UNIQUE,
Direccion VARCHAR(90) NOT NULL,
Telefono INT NOT NULL,
Nit VARCHAR(15) NOT NULL,
Sexo VARCHAR (4) NOT NULL CHECK (Sexo IN ('M', 'F')) 
);
GO

/*------- Inserciones------- */
INSERT INTO Paciente VALUES('Juan Manuel','Perez Lopez','1994/05/21','4851247859585','46 Calle 201-53 Zona 12 Guatemala',45623596,'451254-1','M');
INSERT INTO Paciente VALUES('Alma Celeste','Garcia Lopez','1982/04/05','4851247857485','41 Calle 2-53 Zona 12 Guatemala',45633586,'451254-1','F');
INSERT INTO Paciente VALUES('Eli Rafael','Lopez Gonzalez','1991/10/08','7451247859585','46 Calle 01-53 Zona 1 Guatemala',35623596,'451254-1','M');
INSERT INTO Paciente VALUES('Sofia Maria','Perez Lopez','1994/05/21','7851247859585','42 Calle 201-53 Zona 12 Guatemala',45623596,'451254-1','F');
INSERT INTO Paciente VALUES('Elmer Alejandro','Perez Lopez','1994/05/21','3851247859585','44 Calle 201-53 Zona 12 Guatemala',45623596,'451254-1','M');
INSERT INTO Paciente VALUES('Juan Alexander','Perez Lopez','1994/05/21','2851247859585','4 Calle 201-53 Zona 12 Guatemala',45623596,'451254-1','M');
GO

/*-------------------------------- Procediminetos Almacenados Tabla de Pacientes -------------------------------------------- */


/*------- Mostrar Pacientes y Consultarlos ------- */
CREATE PROC ConsultaPacientes
@Condicion nvarchar(30)
as
select *from Paciente where id_Paciente like @Condicion+'%' or Nombre like @Condicion+'%' 
GO

/*------- Registrar un nuevo Paciente ------- */
CREATE PROC RegistrarPaciente
@nombre VARCHAR(25),
@apellido VARCHAR(25),
@birthdate DATE,
@dpi VARCHAR(14),
@direccion VARCHAR(90),
@telefono INT,
@nit VARCHAR(15),
@sexo VARCHAR (4)
as
insert into Paciente values (@nombre,@apellido,@birthdate,@dpi,@direccion,@telefono,@nit,@sexo)
GO

/*------- Actualizar los registros de Pacientes ------- */
CREATE PROC ActualizarPaciente
@nombre VARCHAR(25),
@apellido VARCHAR(25),
@birthdate DATE,
@dpi VARCHAR(14),
@direccion VARCHAR(90),
@telefono INT,
@nit VARCHAR(15),
@sexo VARCHAR (4),
@id INT
as
update Paciente set Nombre = @nombre, Apellido = @apellido, Birthdate = @birthdate, DPI = @dpi, Direccion = @direccion, Telefono = @telefono, Nit = @nit, Sexo=@sexo where id_Paciente = @id;
GO

/*------- Eliminar Registro de Pacientes ------- */
create proc EliminarPaciente
@id int
as
delete from Paciente where id_Paciente=@id
GO

/*------------------------------------ Tabla Especialidad -------------------------------------- */
CREATE TABLE Especialidad
(
id_Especialidad INT IDENTITY(101,1) primary Key,
Especializacion VARCHAR(30)
);
GO


/*------- Inserciones------- */
INSERT INTO Especialidad VALUES
('cirugía vascular'),('Odontología'),('Medico General'),
('Dermatología'),('Ginecología'),('Oftalmología'),('Otorrinolaringología'),('Urología'),('Traumatología'),
('Endocrinología'),('Gastroenterología'),('Cardiología'),('Anestesiología');
Go


/*-------------------------------- Procediminetos Almacenados Table Especialidad-------------------------------------------- */

/*------- Mostrar Especialidades ------- */
create proc MostrarEspecialidad
as
select id_Especialidad from Especialidad
GO


/*--------------------------------------- Tabla Doctor ------------------------------------------ */
CREATE TABLE Doctor
(
id_Doctor INT IDENTITY(101,1) primary Key,
id_Especialidad INT,
Nombre VARCHAR(25) NOT NULL,
Apellido VARCHAR(25) NOT NULL,
DPI VARCHAR(14) NOT NULL UNIQUE,
Telefono INT NOT NULL,
CONSTRAINT fk_id_Especialidad FOREIGN KEY (id_Especialidad) REFERENCES Especialidad (id_Especialidad)
);
GO


/*------- Inserciones------- */
INSERT INTO Doctor VALUES(103, 'Juan Carlos', 'Rosales Montes', '8596693556245', 85966998);
INSERT INTO Doctor VALUES(104, 'Manuel Meleon', 'Rosales Perez', '8576693556245', 85966998);
Go


/*-------------------------------- Procediminetos Almacenados Table de Doctores-------------------------------------------- */

/*------- Mostrar Doctor y Especialidad ------- */
create proc ConsultaDoctor
@Condicion nvarchar(30)
as
select d.id_Doctor, D.Nombre, D.Apellido, D.DPI, D.Telefono, E.Especializacion, E.id_Especialidad from Doctor as D
inner join  Especialidad as E on  D.id_Especialidad = E.id_Especialidad where D.id_Doctor like @Condicion+'%' or D.Nombre like @Condicion+'%' ;
GO

/*------- Registrar Doctor ------- */
CREATE PROC RegistrarDoctor
@id_Especialidad INT,
@nombre VARCHAR(25),
@apellido VARCHAR(25),
@dpi VARCHAR(14),
@telefono INT
as
insert into Doctor values (@id_Especialidad,@nombre,@apellido,@dpi,@telefono)
GO

/*------- Actualizar los registros de Doctores ------- */
CREATE PROC ActualizarDoctor
@id_Especialidad INT,
@nombre VARCHAR(25),
@apellido VARCHAR(25),
@dpi VARCHAR(14),
@telefono INT,
@id INT
as
update Doctor set id_Especialidad = @id_Especialidad, Nombre = @nombre, Apellido = @apellido, DPI = @dpi, Telefono = @telefono where id_Doctor = @id;
GO

/*------- Eliminar los registros de Doctores ------- */
create proc EliminarDoctor
@id int
as
delete from Doctor where id_Doctor=@id
GO


/*--------------------------------------- Tabla de Precios ------------------------------------------ */
CREATE TABLE Precio
(
id_Precio INT IDENTITY(101,1) primary Key,
Tipo VARCHAR(30) NOT NULL,
Costo INT NOT NULL,
);
GO

/*------- Inserciones------- */
INSERT INTO Precio VALUES('Consulta General', 90);
INSERT INTO Precio VALUES('Consulta Especialidad', 200);
INSERT INTO Precio VALUES('Cirugia Vascular', 11000);
INSERT INTO Precio VALUES('Cirugia de piel', 8500);
INSERT INTO Precio VALUES('Cirugia vesicular', 12000);
INSERT INTO Precio VALUES('Traumatologia', 5000);
INSERT INTO Precio VALUES('Triquiasis', 9500);
INSERT INTO Precio VALUES('Cirugia de Cataratas', 13500);
INSERT INTO Precio VALUES('Cirugia Osteotomia', 6000);
INSERT INTO Precio VALUES('Cirugia Adenoidectomia', 9000);
INSERT INTO Precio VALUES('Extraccion de Quiste', 2500);
GO

/*--------------------------------------- Tabla de Precios ------------------------------------------ */

CREATE TABLE Visita
(
id_Visita INT IDENTITY(101,1) primary Key,
id_Paciente INT,
id_Doctor INT,
id_Precio INT,
Fecha_Ingreso SMALLDATETIME NOT NULL,
Fecha_Salida SMALLDATETIME NOT NULL,
Cama INT,
CONSTRAINT fk_id_Paciente FOREIGN KEY (id_Paciente) REFERENCES Paciente (id_Paciente),
CONSTRAINT fk_id_Doctor  FOREIGN KEY (id_Doctor) REFERENCES Doctor (id_Doctor),
CONSTRAINT fk_id_Precio FOREIGN KEY (id_Precio) REFERENCES Precio (id_Precio)
);
GO

INSERT INTO Visita VALUES(102,103,101,GETDATE(),'2019/05/11',1);

select *from Visita


select  p.Nombre, D.Nombre, pr.Tipo, pr.Costo, v.Fecha_Salida From visita as v
inner join Paciente as P on  P.id_Paciente= v.id_Paciente 
inner join Doctor as D on  D.id_Doctor= v.id_Doctor 
inner join Precio as Pr on  Pr.id_Precio= V.id_Precio   



Select * From Doctor