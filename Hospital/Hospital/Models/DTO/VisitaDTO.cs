using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models.DTO
{
    class VisitaDTO
    {
     
        private int id_Paciente;
        private string paciente;
        private int id_Doctor;
        private string doctor;
        private string especializacion;
        private int id_Visita;
   
        public int Id_Paciente { get => id_Paciente; set => id_Paciente = value; }
        public string Paciente { get => paciente; set => paciente = value; }
        public int Id_Doctor { get => id_Doctor; set => id_Doctor = value; }
        public string Doctor { get => doctor; set => doctor = value; }
        public string Especializacion { get => especializacion; set => especializacion = value; }
        public int Id_Visita { get => id_Visita; set => id_Visita = value; }
    }
}
