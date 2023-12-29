using POS.Clases.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class FormProd : Form
    {
        Art art = new Art();
        public FormProd()
        {
            InitializeComponent();
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

        private void btnNewProd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string code = txtCode.Text.Trim(); 
            string barcode = txtBarcode.Text.Trim();   
            decimal tax = decimal.Parse(txtTax.Text.Trim());
            string unit = cmbUnit.Text.Trim();
            decimal cost = decimal.Parse(txtCost.Text.Trim());
            decimal listPrice = decimal.Parse(txtListPrice.Text);
            decimal minimunPrice = decimal.Parse(txtMinimunPrice.Text);
            int idStatus = 1;//int.Parse(cmbStatus.SelectedValue.ToString());
            string description = txtDescription.Text.Trim();

            int ok = art.NewArt(name,code,barcode,tax,unit,cost,listPrice,minimunPrice,idStatus,description);
            if (ok == 0)
            {
                MessageBox.Show("Se inserto"); 
            }
            else
            {
                MessageBox.Show("Problema al insertar");
            }


        }
    }
}
