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
using View;
using Hospital.Views;


namespace Hospital.Controllers
{
     public sealed class HomeCotroller
    {
        private MenuPrincipal vista;

        public HomeCotroller(MenuPrincipal View)
        {
            vista = View;
            vista.btnCerrar.Click += new EventHandler(cerrarAplicacion);
            vista.btnRegistrarPaciente.Click += new EventHandler(abrirFormularioPaciente);
            vista.btnRegistrarDoctor.Click += new EventHandler(abrirFormularioDoctor);
            vista.Load += new EventHandler(abrirFormularioInicio);
            vista.btnMaximizar.Click += new EventHandler(maximizarAplicacion);
            vista.btnMinimizar.Click += new EventHandler(minimizarAplicacion);
            vista.btnRestaurar.Click += new EventHandler(restaurarAplicacion);
            vista.BarraTitulo.MouseDown += new MouseEventHandler(moverFomulario);
            vista.MenuVertical.MouseDown += new MouseEventHandler(moverFomulario);
            vista.btnInicio.MouseDown += new MouseEventHandler(moverFomulario);
            vista.btnInicio.Click += new EventHandler(abrirFormularioInicio);
            vista.btnVisita.Click += new EventHandler(abrirFormularioVisita);
            vista.btnHistorial.Click += new EventHandler(abrirFormularioHistorial);
        }

        /*---------------------Metodos Para Cerra, minimizar , restaurar el formulario-----------------*/
        private void cerrarAplicacion(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maximizarAplicacion(object sender, EventArgs e)
        {
            vista.WindowState = FormWindowState.Maximized;
            vista.btnMaximizar.Visible = false;
            vista.btnRestaurar.Visible = true;
        }

        private void restaurarAplicacion(object sender, EventArgs e)
        {
            vista.WindowState = FormWindowState.Normal;
            vista.btnRestaurar.Visible = false;
            vista.btnMaximizar.Visible = true;
        }

        private void minimizarAplicacion(object sender, EventArgs e)
        {
            vista.WindowState = FormWindowState.Minimized;
        }

        /*-----------------------------------------------------------------------------------------------*/


        /*---------------------Codigo para poder mover el formulario -----------------*/

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void moverFomulario(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(vista.Handle, 0x112, 0xf012, 0);
        }
        /*-----------------------------------------------------------------------------*/

        /*---------------------Metodos Para Abrir Los Formularios -----------------*/
        private void abrirFormulario(object formulario)
        {
            if (vista.PanelContenedor.Controls.Count > 0)
            {
                vista.PanelContenedor.Controls.RemoveAt(0);
            }
            Form FH = formulario as Form;
            FH.TopLevel = false;
            FH.Dock = DockStyle.Fill;
            vista.PanelContenedor.Controls.Add(FH);
            vista.PanelContenedor.Tag = FH;
            FH.Show();
        }

        private void abrirFormularioPaciente(object sender, EventArgs e)
        {
            abrirFormulario(new Paciente());
        }

        private void abrirFormularioDoctor(object sender, EventArgs e)
        {
            abrirFormulario(new Doctor());
        }

        private void abrirFormularioInicio(object sender, EventArgs e)
        {
            abrirFormulario(new Inicio());
        }

        private void abrirFormularioVisita(object sender, EventArgs e)
        {
            abrirFormulario(new Visita());
        }


        private void abrirFormularioHistorial(object sender, EventArgs e)
        {
            abrirFormulario(new Historial());
        }

        /*--------------------------------------------------------------------------*/

    }
}
