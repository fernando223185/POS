using POS.Clases.Models;
using System;
using System.Data;
using System.Text.Json;
using System.Windows.Forms;

namespace POS
{
    public partial class Productos : Form
    {
        Art products = new Art();
        public Productos()
        {
            InitializeComponent();
            getProducts();
        }



        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewProd_Click(object sender, EventArgs e)
        {
            FormProd formForProd = new FormProd(0);
            formForProd.Show();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            FormProd formForProd = new FormProd(2);
            formForProd.Show();
        }

        public async void getProducts()
        {
            var parametros = new
            {
                page = 1,
                search = ""
            };

            dataProducts.Rows.Clear();
            var result = await products.GetProducts(parametros);
            var apiResponse = JsonSerializer.Deserialize<Art.ProductsResponse>(result.Content);
            if (dataProducts.Columns.Count == 0)
            {
                dataProducts.Columns.Add("id", "ID");
                dataProducts.Columns["id"].Width = 100;

                dataProducts.Columns.Add("code", "Codigo");
                dataProducts.Columns["code"].Width = 100;

                dataProducts.Columns.Add("name", "Nombre");
                dataProducts.Columns["name"].Width = 150;

                dataProducts.Columns.Add("description", "Descripcion");
                dataProducts.Columns["description"].Width = 150;

                dataProducts.Columns.Add("barcode", "Codigo de barras");
                dataProducts.Columns["barcode"].Width = 160;

                dataProducts.Columns.Add("price", "Precio");
                dataProducts.Columns["price"].Width = 100;
   
            }

            foreach (var product in apiResponse.data)
            {
                dataProducts.Rows.Add(product.id, product.code, product.name, product.description, product.barcode, product.price);
            }
        }

    }
}
