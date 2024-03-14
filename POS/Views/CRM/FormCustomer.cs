using POS.Clases.Models;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Windows.Forms;

namespace POS.Views.CRM
{
    public partial class FormCustomer : Form
    {
        CustomersClass customer = new CustomersClass();
        public int ID { get; set; }

        public FormCustomer(int id)
        {
            InitializeComponent();
            getCustomerID(id);
            ID = id;

        }

        private async void getCustomerID(int id)
        {
            var customerInfo = await customer.GetCustomerID(id);
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

        private async void btnNewProd_Click(object sender, EventArgs e)
        {
            var parameters = new 
            {
                id = ID,
                code = this.TxtCode.Text,
                name = this.TxtName.Text,
                lastName = this.TxtLastName.Text,
                phone = this.TxtPhone.Text,
                email = this.TxtEmail.Text,
                address = this.TxtAddress.Text,
                taxId = this.TxtTaxId.Text,
                zipCode = this.TxtZipCode.Text,
                commentary = this.TxtComments.Text,
                countryId = 1,
                stateId = 0,
                interiornumber = this.TxtNumInt.Text,
                exteriorNumber = this.TxtNumExt.Text,
            };

            var result = await customer.UpdateCustomer(parameters);
            var response = JsonSerializer.Deserialize<CustomersClass.Response>(result.Content);
            if (response.error == 0)
            {
                var message = MessageBox.Show(response.message, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (message == DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
