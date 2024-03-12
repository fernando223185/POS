using System;
using System.Threading.Tasks;
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

        private string urlApi = "https://localhost:7254/api/Login/login"; //Url para la api de users

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