using System;
using System.Text.Json;
using System.Windows.Forms;
using POS.Clases;
using POS.Clases.Models;
using POS.Views.CRM;

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

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (dataCte.SelectedCells.Count > 0)
            {
                int rowIndex = dataCte.SelectedCells[0].RowIndex;
                object idValue = dataCte.Rows[rowIndex].Cells["id"].Value;
                if (idValue != null)
                {
                    int id = Convert.ToInt32(idValue);
                    FormCustomer form = new FormCustomer(id);
                    form.Show();
                }
            }
        }
    }
}
