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
            vista.btnBuscarDoctor.Click += new EventHandler(abrirFormulario);
            vista.btnBuscarTipo.Click += new EventHandler(abrirFormulario);
            vista.btnCerrarformulario.Click += new EventHandler(cerraFormulario);
            vista.btnGuardar.Click += new EventHandler(registrarVisita);
            vista.btnNuevo.Click += new EventHandler(Limpiar);
        }


        private void abrirFormulario(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Name == "btnBuscarPaciente")
            {
                PacienteBuscador paciente = new PacienteBuscador();
                vista.AddOwnedForm(paciente);
                paciente.Show();
            }

            if (((PictureBox)sender).Name == "btnBuscarDoctor")
            {
                DoctorBuscador doctor = new DoctorBuscador(); 
                vista.AddOwnedForm(doctor);
                doctor.Show();
            }

            if (((PictureBox)sender).Name == "btnBuscarTipo")
            {
                TipoBuscador tipo = new TipoBuscador();
                vista.AddOwnedForm(tipo);
                tipo.Show();
            }
        }

        private void cerraFormulario(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar el formulario?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                vista.Close();
            }
        }

        private void registrarVisita(object sender, EventArgs e)
        {
            /* Convierte de string a Date */
            DateTime date = Convert.ToDateTime(vista.txtDate.Text);
            /*Da Formato a la fecha*/
            string fecha = date.ToString("yyyy/MM/dd");

            VisitaDAO dao = new VisitaDAO();
            dao.isertarRegistro(Convert.ToInt32(vista.txtCodigoPaciente.Text), Convert.ToInt32(vista.txtCodigoDoctor.Text), Convert.ToInt32(vista.txtCodigoTipo.Text), fecha, Convert.ToInt32(vista.txtCama.Text));
            MessageBox.Show("Guardado con exito");

        }

        private void Limpiar(object sender, EventArgs e)
        {
            vista.txtBuscarPaciente.Clear();
            vista.txtCodigoPaciente.Clear();
            vista.txtBuscarDoctor.Clear();
            vista.txtCodigoDoctor.Clear();
            vista.txtPrecio.Clear();
            vista.txtBuscarTipo.Clear();
            vista.txtCodigoTipo.Clear();
        }

    }

}
