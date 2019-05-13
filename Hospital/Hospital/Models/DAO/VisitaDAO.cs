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
    class VisitaDAO : DBConexion
    {
        public void isertarRegistro(int idPaciente, int idDoctor, int idPrecio, string fechaSalida, int cama)
        {
            comando.Connection = Conexion;
            Conexion.Open();

            comando.CommandText = "RegistrarVisita";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@id_Paciente", idPaciente);
            comando.Parameters.AddWithValue("@id_Doctor", idDoctor);
            comando.Parameters.AddWithValue("@id_Precio", idPrecio);
            comando.Parameters.AddWithValue("@Fecha_Salida", fechaSalida);
            comando.Parameters.AddWithValue("@Cama", cama);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            Conexion.Close();
        }

        public List<VisitaDTO> mostrarRegistros(string Condicion)
        {
            // Data Access object
            comando.Connection = Conexion;
            Conexion.Open();

            comando.CommandText = "MostrarVisita";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Condicion", Condicion);

            leer = comando.ExecuteReader();

            List<VisitaDTO> lista = new List<VisitaDTO>();

            while (leer.Read())
            {
                lista.Add(new VisitaDTO
                {
                    Id_Paciente = leer.GetInt32(0),
                    Paciente = leer.GetString(1),
                    Id_Doctor = leer.GetInt32(2),
                    Doctor = leer.GetString(3),
                    Especializacion = leer.GetString(4),
                    Id_Visita = leer.GetInt32(5)
                });
            }

            leer.Close();
            comando.Parameters.Clear();
            Conexion.Close();
            return lista;

        }



    }

}
