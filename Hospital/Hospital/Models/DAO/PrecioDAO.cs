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
    class PrecioDAO: DBConexion
    {

        /*----- Metodo Mostrar Registros-----*/
        public List<PrecioDTO> mostrarRegistros(string Condicion)
        {
            //Data Access object
            comando.Connection = Conexion;
            Conexion.Open();

            comando.CommandText = "MostrarPrecio";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Condicion", Condicion);

            leer = comando.ExecuteReader();


            //Data transfer Object
            //Lista generica 
            List<PrecioDTO> precio = new  List<PrecioDTO>();

            while (leer.Read())
            {
                precio.Add(new PrecioDTO
                {
                    Id_Precio = leer.GetInt32(0),
                    Tipo = leer.GetString(1),
                    Costo = leer.GetInt32(2)
                });
            }

            leer.Close();
            comando.Parameters.Clear();
            Conexion.Close();
            return precio;
        }

    }
}
