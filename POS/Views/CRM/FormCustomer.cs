using POS.Clases.Models;
using System;
using System.Text.Json;
using System.Windows.Forms;

namespace POS.Views.CRM
{
    public partial class FormCustomer : Form
    {
        CustomersClass customer = new CustomersClass();

        public FormCustomer(int id)
        {
            InitializeComponent();
            getCustomerID(id);

        }

        private async void getCustomerID(int id)
        {
            var customerInfo = await customer.GetCustomerID(id);
            Console.WriteLine(customerInfo.Content);
            var apiResponse = JsonSerializer.Deserialize<CustomersClass>(customerInfo.Content);
            
            if(apiResponse != null) 
            {
                this.TxtCode.Text = apiResponse.code;
                this.TxtName.Text = apiResponse.name;
                this.TxtLastName.Text = apiResponse.lastName;
                this.TxtPhone.Text = apiResponse.phone;
                this.TxtEmail.Text = apiResponse.email;
                this.TxtAddress.Text = apiResponse.address;
                this.TxtTaxId.Text = apiResponse.taxId;
                this.TxtZipCode.Text = apiResponse.zipCode;
                this.TxtComments.Text = apiResponse.commentary;
                this.TxtNumInt.Text = apiResponse.interiorNumber;
                this.TxtNumExt.Text = apiResponse.exteriorNumber;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
