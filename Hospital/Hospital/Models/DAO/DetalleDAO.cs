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
    class DetalleDAO: DBConexion
    {
        public List<DetalleDTO> mostrarRegistros(string Condicion)
        {
            //Data Access object
            comando.Connection = Conexion;
            Conexion.Open();

            comando.CommandText = "VisitaCmpleta";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Condicion", Condicion);

            leer = comando.ExecuteReader();

            //Data transfer Object
            List<DetalleDTO> ListaGenerica = new List<DetalleDTO>();

            while (leer.Read())
            {
                ListaGenerica.Add(new DetalleDTO
                {
                    IdPaciente = leer.GetInt32(0),
                    IdVisita = leer.GetInt32(1),
                    Nombre = leer.GetString(2),
                    Apellido = leer.GetString(3),
                    Nit = leer.GetString(4),
                    FechaSalida = Convert.ToString(leer.GetDateTime(5)),
                    Tipo = leer.GetString(6),
                   Costo = leer.GetInt32(7)
                });
            }

            leer.Close();
            comando.Parameters.Clear();
            Conexion.Close();
            return ListaGenerica;
        }
    }
}
