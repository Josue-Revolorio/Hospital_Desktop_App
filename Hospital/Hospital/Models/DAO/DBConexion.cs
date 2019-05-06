using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Hospital.Models.DAO
{
    public class DBConexion
    {
        protected SqlDataReader leer;
        protected SqlCommand comando = new SqlCommand();
        protected SqlConnection Conexion = new SqlConnection("Server = (local); DataBase=HospitalUMG;;Integrated Security = true");
    }
}
