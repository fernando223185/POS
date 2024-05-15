using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Clases.Models
{
    public class Sales_Orders
    {
        private string urlApi = "https://localhost:7254/api/Sales/";

        public int id { get; set; }
        public int company_ID { get; set; }
        public string mov { get; set; }
        public string movID { get; set; }
        public DateTime fechaEmision { get; set; } 
        public DateTime ultimoCambio { get; set; }
        public string moneda { get; set; }
        public string user { get; set; }
        public string status { get; set; }
        public string customer { get; set; }
        public string warehouse { get; set; }
        public decimal importe { get; set; }
        public decimal impuestos { get; set; }
        public decimal saldo { get; set; }
        public decimal discount { get; set; }
        public decimal precioTotal { get; set; }

        public class SalesResponse
        {
            public int page { get; set; }

            public int totalPages { get; set; }
            public int sizePage { get; set; }
            public List<Sales_Orders> data { get; set; }

        }

        public class Response
        {
            public string message { get; set; }
            public int error { get; set; }
            public Sales_Orders result { get; set; }

        }

        public async Task<RestResponse> CreateSale(Object parameters)
        {
            var Sale = new RestClient(urlApi + "create");
            var request = new RestRequest();
            request.Method = Method.Post;

            request.AddJsonBody(parameters);

            try {
                var response = await Sale.ExecuteAsync(request);

                return (RestResponse)response;
                
            }catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
