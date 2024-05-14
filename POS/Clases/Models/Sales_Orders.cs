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

        public int ID { get; set; }
        public int Company_ID { get; set; }
        public string Mov { get; set; }
        public string MovID { get; set; }
        public DateTime FechaEmision { get; set; } 
        public DateTime UltimoCambio { get; set; }
        public string Moneda { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public string Customer { get; set; }
        public string Warehouse { get; set; }
        public decimal Importe { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Saldo { get; set; }
        public decimal Discount { get; set; }
        public decimal PrecioTotal { get; set; }

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
            public Sales_Orders data { get; set; }

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
