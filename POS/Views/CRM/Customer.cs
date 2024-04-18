using System;
using System.Text.Json;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
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

        public async void getCustomers()
        {
            var parametros = new
            {
                page = 1,
                search = ""
            };
            dataCte.Rows.Clear();
            var customers = await customer.GetCustomers(parametros);
            var apiResponse = JsonSerializer.Deserialize<CustomersClass.CustomersResponse>(customers.Content);

            if (dataCte.Columns.Count == 0)
            {
                dataCte.Columns.Add("id", "ID");
                dataCte.Columns["id"].Width = 50;

                dataCte.Columns.Add("name", "Nombre");
                dataCte.Columns["name"].Width = 150;

                dataCte.Columns.Add("lastName", "Apellido");
                dataCte.Columns["lastName"].Width = 150;

                dataCte.Columns.Add("phone", "Teléfono");
                dataCte.Columns["phone"].Width = 100;

                dataCte.Columns.Add("email", "Correo electrónico");
                dataCte.Columns["email"].Width = 160;

                dataCte.Columns.Add("address", "Dirección");
                dataCte.Columns["address"].Width = 100;

                dataCte.Columns.Add("taxId", "ID fiscal");
                dataCte.Columns["taxId"].Width = 100;

                dataCte.Columns.Add("zipCode", "Código postal");
                dataCte.Columns["zipCode"].Width = 100;
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

        private void btnNewProd_Click(object sender, EventArgs e)
        {
            FormCustomer form = new FormCustomer(0);
            form.Show();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = TxtSearch.Text;
            var parametros = new
            {
                page = 1,
                search = search
            };
            dataCte.Rows.Clear();
            var customers = await customer.GetCustomers(parametros);
            var apiResponse = JsonSerializer.Deserialize<CustomersClass.CustomersResponse>(customers.Content);

            if (dataCte.Columns.Count == 0)
            {
                dataCte.Columns.Add("id", "ID");
                dataCte.Columns["id"].Width = 50;

                dataCte.Columns.Add("name", "Nombre");
                dataCte.Columns["name"].Width = 150;

                dataCte.Columns.Add("lastName", "Apellido");
                dataCte.Columns["lastName"].Width = 150;

                dataCte.Columns.Add("phone", "Teléfono");
                dataCte.Columns["phone"].Width = 100;

                dataCte.Columns.Add("email", "Correo electrónico");
                dataCte.Columns["email"].Width = 160;

                dataCte.Columns.Add("address", "Dirección");
                dataCte.Columns["address"].Width = 100;

                dataCte.Columns.Add("taxId", "ID fiscal");
                dataCte.Columns["taxId"].Width = 100;

                dataCte.Columns.Add("zipCode", "Código postal");
                dataCte.Columns["zipCode"].Width = 100;
            }

            foreach (var customer in apiResponse.data)
            {
                dataCte.Rows.Add(customer.id, customer.name, customer.lastName, customer.phone, customer.email, customer.address, customer.taxId, customer.zipCode);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataCte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
