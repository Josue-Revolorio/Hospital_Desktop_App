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
    public class DoctorDAO: DBConexion
    {
        public List<string> itemEspecialidad()
        {
            comando.Connection = Conexion;
            Conexion.Open();

            comando.CommandText = "MostrarEspecialidad";
            comando.CommandType = CommandType.StoredProcedure;

            leer = comando.ExecuteReader();

            List<string> item = new List<string>();

            while (leer.Read())
            {
                item.Add(leer["id_Especialidad"].ToString());
            }
            leer.Close();

            comando.Parameters.Clear();
            Conexion.Close();
            return item;
        }


    }
}
