using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    class PacienteBuscardorController
    {
        private PacienteBuscador vista;

        public PacienteBuscardorController(PacienteBuscador vista)
        {
            this.vista = vista;
            vista.Load += new EventHandler(mostrarRegistrosPaciente);
            vista.txtBuscar.TextChanged += new EventHandler(mostrarRegistrosPaciente);
            vista.btnAgregar.Click += new EventHandler(enviarDatos);
        }

        private void mostrarRegistrosPaciente(object sender, EventArgs e)
        {
            PacienteDAO dao = new PacienteDAO();
            vista.TablaBuscar.DataSource = dao.mostrarRegistros(vista.txtBuscar.Text);
        }

        private void enviarDatos(object sender, EventArgs e)
        {

            if (vista.TablaBuscar.SelectedRows.Count > 0)
            {

                Visita visita = vista.Owner as Visita;
                visita.txtCodigoPaciente.Text = vista.TablaBuscar.CurrentRow.Cells["Id"].Value.ToString();
                visita.txtBuscarPaciente.Text = vista.TablaBuscar.CurrentRow.Cells["Nombre"].Value.ToString();

                visita.txtBuscarPaciente.Enabled = false;
                visita.txtCodigoPaciente.Enabled = false;

                vista.Close();
            }
            else
            {
                MessageBox.Show("Seleccione una Fila");
            }

        }
    }
}
