using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasCarros
{
    public class Venta
    {
        public string IdVenta { get; set; }
        public Vehiculo VehiculoVendido { get; set; }
        public Cliente ClienteComprador { get; set; }
        public Empleado Vendedor { get; set; }
        public DateTime FechaVenta { get; set; }
        public double PrecioFinal { get; set; }

        public Venta(string idVenta, Vehiculo vehiculo, Cliente cliente, Empleado vendedor, double precioFinal)
        {
            IdVenta = idVenta;
            VehiculoVendido = vehiculo;
            ClienteComprador = cliente;
            Vendedor = vendedor;
            FechaVenta = DateTime.Now;
            PrecioFinal = precioFinal;

            // Cambiar el estado del vehículo a "vendido"
            vehiculo.Estado = "Vendido";
        }

        public void MostrarDetallesVenta()
        {
            Console.WriteLine($"Venta ID: {IdVenta}\nVehículo: {VehiculoVendido.Marca} {VehiculoVendido.Modelo} - {VehiculoVendido.Año}\nCliente: {ClienteComprador.Nombre}\nVendedor: {Vendedor.Nombre}\nFecha de Venta: {FechaVenta}\nPrecio Final: {PrecioFinal}");
        }
    }
}
