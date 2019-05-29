using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hospital.Models.DAO;
using View;
using Formulario_Login;

namespace Hospital.Controllers
{
    class LoginController
    {
        private FormuLogin vista;

        public LoginController(FormuLogin vista)
        {
            this.vista = vista;
            vista.btnLogin.Click += new EventHandler(login);
        }

        private void login(object sender, EventArgs e)
        {
            LoginDAO dao = new LoginDAO();
            Boolean validacion = dao.ValidarLogin(vista.txtUser.Text, vista.txtPass.Text);
            if (vista.txtUser.Text == "")
            {
                if (vista.txtPass.Text == "")
                {
                    MessageBox.Show("Verificar que los Campos esten llenos");
                }
            }
            else
            {
                if (validacion)
                {
                    MessageBox.Show("Usuario y Contraseña Correcta");
                    MenuPrincipal menu = new MenuPrincipal();
                    menu.Show();
                    menu.FormClosed += Logout;

                    vista.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario 0 Contraseña incorrecta intente de nuevo");
                    vista.txtUser.Clear();
                    vista.txtPass.Clear();
                }
            }


        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            vista.txtUser.Clear();
            vista.txtPass.Clear();
            vista.Show();
        }


    }
}
