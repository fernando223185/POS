using System;
using System.Text.Json;
using System.Windows.Forms;
using POS.Clases;

namespace POS
{
    public partial class Login : Form
    {
        User login = new User();
        public Login()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            string pass = txtContra.Text;
            var response = await login.GetLogin(user, pass);
            var apiResponse = JsonSerializer.Deserialize<User.ResponseApi>(response.Content);
            if (apiResponse != null)
            {
                if (apiResponse.error == 0)
                {
                    var result = MessageBox.Show(apiResponse.message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}