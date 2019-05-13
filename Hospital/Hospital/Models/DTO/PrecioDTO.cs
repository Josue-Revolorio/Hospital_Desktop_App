using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models.DTO
{
    class PrecioDTO
    {
        private int id_Precio;
        private string tipo;
        private int costo;

        public int Id_Precio { get => id_Precio; set => id_Precio = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Costo { get => costo; set => costo = value; }
    }
}
