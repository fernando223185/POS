using System;
using System.Windows.Forms;
using POS.Clases;
using POS.Clases.Models;

namespace POS.Views.Customers
{
    public partial class Customer : Form
    {
        Clases.Models.Customers customer = new Clases.Models.Customers();
        public Customer()
        {
            InitializeComponent();
            getCustomers();

        }

/*        private void Customer_Load(object sender, EventArgs e)
        {
            getCustomers();
        } */

        private async void getCustomers()
        {

            dataCte.Rows.Clear();
            var customers = await customer.GetCustomers();
            MessageBox.Show(customers.Content);

            /*foreach (var customer in ConsultarProductos())
            {
                dataCte.Rows.Add(producto.Id, producto.Nombre, producto.Precio);
            } */

        }
    }
}
