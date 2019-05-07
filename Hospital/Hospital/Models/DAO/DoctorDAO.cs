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
    class DoctorDAO: DBConexion
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

        public List<DoctorDTO> MostarRegistros(String Condicion)
        {
            //Data Access object
            comando.Connection = Conexion;
            Conexion.Open();

            comando.CommandText = "ConsultaDoctor";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Condicion", Condicion);
            leer = comando.ExecuteReader();

            //Data transfer Object
            List<DoctorDTO> list = new List<DoctorDTO>();
            while (leer.Read())
            {
               list.Add(new DoctorDTO
                {
                   Id_Doctor = leer.GetInt32(0),
                   Nombre = leer.GetString(1),
                   Apellido = leer.GetString(2),
                   DPI = leer.GetString(3),
                   Telefono = leer.GetInt32(4),
                   Especializacion = leer.GetString(5),
                   Id_Epecialidad = leer.GetInt32(6),
               });
            }
            leer.Close();

            comando.Parameters.Clear();
            Conexion.Close();

            return list;
        }

    }
}
