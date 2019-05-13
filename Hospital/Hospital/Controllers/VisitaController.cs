using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hospital.Views;
using Hospital.Models.DAO;
using Hospital.Models.DTO;
using View;

namespace Hospital.Controllers
{
    class VisitaController
    {
        private Visita vista;

        public VisitaController(Visita vista)
        {
            this.vista = vista;
            vista.btnBuscarPaciente.Click += new EventHandler(abrirFormulario);
            vista.btnCerrarformulario.Click += new EventHandler(cerraFormulario);
        }


        private void abrirFormulario(object sender, EventArgs e)
        {
            BuscadorPacientes paciente = new BuscadorPacientes();
            vista.AddOwnedForm(paciente);
            paciente.Show();
        }

        private void cerraFormulario(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar el formulario?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                vista.Close();
            }
        }

    }

}
