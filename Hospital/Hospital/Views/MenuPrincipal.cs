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

namespace View
{
    public partial class MenuPrincipal : Form 
    {

        public MenuPrincipal()
        {
            InitializeComponent();
            HomeCotroller menu = new HomeCotroller(this);
        }

        
    }
}
