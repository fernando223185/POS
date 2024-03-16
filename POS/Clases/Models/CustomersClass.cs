using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public class Response
        {
            public string message { get; set; }
            public int error { get; set; }
            public CustomersClass data { get; set; }
        }




        public async Task<RestResponse> GetCustomers(Object parameters)
        {
            var customer = new RestClient(urlApi+"List");
            var request = new RestRequest();
            request.Method = Method.Post;

            request.AddJsonBody(parameters);

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

        public async Task<RestResponse> GetCustomerID(int id)
        {
            var customer = new RestClient(urlApi + "find_by_id/" + id);
            var request = new RestRequest();
            request.Method = Method.Get;

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

        public async Task<RestResponse> UpdateCustomer(Object parameters)
        {
            var customer = new RestClient(urlApi + "update");
            var request = new RestRequest();
            request.Method = Method.Put;

            request.AddJsonBody(parameters);

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

        public async Task<RestResponse> CreateCustomer(Object parameters)
        {
            var customer = new RestClient(urlApi + "create");
            var request = new RestRequest();
            request.Method = Method.Post;

            request.AddJsonBody(parameters);

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
