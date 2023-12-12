using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCliente.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }        
        public string Direccion { get; set; }        
        public int Telefono { get; set; }
        public string Email { get; set; }

    }
}