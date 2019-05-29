using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Hospital.Controllers;

namespace Formulario_Login
{
    public partial class FormuLogin : Form
    {
        public override bool AutoSize { get; set; }

        public FormuLogin()
        {
            InitializeComponent();
            LoginController vista = new LoginController(this);
            Componetes();

        }

        public void Componetes() {
            this.txtUser.AutoSize = false;
            txtUser.Size = new Size(250,25);
            this.txtUser.Font = new System.Drawing.Font("Arial", 13, FontStyle.Regular);

            this.txtPass.AutoSize = false;
            txtPass.Size = new Size(250, 25);
            this.txtPass.Font = new System.Drawing.Font("Arial", 13, FontStyle.Regular);
            txtPass.UseSystemPasswordChar = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public static void BorderRedondoButton(Button b)
        {
            Rectangle r = new Rectangle(0, 0, b.Width, b.Height);
            System.Drawing.Drawing2D.GraphicsPath button = new System.Drawing.Drawing2D.GraphicsPath();
            int d = 40;
            button.AddArc(r.X, r.Y, d, d, 180, 90);
            button.AddArc(r.X + r.Width - d, r.Y, d, d, 280, 90);
            button.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
            button.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
            b.Region = new Region(button);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BorderRedondoButton(btnLogin);
        }
    }
}
