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
    public partial class HistorialBuscar : Form
    {
        public HistorialBuscar()
        {
            InitializeComponent();
            HistorialBuscarController vista = new HistorialBuscarController(this);
        }
    }
}
