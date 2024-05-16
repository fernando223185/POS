using System;
using System.Threading.Tasks;
using RestSharp;

namespace POS.Clases
{
    public class User
    {
        public int id { get; set; }
        public string code { get; set; }
        public string nameUser { get; set; }
        public string pass { get; set; }
        public string nameP { get; set; }
        public string lastNameP { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public int IdDepartamento { get; set; }
        public DateTime DateRegistro { get; set; }
        public int IdEstatus { get; set; }

        private string urlApi = "https://localhost:7254/api/Login/login"; //Url para la api de users
        public static ResponseApi CurrentUser { get; set; }

        public class ResponseApi
        {
            public string message { get; set; }
            public int error { get; set; }
            public User user { get; set; }
        }
        public async Task<RestResponse> GetLogin(string username, string password)
        {
            var client = new RestClient(urlApi);
            var request = new RestRequest();
            request.Method = Method.Post;
            var parametros = new
            {
                nameUser = username,
                pass = password
            };

            request.AddJsonBody(parametros);

            try
            {
                var response = await client.ExecuteAsync(request);
                return (RestResponse)response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}