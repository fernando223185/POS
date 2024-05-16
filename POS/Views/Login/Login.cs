using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Windows.Forms;
using POS.Clases;
using System.Runtime.InteropServices;

namespace POS
{
    public partial class Login : Form
    {
        User login = new User();
        public Login()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private async void button1_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            string pass = txtContra.Text;
            var response = await login.GetLogin(user, pass);
            var apiResponse = System.Text.Json.JsonSerializer.Deserialize<User.ResponseApi>(response.Content);
            if (apiResponse != null)
            {
                if (apiResponse.error == 0)
                {
                    var result = MessageBox.Show(apiResponse.message, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    User.CurrentUser = apiResponse;
                    if (result == DialogResult.OK)
                    {
                        var nuevaVentana = new Menu();
                        nuevaVentana.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show(apiResponse.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La respuesta no se pudo deserializar correctamente.");
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}