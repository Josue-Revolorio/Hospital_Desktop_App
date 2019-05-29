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
    class DetalleController
    {
        private Detalle vista;

        public DetalleController(Detalle vista)
        {
            this.vista = vista;
            vista.Load += new EventHandler(mostrarRegistrosTipo);
            vista.txtBuscar.TextChanged += new EventHandler(mostrarRegistrosTipo);
            vista.btnAgregar.Click += new EventHandler(enviarDatos);
        }

        private void mostrarRegistrosTipo(object sender, EventArgs e)
        {
            DetalleDAO dao = new DetalleDAO();
            vista.TablaBuscar.DataSource = dao.mostrarRegistros(vista.txtBuscar.Text);
        }


        private void enviarDatos(object sender, EventArgs e)
        {

            if (vista.TablaBuscar.SelectedRows.Count > 0)
            {

               Facturacion factura = vista.Owner as Facturacion;
                factura.txtCodigoPaciente.Text = vista.TablaBuscar.CurrentRow.Cells["idPaciente"].Value.ToString();
                factura.txtCodigoVisita.Text = vista.TablaBuscar.CurrentRow.Cells["idvisita"].Value.ToString();
                factura.txtNombre.Text = vista.TablaBuscar.CurrentRow.Cells["Nombre"].Value.ToString();
                factura.txtApellido.Text = vista.TablaBuscar.CurrentRow.Cells["Apellido"].Value.ToString();
                factura.txtNit.Text = vista.TablaBuscar.CurrentRow.Cells["Nit"].Value.ToString();
                factura.txtTotal.Text = vista.TablaBuscar.CurrentRow.Cells["Costo"].Value.ToString();
                factura.Datos.Rows.Add(vista.TablaBuscar.CurrentRow.Cells["Tipo"].Value.ToString() , vista.TablaBuscar.CurrentRow.Cells["Costo"].Value.ToString());


                factura.txtCodigoPaciente.Enabled = false;
                factura.txtCodigoVisita.Enabled = false;
                factura.txtNombre.Enabled = false;
                factura.txtApellido.Enabled = false;
                factura.txtNit.Enabled = false;
                factura.txtTotal.Enabled = false;

                vista.Close();
            }
            else
            {
                MessageBox.Show("Seleccione una Fila");
            }

        }


    }
}
