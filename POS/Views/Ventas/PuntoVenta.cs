using POS.Clases;
using POS.Clases.Models;
using RestSharp;
using System;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;

namespace POS
{
    public partial class PuntoVenta : Form
    {
        Sales_Orders sales = new Sales_Orders();
        User user = new User();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public PuntoVenta()
        {
            InitializeComponent();

            // Agregar el manejador de eventos MouseDown al formulario
            this.MouseDown += new MouseEventHandler(Form_MouseDown);

        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private async void createSale()
        {
            var result = new RestResponse();
            var parameters = new
            {
                company_ID = 1,
                mov = "Pedido",
                moneda = "MXN",
                user = user.NameUser,
                customer = ""
            };
            result = await sales.CreateSale(parameters);

            var response = JsonSerializer.Deserialize<Sales_Orders.Response>(result.Content);
            
        }

        // Constantes para los mensajes de SendMessage
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
    }
}
