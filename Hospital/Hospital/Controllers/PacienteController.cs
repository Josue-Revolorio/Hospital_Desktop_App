using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;  // para mover el formulario
using System.Windows.Forms;
using Hospital.Models.DAO;
using View;

namespace Hospital.Controllers
{
    public sealed class PacienteController
    {
        private Paciente vista;
        private PacienteDAO dao = new PacienteDAO();
        private string id = null;
        private Boolean actualizar = false;


        public PacienteController(Paciente view)
        {
            this.vista = view;
            vista.btnCerrarformulario.Click += new EventHandler(cerrarFormulario);
            vista.Load += new EventHandler(item);
            vista.Load += new EventHandler(pacientesMostrarRegistros);
            vista.txtBuscar.TextChanged += new EventHandler(pacientesMostrarRegistros);
            vista.btnGuardar.Click += new EventHandler(registrarPaciente);
            vista.btnActualizar.Click += new EventHandler(actualizarPaciente);
            vista.btnEliminar.Click += new EventHandler(eliminarPaciente);

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


        /*-----------------------------------Metido Muestra Items-------------------------------*/
        private void item(object sender, EventArgs e)
        {
            vista.txtSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            vista.txtSexo.Items.Add("F");
            vista.txtSexo.Items.Add("M");

        }
        /*---------------------------------------------------------------------------------------*/

        /*---------------------------------------Metodo de Mostrar, Eliminar, Actualizar BD------------------------------------*/
        private void pacientesMostrarRegistros(object sender, EventArgs e)
        {
            PacienteDAO dao = new PacienteDAO();
            vista.TablaPacientes.DataSource = dao.mostrarRegistros(vista.txtBuscar.Text);
        }

        private void registrarPaciente(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(vista.txtDatePicker.Text);
            string fecha = date.ToString("yyyy/MM/dd");

            if(actualizar == false)
            {
                try
                {
                    dao.isertarRegistro(vista.txtNombre.Text, vista.txtApellido.Text, fecha, vista.txtDPI.Text, vista.txtDireccion.Text, Convert.ToInt32(vista.txtTelefono.Text), vista.txtNit.Text, vista.txtSexo.Text);
                    MessageBox.Show("Guardado con exito");
                    pacientesMostrarRegistros(null, e);

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
                    dao.editarRegistro(vista.txtNombre.Text, vista.txtApellido.Text, fecha, vista.txtDPI.Text, vista.txtDireccion.Text, Convert.ToInt32(vista.txtTelefono.Text), vista.txtNit.Text, vista.txtSexo.Text, Convert.ToInt32(id));
                    MessageBox.Show("Actualizado con exito");
                    pacientesMostrarRegistros(null, e);
                    actualizar = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString());
                }

            }

            Limpiar();

        }

        private void actualizarPaciente(object sender, EventArgs e)
        {
            if (vista.TablaPacientes.SelectedRows.Count > 0)
            {
                actualizar = true;
                vista.txtNombre.Text = vista.TablaPacientes.CurrentRow.Cells["Nombre"].Value.ToString();
                vista.txtApellido.Text = vista.TablaPacientes.CurrentRow.Cells["Apellido"].Value.ToString();
                vista.txtDatePicker.Text = vista.TablaPacientes.CurrentRow.Cells["Fecha_Nacimiento"].Value.ToString();
                vista.txtDPI.Text = vista.TablaPacientes.CurrentRow.Cells["DPI"].Value.ToString();
                vista.txtDireccion.Text = vista.TablaPacientes.CurrentRow.Cells["Direccion"].Value.ToString();
                vista.txtTelefono.Text = vista.TablaPacientes.CurrentRow.Cells["Telefono"].Value.ToString();
                vista.txtNit.Text = vista.TablaPacientes.CurrentRow.Cells["Nit"].Value.ToString();
                vista.txtSexo.Text = vista.TablaPacientes.CurrentRow.Cells["Sexo"].Value.ToString();
                id = vista.TablaPacientes.CurrentRow.Cells["Id"].Value.ToString();
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
            vista.txtDireccion.Clear();
            vista.txtTelefono.Clear();
            vista.txtNit.Clear();
            vista.txtBuscar.Clear();
        }


        private void eliminarPaciente(object sender, EventArgs e)
        {
            if (vista.TablaPacientes.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Desea eliminar el elemento seleccionado?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    id = vista.TablaPacientes.CurrentRow.Cells["Id"].Value.ToString();
                    dao.eliminarRegistro(Convert.ToInt32(id));
                    MessageBox.Show("Eliminado con exito");
                    pacientesMostrarRegistros(null, e);
                }

            }
            else
            {
                MessageBox.Show("Seleccione una Fila");
            }

        }


    }
}
