using System;
using System.Windows.Forms;

namespace POS.Views.Customers
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            getCustomers();
        }

        private void getCustomers()
        {

            dataCte.Rows.Clear();
            var customer = await login.GetLogin(

            foreach (var customer in ConsultarProductos())
            {
                dataCte.Rows.Add(producto.Id, producto.Nombre, producto.Precio);
            }

        }
    }
}
