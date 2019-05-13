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
        private string id = null;
        private Boolean actualizar = false;


        public DoctorController(Doctor view)
        {
            vista = view;
            vista.btnCerrarFormulario.Click += new EventHandler(cerrarFormulario);
            vista.Load += new EventHandler(itemEspecialidad);
            vista.Load += new EventHandler(mostrarRegistrosDoctor);
            vista.txtBuscar.TextChanged += new EventHandler(mostrarRegistrosDoctor);
            vista.btnGuardar.Click += new EventHandler(registrarPaciente);
            vista.btnActualizar.Click += new EventHandler(actualizarDoctor);
            vista.btnEliminar.Click += new EventHandler(eliminarDoctor);
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


        /*-------------------------------------- Agregar Items---------------------------------------------*/
        private void itemEspecialidad(object sender, EventArgs e)
        {
            /*caja de texto Bloqueada*/
            vista.txtItems.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (var item in dao.itemEspecialidad())
            {
                vista.txtItems.Items.Add(item.ToString());
            }
        }
        /*-----------------------------------------------------------------------------------*/
    
        /*---------------------------------------Metodo de Mostrar, Eliminar, Actualizar BD------------------------------------*/
        private void mostrarRegistrosDoctor(object sender, EventArgs e)
        {
            DoctorDAO dao = new DoctorDAO();
            vista.TablaDoctor.DataSource = dao.mostarRegistros(vista.txtBuscar.Text);
        }

        private void registrarPaciente(object sender, EventArgs e)
        {

            if (actualizar == false)
            {
                try
                {
                    dao.isertarRegistro(Convert.ToInt32(vista.txtItems.Text), vista.txtNombre.Text, vista.txtApellido.Text, vista.txtDPI.Text, Convert.ToInt32(vista.txtTelefono.Text));
                    MessageBox.Show("Guardado con exito");
                    mostrarRegistrosDoctor(null, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString());
                }

            }

            if (actualizar == true)
            {
                try
                {
                    dao.editarRegistro(Convert.ToInt32(vista.txtItems.Text), vista.txtNombre.Text, vista.txtApellido.Text, vista.txtDPI.Text, Convert.ToInt32(vista.txtTelefono.Text), Convert.ToInt32(id));
                    MessageBox.Show("Actualizado con exito");
                    mostrarRegistrosDoctor(null, e);
                    actualizar = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString());
                }

            }

            Limpiar();

        }


        private void actualizarDoctor(object sender, EventArgs e)
        {
            if (vista.TablaDoctor.SelectedRows.Count > 0)
            {
                actualizar = true;
                vista.txtNombre.Text = vista.TablaDoctor.CurrentRow.Cells["Nombre"].Value.ToString();
                vista.txtApellido.Text = vista.TablaDoctor.CurrentRow.Cells["Apellido"].Value.ToString();
                vista.txtDPI.Text = vista.TablaDoctor.CurrentRow.Cells["DPI"].Value.ToString();
                vista.txtTelefono.Text = vista.TablaDoctor.CurrentRow.Cells["Telefono"].Value.ToString();
                vista.txtItems.Text = vista.TablaDoctor.CurrentRow.Cells["Id_Epecialidad"].Value.ToString();
                id = vista.TablaDoctor.CurrentRow.Cells["Id_Doctor"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una Fila");
            }
        }

        private void eliminarDoctor(object sender, EventArgs e)
        {
            if (vista.TablaDoctor.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Desea eliminar el elemento seleccionado?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    id = vista.TablaDoctor.CurrentRow.Cells["Id_Doctor"].Value.ToString();
                    dao.eliminarRegistro(Convert.ToInt32(id));
                    MessageBox.Show("Eliminado con exito");
                    mostrarRegistrosDoctor(null, e);
                }

            }
            else
            {
                MessageBox.Show("Seleccione una Fila");
            }

        }

        private void Limpiar()
        {
            vista.txtNombre.Clear();
            vista.txtApellido.Clear();
            vista.txtDPI.Clear();
            vista.txtTelefono.Clear();
            vista.txtBuscar.Clear();
        }

        /*-----------------------------------------------------------------------------------*/

    }
}
