using POS.Clases.Models;
using POS.Views.Customers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class FormProd : Form
    {
        Art art = new Art();
        public int ID { get; set; }

        public FormProd(int id)
        {
            InitializeComponent();
            if (id > 0)
            {
                //getCustomerID(id);
            }
            ID = id;

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImgLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes|*.jpg; *.png";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofdSeleccionar.Title = "Seleccionar imagen";
            if (ofdSeleccionar.ShowDialog() == DialogResult.OK) 
            {
                pbImagen.Image = Image.FromFile(ofdSeleccionar.FileName);

            }
        }

        private async void btnNewProd_Click(object sender, EventArgs e)
        {
            var result = new RestResponse();

            if (ID > 0)
            {
                var parameters = new
                {
                    id = ID,
                    name = this.txtName.Text,
                    description = this.txtDescription.Text,
                    code = this.txtCode.Text,
                    barcode = this.txtBarcode.Text,
                    price = this.txtListPrice.Text
                };

                result = await art.UpdateProduct(parameters);
            }
            else
            {
                var parameters = new
                {
                    name = this.txtName.Name,
                    description = this.txtDescription.Text,
                    code = this.txtCode.Text,
                    barcode = this.txtBarcode.Text,
                    price = this.txtListPrice.Text
                };

                result = await art.CreateProduct(parameters);
            }

            var response = JsonSerializer.Deserialize<Art.Response>(result.Content);
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
