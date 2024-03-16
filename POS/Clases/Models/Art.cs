using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace POS.Clases.Models
{
    public class Art
    {
        private string urlApi = "https://localhost:7254/api/Product/";
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public string barcode { get; set; }
        public decimal price { get; set; }

        public class ProductsResponse
        {
            public int page { get; set; }
            public int totalPages { get; set; }
            public int sizePage { get; set; }
            public List<Art> data { get; set; }
        }

        public class Response
        {
            public string message { get; set; }
            public int error { get; set; }
            public Art data { get; set; }
        }

        public async Task<RestResponse> GetProducts(Object parameters)
        {
            var products = new RestClient(urlApi + "List");
            var request = new RestRequest();
            request.Method = Method.Post;

            request.AddJsonBody(parameters);

            try 
            {
                var response = await products.ExecuteAsync(request);

                return (RestResponse)response;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public async Task<RestResponse> CreateProduct(Object parameters)
        {
            var product = new RestClient(urlApi + "create");
            var request = new RestRequest();
            request.Method = Method.Post;

            request.AddJsonBody(parameters);

            try
            {
                var response = await product.ExecuteAsync(request);
                return (RestResponse)response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<RestResponse> UpdateProduct(Object parameters)
        {
            var product = new RestClient(urlApi + "update");
            var request = new RestRequest();
            request.Method = Method.Put;

            request.AddJsonBody(parameters);

            try
            {

                var response = await product.ExecuteAsync(request);

                return (RestResponse)response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
