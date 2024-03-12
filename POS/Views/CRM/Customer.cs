using System;
using System.Text.Json;
using System.Windows.Forms;
using POS.Clases;
using POS.Clases.Models;

namespace POS.Views.Customers
{
    public partial class Customer : Form
    {
        CustomersClass customer = new CustomersClass();
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
            Console.WriteLine("JSON: " + customers.Content);
            //MessageBox.Show("JSON: "+customers.Content);

            var apiResponse = JsonSerializer.Deserialize<CustomersClass.CustomersResponse>(customers.Content);

            if (dataCte.Columns.Count == 0)
            {
                dataCte.Columns.Add("id", "ID");
                dataCte.Columns.Add("name", "Nombre");
                dataCte.Columns.Add("lastName", "Apellido");
                dataCte.Columns.Add("phone", "Teléfono");
                dataCte.Columns.Add("email", "Correo electrónico");
                dataCte.Columns.Add("address", "Dirección");
                dataCte.Columns.Add("taxId", "ID fiscal");
                dataCte.Columns.Add("zipCode", "Código postal");
            }

            foreach (var customer in apiResponse.data)
            {
                dataCte.Rows.Add(customer.id, customer.name, customer.lastName, customer.phone, customer.email, customer.address, customer.taxId, customer.zipCode);
            } 

        }
    }
}
