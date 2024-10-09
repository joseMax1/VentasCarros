using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasCarros
{
    public class Cliente
    {
        public string IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public Cliente(string idCliente, string nombre, string direccion)
        {
            IdCliente = idCliente;
            Nombre = nombre;
            Direccion = direccion;
        }
    }
}
