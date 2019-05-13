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
    class DoctorBuscadorController
    {
        private DoctorBuscador vista;

        public DoctorBuscadorController(DoctorBuscador vista)
        {
            this.vista = vista;
            vista.Load += new EventHandler(mostrarRegistrosDoctor);
            vista.txtBuscar.TextChanged += new EventHandler(mostrarRegistrosDoctor);
            vista.btnAgregar.Click += new EventHandler(enviarDatos);

        }

        private void mostrarRegistrosDoctor(object sender, EventArgs e)
        {
            DoctorDAO dao = new DoctorDAO();
            vista.TablaBuscar.DataSource = dao.mostarRegistros(vista.txtBuscar.Text);
        }

        private void enviarDatos(object sender, EventArgs e)
        {

            if (vista.TablaBuscar.SelectedRows.Count > 0)
            {

                Visita visita = vista.Owner as Visita;
                visita.txtCodigoDoctor.Text = vista.TablaBuscar.CurrentRow.Cells["id_Doctor"].Value.ToString();
                visita.txtBuscarDoctor.Text = vista.TablaBuscar.CurrentRow.Cells["Nombre"].Value.ToString();

                visita.txtBuscarDoctor.Enabled = false;
                visita.txtCodigoDoctor.Enabled = false;

                vista.Close();
            }
            else
            {
                MessageBox.Show("Seleccione una Fila");
            }

        }
    }
}
