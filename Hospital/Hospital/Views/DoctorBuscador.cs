using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hospital.Controllers;

namespace Hospital.Views
{
    public partial class DoctorBuscador : Form
    {
        public DoctorBuscador()
        {
            InitializeComponent();
            DoctorBuscadorController Vista = new DoctorBuscadorController(this);
        }
    }
}
