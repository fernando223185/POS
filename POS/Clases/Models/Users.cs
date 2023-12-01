using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

        public User()
        {
            
        }
    }
}
