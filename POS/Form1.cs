using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Clases;

namespace POS
{
    public partial class Form1 : Form
    {
        User login = new User();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            string pass = txtContra.Text;
            int ok = login.GetLogin(user, pass);
            if (ok == 1)
            {
                Menu menu = new Menu();
                menu.Show();
            }
        }
    }
}
