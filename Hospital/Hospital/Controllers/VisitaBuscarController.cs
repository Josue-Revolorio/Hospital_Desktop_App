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
    class VisitaBuscarController
    {
        VisitaBuscar vista;

        public VisitaBuscarController(VisitaBuscar vista)
        {
            this.vista = vista;
            vista.Load += new EventHandler(mostrarRegistrosTipo);
            vista.txtBuscar.TextChanged += new EventHandler(mostrarRegistrosTipo);
            vista.btnAgregar.Click += new EventHandler(enviarDatos);
        }

        private void mostrarRegistrosTipo(object sender, EventArgs e)
        {
            VisitaDAO dao = new VisitaDAO();
            vista.TablaBuscar.DataSource = dao.mostrarRegistros(vista.txtBuscar.Text);
        }

        private void enviarDatos(object sender, EventArgs e)
        {

            if (vista.TablaBuscar.SelectedRows.Count > 0)
            {

                Historial historial = vista.Owner as Historial;
                historial.txtCodigoPaciente.Text = vista.TablaBuscar.CurrentRow.Cells["id_Paciente"].Value.ToString();
                historial.txtPaciente.Text = vista.TablaBuscar.CurrentRow.Cells["Paciente"].Value.ToString();
                historial.txtCodigoDoctor.Text = vista.TablaBuscar.CurrentRow.Cells["id_Doctor"].Value.ToString();
                historial.txtDoctor.Text = vista.TablaBuscar.CurrentRow.Cells["Doctor"].Value.ToString();
                historial.txtEspecializacion.Text = vista.TablaBuscar.CurrentRow.Cells["Especializacion"].Value.ToString();
                historial.txtCodigoVisita.Text = vista.TablaBuscar.CurrentRow.Cells["id_Visita"].Value.ToString();


                historial.txtCodigoPaciente.Enabled = false;
                historial.txtPaciente.Enabled = false;
                historial.txtCodigoDoctor.Enabled = false;
                historial.txtDoctor.Enabled = false;
                historial.txtEspecializacion.Enabled = false;
                historial.txtCodigoVisita.Enabled = false;

                vista.Close();
            }
            else
            {
                MessageBox.Show("Seleccione una Fila");
            }

        }

    }
}
