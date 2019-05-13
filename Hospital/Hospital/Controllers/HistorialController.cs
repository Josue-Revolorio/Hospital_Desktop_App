using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hospital.Views;
using Hospital.Models.DAO;
using Hospital.Models.DTO;
using View;

namespace Hospital.Controllers
{
    class HistorialController
    {
        private Historial vista;
        private Boolean Actualizar = false;

        public HistorialController(Historial vista)
        {
            this.vista = vista;
            vista.Load += new EventHandler(Diseño);
            vista.btnCerrarformulario.Click += new EventHandler(cerrarFormulario);
            vista.btnNuevo.Click += new EventHandler(abrirFormulario);
            vista.btnGuardar.Click += new EventHandler(guardarRegistro);
            vista.btnAbrir.Click += new EventHandler(abrirFormulario);
        }


        private void Diseño(object sender, EventArgs e)
        {
            this.vista.txtSintomas.AutoSize = false;
            vista.txtSintomas.Size = new Size(300, 70);
            vista.txtSintomas.ScrollBars = ScrollBars.Both;

            this.vista.txtDiagnostico.AutoSize = false;
            vista.txtDiagnostico.Size = new Size(300, 70);
            vista.txtDiagnostico.ScrollBars = ScrollBars.Both;

            this.vista.txtTratamiento.AutoSize = false;
            vista.txtTratamiento.Size = new Size(300, 70);
            vista.txtTratamiento.ScrollBars = ScrollBars.Both;

            vista.txtCodigoHistorial.Enabled = false;
            vista.txtCodigoPaciente.Enabled = false;
            vista.txtCodigoDoctor.Enabled = false;
            vista.txtCodigoVisita.Enabled = false;

        }

        private void cerrarFormulario(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar el formulario?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                vista.Close();
            }
        }

        private void abrirFormulario(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Name == "btnNuevo")
            {
                Actualizar = false;
                VisitaBuscar visita = new VisitaBuscar();
                vista.AddOwnedForm(visita);
                visita.Show();
            }

            if (((PictureBox)sender).Name == "btnAbrir")
            {
                Actualizar = true;
                HistorialBuscar historial = new HistorialBuscar();
                vista.AddOwnedForm(historial);
                historial.Show();
            }

        }

        private void guardarRegistro(object sender, EventArgs e)
        {
            HistorialDAO dao = new HistorialDAO();
            if (Actualizar == false)
            {
                dao.isertarRegistro(Convert.ToInt32(vista.txtCodigoPaciente.Text), Convert.ToInt32(vista.txtCodigoDoctor.Text), Convert.ToInt32(vista.txtCodigoVisita.Text), vista.txtSintomas.Text, vista.txtDiagnostico.Text, vista.txtTratamiento.Text);
                MessageBox.Show("Registro Guardado");
            }
            if (Actualizar == true)
            {
                dao.actualizarRegistro(Convert.ToInt32(vista.txtCodigoPaciente.Text), Convert.ToInt32(vista.txtCodigoDoctor.Text), Convert.ToInt32(vista.txtCodigoVisita.Text), vista.txtSintomas.Text, vista.txtDiagnostico.Text, vista.txtTratamiento.Text, Convert.ToInt32(vista.txtCodigoHistorial.Text));
                MessageBox.Show("Registro Actulizado");
            }
            limpiar();
        }

        private void limpiar()
        {
            vista.txtCodigoDoctor.Clear();
            vista.txtCodigoHistorial.Clear();
            vista.txtCodigoPaciente.Clear();
            vista.txtCodigoVisita.Clear();
            vista.txtDiagnostico.Clear();
            vista.txtDoctor.Clear();
            vista.txtEspecializacion.Clear();
            vista.txtPaciente.Clear();
            vista.txtSintomas.Clear();
            vista.txtTratamiento.Clear();

        }

    }
}
