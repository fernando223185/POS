using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class Ventas : Form
    {
        private string urlApi = "https://apiposfd22.azurewebsites.net/api/Art/Articulos";
        public Ventas()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
