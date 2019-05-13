using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models.DTO
{
    class DoctorDTO
    {
        private int id_Doctor;
        private string nombre;
        private string apellido;
        private string _DPI;
        private int telefono;
        private string especializacion;
        private int id_Epecialidad;

        public int Id_Doctor { get => id_Doctor; set => id_Doctor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string DPI { get => _DPI; set => _DPI = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Especializacion { get => especializacion; set => especializacion = value; }
        public int Id_Epecialidad { get => id_Epecialidad; set => id_Epecialidad = value; }
    }
}
