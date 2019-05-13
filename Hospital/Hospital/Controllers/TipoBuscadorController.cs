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
    class TipoBuscadorController
    {
        TipoBuscador vista;

        public TipoBuscadorController(TipoBuscador vista)
        {
            this.vista = vista;
            vista.Load += new EventHandler(mostrarRegistrosTipo);
            vista.txtBuscar.TextChanged += new EventHandler(mostrarRegistrosTipo);
            vista.btnAgregar.Click += new EventHandler(enviarDatos);
        }

        private void mostrarRegistrosTipo(object sender, EventArgs e)
        {
            PrecioDAO dao = new PrecioDAO();
            vista.TablaBuscar.DataSource = dao.mostrarRegistros(vista.txtBuscar.Text);
        }

        private void enviarDatos(object sender, EventArgs e)
        {

            if (vista.TablaBuscar.SelectedRows.Count > 0)
            {

                Visita visita = vista.Owner as Visita;
                visita.txtCodigoTipo.Text = vista.TablaBuscar.CurrentRow.Cells["Id_Precio"].Value.ToString();
                visita.txtBuscarTipo.Text = vista.TablaBuscar.CurrentRow.Cells["Tipo"].Value.ToString();
                visita.txtPrecio.Text = vista.TablaBuscar.CurrentRow.Cells["Costo"].Value.ToString();

                visita.txtBuscarTipo.Enabled = false;
                visita.txtCodigoTipo.Enabled = false;
                visita.txtPrecio.Enabled = false;


                vista.Close();
            }
            else
            {
                MessageBox.Show("Seleccione una Fila");
            }

        }
    }
}
