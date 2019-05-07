using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models.DTO
{
    class DoctorDTO
    {
        int id_Doctor;
        string nombre;
        string apellido;
        string _DPI;
        int telefono;
        string especializacion;
        int id_Epecialidad;

        public int Id_Doctor { get => id_Doctor; set => id_Doctor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string DPI { get => _DPI; set => _DPI = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Especializacion { get => especializacion; set => especializacion = value; }
        public int Id_Epecialidad { get => id_Epecialidad; set => id_Epecialidad = value; }
    }
}
