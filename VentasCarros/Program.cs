using System;
using System.Collections.Generic;


namespace VentasCarros
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            List<Cliente> clientes = new List<Cliente>();
            List<Empleado> empleados = new List<Empleado>();
            {
                new Vendedor("01", "Maximiliano", "Vendedor");
                new Gerente("02", "jose", "Gerente");
            };

            // Realizo un menu interativo donde se pueden realizar diferente acciones

            bool continuar = true;
            while (continuar) {
                Console.WriteLine("Selecciona una opcion: \n");
                Console.WriteLine("1. Agregar Vehiculo: \n");
                Console.WriteLine("2. Actualizar Vehiculo: \n");
                Console.WriteLine("3. Ver Historial de Vehiculo: \n");
                Console.WriteLine("4. Agregar cliente: \n");
                Console.WriteLine("5. Gestionar empleado: \n");
                Console.WriteLine("0. Salir: \n");


                int opcion = int .Parse(Console.ReadLine());
                switch (opcion) 
                { 
                    case 1:
                        AgregarVehiculo(vehiculos);
                        break;

                    case 2:
                        ActualizarVehiculo(vehiculos);
                        break;

                    case 3:

                        VerHistorialVehiculo(vehiculos);
                        break;

                    case 4:
                        AgregarCliente(clientes);
                        break;

                    case 5:
                        GestionarEmpleados(empleados);
                        break;

                    case 0:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }

            }

            Console.WriteLine("Gestión finalizada.");

        }


        static void AgregarVehiculo(List<Vehiculo> vehiculos) 
        {

            Console.WriteLine("Agregar Vehiculo");
            Console.WriteLine("Numero de serie: ");
            string numeroSerie = Console.ReadLine();
            Console.WriteLine("Marca: ");
            string marca = Console.ReadLine();
            Console.Write("Modelo: ");
            string modelo = Console.ReadLine();
            Console.Write("Año: ");
            int año = int.Parse(Console.ReadLine());
            Console.Write("Precio de Venta: ");
            double precioVenta = double.Parse(Console.ReadLine());

            Vehiculo nuevoVehiculo = new Vehiculo(numeroSerie, marca, modelo, año, precioVenta);
            vehiculos.Add(nuevoVehiculo);
            Console.WriteLine("Vehículo agregado con éxito.");
        }

        static void ActualizarVehiculo(List<Vehiculo> vehiculos)
        {
            Console.WriteLine("Actualizar Vehículo");
            Console.Write("Ingrese el número de serie del vehículo a actualizar: ");
            string numeroSerie = Console.ReadLine();
            Vehiculo vehiculo = vehiculos.Find(v => v.NumeroSerie == numeroSerie);
            if (vehiculo != null)
            {
                Console.Write("Nueva Marca: ");
                vehiculo.Marca = Console.ReadLine();
                Console.Write("Nuevo Modelo: ");
                vehiculo.Modelo = Console.ReadLine();
                Console.Write("Nuevo Año: ");
                vehiculo.Año = int.Parse(Console.ReadLine());
                Console.Write("Nuevo Precio de Venta: ");
                vehiculo.PrecioVenta = double.Parse(Console.ReadLine());

                // Agregamos un mensaje al historial
                vehiculo.AgregarAlHistorial($"Actualización: {vehiculo.Marca} {vehiculo.Modelo}, Año: {vehiculo.Año}, Precio: {vehiculo.PrecioVenta}");

                Console.WriteLine("Vehículo actualizado con éxito.");
            }
            else
            {
                Console.WriteLine("Vehículo no encontrado.");
            }
        }

        static void VerHistorialVehiculo(List<Vehiculo> vehiculos)
        {
            Console.WriteLine("Ver Historial de Vehículo");
            Console.Write("Ingrese el número de serie del vehículo: ");
            string numeroSerie = Console.ReadLine();
            Vehiculo vehiculo = vehiculos.Find(v => v.NumeroSerie == numeroSerie);
            if (vehiculo != null)
            {
                vehiculo.MostrarHistorial();
            }
            else
            {
                Console.WriteLine("Vehículo no encontrado.");
            }
        }

        static void AgregarCliente(List<Cliente> clientes)
        {
            Console.WriteLine("Agregar Cliente");
            Console.Write("ID Cliente: ");
            string idCliente = Console.ReadLine();
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();

            Cliente nuevoCliente = new Cliente(idCliente, nombre, direccion);
            clientes.Add(nuevoCliente);
            Console.WriteLine("Cliente agregado con éxito.");
        }

        static void GestionarEmpleados(List<Empleado> empleados)
        {
            Console.WriteLine("Gestión de Empleados:");
            foreach (var empleado in empleados)
            {
                empleado.MostrarRol();
            }
        }

    }
    
}