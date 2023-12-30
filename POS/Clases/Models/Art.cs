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
        private string urlApi = "https://apiposfd22.azurewebsites.net/api/Art";

        public class ResponseApi
        {
            public bool succes { get; set; }
            public int ok { get; set; }
            public string response { get; set; }

        }

        public int NewArt(string name, string code, string barcode, decimal tax, string unit, decimal cost, decimal listPrice, decimal minimunPrice, int idStatus, string description) 
        {
            ResponseApi apiResponse;
            var art = new RestClient(urlApi+"/Guardar");

            var info = new
            {
                Articulo = name,
                Codigo = code,
                CodigoBarras = barcode,
                Descripcion = description,
                Impuesto1 = tax,
                Unidad = unit,
                Categoria = 1,
                Costo = cost,
                PrecioLista = listPrice,
                PrecioMinimo = minimunPrice,
                Estatus = idStatus,
                Foto = ""
            };

            string json = JsonSerializer.Serialize(info);
            var request = new RestRequest();

            request.AddJsonBody(json, "application/json");
            try 
            {
                var response = art.Post(request);
                if (response.IsSuccessful)
                {
                    apiResponse = JsonSerializer.Deserialize<ResponseApi>(response.Content);
                    MessageBox.Show(apiResponse.response);
                    //MessageBox.Show(response.Content);
                    return apiResponse.ok;
                }
                else
                {
                    MessageBox.Show("Entro else");
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

            return 0; 
        }
    }
}
