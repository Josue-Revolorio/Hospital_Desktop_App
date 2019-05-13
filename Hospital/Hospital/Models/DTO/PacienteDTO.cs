using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models.DTO
{
    class PacienteDTO
    {

        private int id;
        private string nombre;
        private string apellido;
        private string fecha_Nacimiento;
        private string _DPI;
        private string direccion;
        private int telefono;
        private string nit;
        private string sexo;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Fecha_Nacimiento { get => fecha_Nacimiento; set => fecha_Nacimiento = value; }
        public string DPI { get => _DPI; set => _DPI = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Nit { get => nit; set => nit = value; }
        public string Sexo { get => sexo; set => sexo = value; }
    }
}
