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
    }
}
