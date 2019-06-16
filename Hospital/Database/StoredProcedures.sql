/*==============================================================*/
/* Author name:    Josue Revolorio                    */
/* DBMS name:      SQL Server 2017 (RTM) 14.0.1000.169          */
/* Created on:     06/05/2019 09:47:09 a.m.                     */
/*==============================================================*/



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
create proc ActualizarPaciente
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


/*-------------------------------- Procediminetos Almacenados Table Especialidad-------------------------------------------- */

/*------- Mostrar Especialidades ------- */
create proc MostrarEspecialidad
as
select id_Especialidad from Especialidad
GO


/*-------------------------------- Procediminetos Almacenados Table de Doctores---------------------------------------------- */

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


*-------------------------------- Procediminetos Almacenados Table Precio-------------------------------------------- */

/*------- Mostrar precios ------- */
create proc MostrarPrecio
@Condicion nvarchar(30)
as
select *from Precio where id_Precio like @Condicion+'%' or Tipo like @Condicion+'%' 
GO


/*-------------------------------- Procediminetos Almacenados Table Visita-------------------------------------------- */

/*------- Registar Visita ------- */
create proc RegistrarVisita
@id_Paciente INT,
@id_Doctor INT,
@id_Precio INT,
@Fecha_Salida SMALLDATETIME,
@Cama INT
as
insert into Visita values (@id_Paciente,@id_Doctor,@id_Precio,GETDATE(),@Fecha_Salida,@Cama)
GO

/*------- Consultar Visita ------- */
create proc MostrarVisita
@Condicion nvarchar(30)
as
select P.id_Paciente, P.Nombre as Paciente, D.id_Doctor, D.Nombre as Doctor, E.Especializacion, V.id_Visita From visita as v
inner join Paciente as P on  P.id_Paciente= v.id_Paciente 
inner join Doctor as D on  D.id_Doctor= v.id_Doctor 
inner join Precio as Pr on  Pr.id_Precio= V.id_Precio   
inner join Especialidad as E on E.id_Especialidad = D.id_Especialidad where P.id_Paciente like @Condicion+'%' or P.Nombre  like @Condicion+'%' 
Go


/*------- Consultar Completa ------- */
create proc VisitaCmpleta
@Condicion nvarchar(30)
as
select P.id_Paciente,  V.id_Visita, P.Nombre, P.Apellido, P.Nit, V.Fecha_Salida, Pr.Tipo, Pr.Costo From visita as v
inner join Paciente as P on  P.id_Paciente= v.id_Paciente 
inner join Doctor as D on  D.id_Doctor= v.id_Doctor 
inner join Precio as Pr on  Pr.id_Precio= V.id_Precio   
inner join Especialidad as E on E.id_Especialidad = D.id_Especialidad where P.id_Paciente like @Condicion+'%' or P.Nombre  like @Condicion+'%' 
Go



/*-------------------------------- Procediminetos Almacenados Table Historia-------------------------------------------- */

/*------- Registar Historial ------- */
create proc RegistrarHistorial
@id_Paciente INT,
@id_Doctor INT,
@id_Visita INT,
@Sintomas VARCHAR(600),
@Diagnostico VARCHAR(600),
@Tratamiento VARCHAR(400)
as
insert into Historial values (@id_Paciente,@id_Doctor,@id_Visita,@Sintomas,@Diagnostico,@Tratamiento)
GO


/*------- Mostrar Historial ------- */
create proc MostrarHistorial
@Condicion nvarchar(30)
as
select h.id_Historial, P.id_Paciente, P.Nombre as Paciente, D.id_Doctor, D.Nombre as Doctor, V.id_Visita, E.Especializacion,H.Sintomas, H.Diagnostico, H.Tratamiento  from Historial as H
inner join Paciente as P on P.id_Paciente = H.id_Paciente
inner join Doctor as D on D.id_Doctor = H.id_Doctor
inner join Visita as V on V.id_Visita = H.id_Visita
inner join Especialidad as E on E.id_Especialidad = D.id_Especialidad where P.id_Paciente like @Condicion+'%' or P.Nombre  like @Condicion+'%'
Go

/*------- Actulizar Historial ------- */
create proc ActulizarHistorial
@id_Paciente INT,
@id_Doctor INT,
@id_Visita INT,
@Sintomas VARCHAR(600),
@Diagnostico VARCHAR(600),
@Tratamiento VARCHAR(400),
@id int
as
update Historial set id_Paciente = @id_Paciente, id_Doctor = @id_Doctor, id_Visita = @id_Visita, Sintomas = @Sintomas, Diagnostico = @Diagnostico, Tratamiento = @Tratamiento where id_Historial = @id;
GO



/*-------------------------------- Procediminetos Almacenados Facturacion---------------------------------------------- */

CREATE PROC RegistrarFactura
@id_Paciente INT,
@id_Visita INT
as
insert into Factura values (@id_Paciente, @id_Visita);
GO

exec RegistrarFactura 110,103

CREATE PROC idMaximo
as
select max(id_factura) from Factura
GO


Select F.id_factura As No_Factura,V.Fecha_Salida as Fecha, P.id_Paciente, P.Nombre,P.Apellido, P.Nit From Factura as F
inner join Paciente as P on P.id_Paciente = F.id_Paciente
inner join Visita as V on V.id_Visita = F.id_Visita




Select *from Usuario Where NombreLogin = 'Admin' and Contraseña = 'Admin205'




/*-------------------------------- Procediminetos Almacenados Usuarios---------------------------------------------- */
CREATE PROC LoginUsiario
@NombreLogin VARCHAR(60),
@Contraseña VARCHAR(60)
as
Select *from Usuario Where NombreLogin = @NombreLogin and Contraseña = @Contraseña
GO