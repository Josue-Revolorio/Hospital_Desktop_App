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
    class BuscardorController
    {
        private BuscadorPacientes paciente;

        public BuscardorController(BuscadorPacientes paciente)
        {
            this.paciente = paciente;
            paciente.Load += new EventHandler(mostrarRegistrosPaciente);
            paciente.txtBuscar.TextChanged += new EventHandler(mostrarRegistrosPaciente);
            paciente.btnAgregar.Click += new EventHandler(enviarDatos);
        }

        private void mostrarRegistrosPaciente(object sender, EventArgs e)
        {
            PacienteDAO dao = new PacienteDAO();
            paciente.TablaBuscar.DataSource = dao.mostrarRegistros(paciente.txtBuscar.Text);
        }

        private void enviarDatos(object sender, EventArgs e)
        {

            if (paciente.TablaBuscar.SelectedRows.Count > 0)
            {

                Visita visita = paciente.Owner as Visita;
                visita.txtBuscarPaciente.Text = paciente.TablaBuscar.CurrentRow.Cells["Nombre"].Value.ToString();
                visita.txtCodigoPaciente.Text = paciente.TablaBuscar.CurrentRow.Cells["Id"].Value.ToString();

                paciente.Close();
            }
            else
            {
                MessageBox.Show("Seleccione una Fila");
            }

        }
    }
}
