using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hospital.Models.DAO;
using View;

namespace Hospital.Controllers
{
    class DoctorController
    {
        private Doctor vista;
        private DoctorDAO dao = new DoctorDAO();

        public DoctorController(Doctor view)
        {
            vista = view;
            vista.btnCerrarFormulario.Click += new EventHandler(cerrarFormulario);
            vista.Load += new EventHandler(itemEspecialidad);
            vista.Load += new EventHandler(mostrarRegistrosDoctor);
            vista.txtBuscar.TextChanged += new EventHandler(mostrarRegistrosDoctor);
        }


        /*------------------------Metodo de Cerrar Formulario-------------------------------*/
        private void cerrarFormulario(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar el formulario?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                vista.Dispose();
            }
        }
        /*-----------------------------------------------------------------------------------*/

        private void itemEspecialidad(object sender, EventArgs e)
        {
            /*caja de texto Bloqueada*/
            vista.txtItems.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (var item in dao.itemEspecialidad())
            {
                vista.txtItems.Items.Add(item.ToString());
            }
        }

        private void mostrarRegistrosDoctor(object sender, EventArgs e)
        {
            DoctorDAO dao = new DoctorDAO();
            vista.TablaDoctor.DataSource = dao.MostarRegistros(vista.txtBuscar.Text);
        }



    }
}
