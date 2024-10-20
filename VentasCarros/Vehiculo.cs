using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasCarros
{
    public class Vehiculo
    {
        public string NumeroSerie {  get; set; }
        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int Año { get; set; }

        public double PrecioVenta { get; set; }


        public string Estado { get; set; }  // Estado del vehículo ("Disponible" o "Vendido")


        public List<string> Historial { get; set; }  // aqui se encuentra el historial de cambios


        public Vehiculo(string numeroSerie, string marca , string modelo,int año, double precioVenta)
        {
            NumeroSerie = numeroSerie;
            Marca = marca;
            Modelo=modelo;
            Año= año;
            PrecioVenta=precioVenta;
            Estado = "Disponible";
            Historial = new List<string>();
            AgregarAlHistorial($"Vehículo agregado: {marca} {modelo}, Año: {año}, Precio: {precioVenta}");

        }

        public void AgregarAlHistorial(string mensaje)
        {
            Historial.Add($"{DateTime.Now}:{ mensaje}");
        }

        public void MostrarHistorial()
        {
            Console.WriteLine($"Historial de cambios para el vehículo {NumeroSerie}:");
            foreach (var registro in Historial)
            {
                Console.WriteLine(registro);
            }
        }
    }
}
        