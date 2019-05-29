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
    class LoginDAO:DBConexion
    {
        public bool ValidarLogin(string user , string pass)
        {
            comando.Connection = Conexion;
            Conexion.Open();

            comando.CommandText = "LoginUsiario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NombreLogin", user);
            comando.Parameters.AddWithValue("@Contraseña", pass);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
