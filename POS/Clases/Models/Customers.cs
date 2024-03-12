using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Clases.Models
{
    public class Customers
    {
        private string urlApi = "https://localhost:7254/api/Customer/";

        public async Task<RestResponse> GetCustomers()
        {
            var customer = new RestClient(urlApi+"List");
            var request = new RestRequest();
            request.Method = Method.Post;
            var parametros = new
            {
                page = 1,
                search = ""
            };

            request.AddJsonBody(parametros);

            try
            {

                var response = await customer.ExecuteAsync(request);

                return (RestResponse)response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Customers()
        {

        }
    }
}
