using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using RestSharp;

namespace POS.Clases
{
    public class User
    {
        public int IdProduct { get; set; }
        public string Code { get; set; }
        public string NameUser { get; set; }
        public string Pass { get; set; }
        public string NameP { get; set; }
        public string LastNameP { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int IdDepartamento { get; set; }
        public DateTime DateRegistro { get; set; }
        public int IdEstatus { get; set; }

        private string urlApi = "https://apiposfd22.azurewebsites.net/api/User/Login"; //Url para la api de users

        public class ResponseApi
        {
            public bool success { get; set; }
            public int ok { get; set; }
            public string response { get; set; }
        }
        public User()
        {
            
        }
        public int GetLogin(string username, string password)
        {
            ResponseApi apiResponse;
            var client = new RestClient(urlApi);
            var parametros = new
            {
                nameUser = username,
                pass = password
            };
            string jsonbody = JsonSerializer.Serialize(parametros);
            var request = new RestRequest();
            request.AddJsonBody(jsonbody, "application/json");
            try
            {
                var response = client.Post(request);
                if (response.IsSuccessful)
                {
                    apiResponse = JsonSerializer.Deserialize<ResponseApi>(response.Content);
                    MessageBox.Show(apiResponse.response);
                    //MessageBox.Show(response.Content);
                    return apiResponse.ok;
                }
                else
                {
                    apiResponse = JsonSerializer.Deserialize<ResponseApi>(response.Content);
                    MessageBox.Show(apiResponse.response);
                    //MessageBox.Show(response.Content);
                    return apiResponse.ok;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }
}
