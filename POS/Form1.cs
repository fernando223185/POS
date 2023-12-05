using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Clases.Models;

namespace POS
{
    public partial class Form1 : Form
    {
        Login login = new Login();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            string pass = txtContra.Text;
            login.GetLogin(user, pass);
            //MessageBox.Show(login.GetLogin(user,pass));
        }
    }
}
