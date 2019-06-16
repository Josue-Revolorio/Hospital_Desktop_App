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
GO
INSERT INTO Paciente VALUES('Alma Celeste','Garcia Lopez','1982/04/05','4851247857485','41 Calle 2-53 Zona 12 Guatemala',45633586,'451254-1','F');
GO
INSERT INTO Paciente VALUES('Eli Rafael','Lopez Gonzalez','1991/10/08','7451247859585','46 Calle 01-53 Zona 1 Guatemala',35623596,'451254-1','M');
GO
INSERT INTO Paciente VALUES('Sofia Maria','Perez Lopez','1994/05/21','7851247859585','42 Calle 201-53 Zona 12 Guatemala',45623596,'451254-1','F');
GO
INSERT INTO Paciente VALUES('Elmer Alejandro','Perez Lopez','1994/05/21','3851247859585','44 Calle 201-53 Zona 12 Guatemala',45623596,'451254-1','M');
GO
INSERT INTO Paciente VALUES('Juan Alexander','Perez Lopez','1994/05/21','2851247859585','4 Calle 201-53 Zona 12 Guatemala',45623596,'451254-1','M');
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
GO
INSERT INTO Doctor VALUES(104, 'Manuel Meleon', 'Rosales Perez', '8576693556245', 85966998);
Go


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
GO
INSERT INTO Precio VALUES('Consulta Especialidad', 200);
GO
INSERT INTO Precio VALUES('Cirugia Vascular', 11000);
GO
INSERT INTO Precio VALUES('Cirugia de piel', 8500);
GO
INSERT INTO Precio VALUES('Cirugia vesicular', 12000);
GO
INSERT INTO Precio VALUES('Traumatologia', 5000);
GO
INSERT INTO Precio VALUES('Triquiasis', 9500);
GO
INSERT INTO Precio VALUES('Cirugia de Cataratas', 13500);
GO
INSERT INTO Precio VALUES('Cirugia Osteotomia', 6000);
GO
INSERT INTO Precio VALUES('Cirugia Adenoidectomia', 9000);
GO
INSERT INTO Precio VALUES('Extraccion de Quiste', 2500);
GO


/*--------------------------------------- Tabla de Visita---------------------------------------------- */
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


/*--------------------------------------- Tabla Historial ------------------------------------------ */
CREATE TABLE Historial
(
id_Historial INT IDENTITY(101,1) primary Key,
id_Paciente INT,
id_Doctor INT,
id_Visita INT,
Sintomas VARCHAR(600) NOT NULL,
Diagnostico VARCHAR(600) NOT NULL,
Tratamiento VARCHAR(400) NOT NULL,
CONSTRAINT fK_id_Visita2  FOREIGN KEY(id_Visita) REFERENCES Visita (id_Visita),
CONSTRAINT fK_id_Paciente2 FOREIGN KEY (id_Paciente) REFERENCES Paciente (id_Paciente),
CONSTRAINT fK_id_Doctor2  FOREIGN KEY (id_Doctor) REFERENCES Doctor (id_Doctor),
);
GO


/*--------------------------------------- Tabla Detalles Factura------------------------------------------ */
CREATE TABLE Factura
(
id_factura INT IDENTITY(101,1) primary Key,
id_Paciente INT,
id_Visita INT
CONSTRAINT fK_id_Paciente3 FOREIGN KEY (id_Paciente) REFERENCES Paciente (id_Paciente),
CONSTRAINT fK_id_Visita3  FOREIGN KEY(id_Visita) REFERENCES Visita (id_Visita)
);
GO


/*--------------------------------------- Tabla Usuario------------------------------------------ */

CREATE TABLE Usuario
(
Id_Usuario INT IDENTITY(101,1) primary Key,
NombreLogin VARCHAR(60) NOT NULL,
Contraseña VARCHAR(60) NOT NULL,
Nombre VARCHAR(25) NOT NULL,
Apellido VARCHAR(25) NOT NULL, 
Posicion VARCHAR(25) NOT NULL
);



/*------- Inserciones------- */
INSERT INTO Usuario VALUES('Admin','Admin200','Sergio','Lopez','Gerente');
GO
INSERT INTO Usuario VALUES('Juan','juan2019','Juan','Fernandez','Programador');}
GO
