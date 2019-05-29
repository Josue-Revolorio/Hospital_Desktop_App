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
    class FacturaDAO: DBConexion
    {
        private int id;

        public void isertarRegistro(int idPaciente, int idVisita)
        {
            comando.Connection = Conexion;
            Conexion.Open();

            comando.CommandText = "RegistrarFactura";

            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@id_Paciente", idPaciente);
            comando.Parameters.AddWithValue("@id_Visita", idVisita);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            Conexion.Close();
        }

        public void mostrarId()
        {
            comando.Connection = Conexion;
            Conexion.Open();

            comando.CommandText = "RegistrarFactura";

            comando.CommandType = CommandType.StoredProcedure;

            leer = comando.ExecuteReader();

            id = Convert.ToInt32(leer.Read());

            leer.Close();
            comando.Parameters.Clear();
            Conexion.Close();
        }



    }
}
