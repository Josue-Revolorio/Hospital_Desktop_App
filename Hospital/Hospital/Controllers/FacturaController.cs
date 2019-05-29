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
    class FacturaController
    {
        private Facturacion vista;

        public FacturaController(Facturacion vista)
        {
            this.vista = vista;
            vista.btnAbrir.Click += new EventHandler(abrirFormulario);
            vista.btnimprimir.Click += new EventHandler(registrarFactura);
        }

        private void abrirFormulario(object sender, EventArgs e)
        {
            Detalle visita = new Detalle();
            vista.AddOwnedForm(visita);
            visita.Show();
        }

        private void registrarFactura(object sender, EventArgs e)
        {
            FacturaDAO dao = new FacturaDAO();
            dao.isertarRegistro(Convert.ToInt32(vista.txtCodigoPaciente.Text), Convert.ToInt32(vista.txtCodigoPaciente.Text));
            MessageBox.Show("Dato Impreseo");
        }
    }
}
