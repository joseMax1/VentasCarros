using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasCarros
{
    public class Vendedor : Empleado
    {

        public Vendedor(string idEmpleado, string nombre, string rol) : base(idEmpleado, nombre, rol) { }

        public override void MostrarRol()
        {
            Console.WriteLine($"Vendedor: {Nombre}");
        }
    }
}