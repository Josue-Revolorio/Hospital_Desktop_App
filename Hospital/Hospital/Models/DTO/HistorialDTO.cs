using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models.DTO
{
    class HistorialDTO
    {
        private int id_Registro;
        private int id_Paciente;
        private string paciente;
        private int id_Doctor;
        private string doctor;
        private int id_Visita;
        private string especializacion;
        private string sintomas;
        private string diagnostico;
        private string tratamiento;

        public int Id_Registro { get => id_Registro; set => id_Registro = value; }
        public int Id_Paciente { get => id_Paciente; set => id_Paciente = value; }
        public string Paciente { get => paciente; set => paciente = value; }
        public int Id_Doctor { get => id_Doctor; set => id_Doctor = value; }
        public string Doctor { get => doctor; set => doctor = value; }
        public int Id_Visita { get => id_Visita; set => id_Visita = value; }
        public string Especializacion { get => especializacion; set => especializacion = value; }
        public string Sintomas { get => sintomas; set => sintomas = value; }
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }
        public string Tratamiento { get => tratamiento; set => tratamiento = value; }
    }
}
