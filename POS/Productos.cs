﻿using System;
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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewProd_Click(object sender, EventArgs e)
        {
            FormProd formForProd = new FormProd();
            formForProd.Show();
        }
    }
}
