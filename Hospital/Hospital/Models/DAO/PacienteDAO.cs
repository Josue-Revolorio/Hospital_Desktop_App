using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Hospital.Models.DTO;

namespace Hospital.Models.DAO
{
    class PacienteDAO: DBConexion
    {
 
        /*----- Metodo Mostrar Registros-----*/
        public List<PacienteDTO> mostrarRegistros(string Condicion)
        {
            //Data Access object
            comando.Connection = Conexion;
            Conexion.Open();

            comando.CommandText = "ConsultaPacientes";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Condicion", Condicion);

            leer = comando.ExecuteReader();

            //Data transfer Object
            //Lista generica 
            List<PacienteDTO> ListaGenerica = new List<PacienteDTO>();

            while (leer.Read())
            {
                ListaGenerica.Add(new PacienteDTO
                {
                    Id = leer.GetInt32(0),
                    Nombre = leer.GetString(1),
                    Apellido = leer.GetString(2),
                    Fecha_Nacimiento = Convert.ToString(leer.GetDateTime(3)),
                    DPI = leer.GetString(4),
                    Direccion = leer.GetString(5),
                    Telefono = leer.GetInt32(6),
                    Nit = leer.GetString(7),
                    Sexo = leer.GetString(8)
                });
            }

            leer.Close();
            comando.Parameters.Clear();
            Conexion.Close();
            return ListaGenerica;
        }

        /*----- Metodo Insertar Registros-----*/
        public void isertarRegistro(string nombre, string apellido, string date, string dpi, string direccion, int telefono, string nit, string sexo)
        {
            comando.Connection = Conexion;
            Conexion.Open();

            comando.CommandText = "RegistrarPaciente";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@birthdate", date);
            comando.Parameters.AddWithValue("@dpi", dpi);
            comando.Parameters.AddWithValue("@direccion", direccion);
            comando.Parameters.AddWithValue("@telefono", telefono);
            comando.Parameters.AddWithValue("@nit", nit);
            comando.Parameters.AddWithValue("@sexo", sexo);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            Conexion.Close();
        }


        /*----- Metodo Actualizar Registros-----*/
        public void editarRegistro(string nombre, string apellido, string date, string dpi, string direccion, int telefono, string nit, string sexo, int id)
        {
            comando.Connection = Conexion;
            Conexion.Open();

            comando.CommandText = "ActualizarPaciente";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@birthdate", date);
            comando.Parameters.AddWithValue("@dpi", dpi);
            comando.Parameters.AddWithValue("@direccion", direccion);
            comando.Parameters.AddWithValue("@telefono", telefono);
            comando.Parameters.AddWithValue("@nit", nit);
            comando.Parameters.AddWithValue("@sexo", sexo);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            Conexion.Close();
        }


        /*----- Metodo Eliminar Registros-----*/
        public void eliminarRegistro(int id)
        {
            comando.Connection = Conexion;
            Conexion.Open();

            comando.CommandText = "EliminarPaciente";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@id", id);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            Conexion.Close();
        }


    }
}
