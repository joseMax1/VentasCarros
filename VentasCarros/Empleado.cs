using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VentasCarros
{
    public abstract class Empleado
    {
        public string IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }

        public Empleado(string idEmpleado, string nombre, string rol)
        {
            IdEmpleado = idEmpleado;
            Nombre = nombre;
            Rol = rol;
        }

        public abstract void MostrarRol();
    }
}