using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Clases.Models
{
    public class Login
    {
        public string NameUser { get; set; }
        public string Pass { get; set; }

        private string urlApi = "http://localhost:5051/api/User/Login"; //Url para la api de users

        public Login() 
        {

        }
        public string GetLogin(string username, string password)
        {
            Login login = new Login()
            {
                NameUser = username,
                Pass = password
            };

            string jsonbody = JsonSerializer.Serialize(login);
            return jsonbody;
            var request = new RestRequest(urlApi).AddJsonBody(jsonbody);
            MessageBox.Show(request.ToString()); 
        }
    }
}
