using System;
using System.Windows.Forms;

namespace POS
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }



        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewProd_Click(object sender, EventArgs e)
        {
            FormProd formForProd = new FormProd(1);
            formForProd.Show();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            FormProd formForProd = new FormProd(2);
            formForProd.Show();
        }


    }
}
