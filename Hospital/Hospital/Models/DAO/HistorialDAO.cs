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
    class HistorialDAO: DBConexion
    {
        public List<HistorialDTO> mostrarRegistros(string Condicion)
        {
            //Data Access object
            comando.Connection = Conexion;
            Conexion.Open();

            comando.CommandText = "MostrarHistorial";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Condicion", Condicion);

            leer = comando.ExecuteReader();

            //Data transfer Object
            //Lista generica 
            List<HistorialDTO> ListaGenerica = new List<HistorialDTO>();

            while (leer.Read())
            {
                ListaGenerica.Add(new HistorialDTO
                {
                    Id_Registro = leer.GetInt32(0),
                    Id_Paciente = leer.GetInt32(1),
                    Paciente = leer.GetString(2),
                    Id_Doctor = leer.GetInt32(3),
                    Doctor = leer.GetString(4),
                    Id_Visita = leer.GetInt32(5),
                    Especializacion = leer.GetString(6),
                    Sintomas = leer.GetString(7),
                    Diagnostico = leer.GetString(8),
                    Tratamiento = leer.GetString(9),
                });
            }

            leer.Close();
            comando.Parameters.Clear();
            Conexion.Close();
            return ListaGenerica;

        }

        public void isertarRegistro(int idPaciente, int idDoctor, int idVisita, string sintomas, string diagnostico, string tratamiento)
        {
            comando.Connection = Conexion;
            Conexion.Open();

            comando.CommandText = "RegistrarHistorial";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@id_Paciente", idPaciente);
            comando.Parameters.AddWithValue("@id_Doctor", idDoctor);
            comando.Parameters.AddWithValue("@id_Visita", idVisita);
            comando.Parameters.AddWithValue("@Sintomas", sintomas);
            comando.Parameters.AddWithValue("@Diagnostico", diagnostico);
            comando.Parameters.AddWithValue("@Tratamiento", tratamiento);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            Conexion.Close();
        }


        public void actualizarRegistro(int idPaciente, int idDoctor, int idVisita, string sintomas, string diagnostico, string tratamiento, int id)
        {
            comando.Connection = Conexion;
            Conexion.Open();

            comando.CommandText = "ActulizarHistorial";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@id_Paciente", idPaciente);
            comando.Parameters.AddWithValue("@id_Doctor", idDoctor);
            comando.Parameters.AddWithValue("@id_Visita", idVisita);
            comando.Parameters.AddWithValue("@Sintomas", sintomas);
            comando.Parameters.AddWithValue("@Diagnostico", diagnostico);
            comando.Parameters.AddWithValue("@Tratamiento", tratamiento);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            Conexion.Close();
        }


    }
}
