using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models.DTO
{
    class DetalleDTO
    {
        private int idPaciente;
        private int idVisita;
        private string nombre;
        private string apellido;
        private string nit;
        private string fechaSalida;
        private string tipo;
        private int costo;

        public int IdPaciente { get => idPaciente; set => idPaciente = value; }
        public int IdVisita { get => idVisita; set => idVisita = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Nit { get => nit; set => nit = value; }
        public string FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Costo { get => costo; set => costo = value; }
    }
}
