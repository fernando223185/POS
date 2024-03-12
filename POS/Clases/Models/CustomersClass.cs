using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Clases.Models
{
    public class CustomersClass
    {
        private string urlApi = "https://localhost:7254/api/Customer/";

        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string taxId { get; set; }
        public string zipCode { get; set; }
        public string commentary { get; set; }
        public int countryId { get; set; }
        public int stateId { get; set; }
        public string interiorNumber { get; set; }
        public string exteriorNumber { get; set; }
        public int statusId { get; set; }
    

        public class CustomersResponse
        {
            public int page { get; set; }
            public int totalPages { get; set; }
            public int sizePage { get; set; }
            public List<CustomersClass> data { get; set; }
        }


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
    }
}
