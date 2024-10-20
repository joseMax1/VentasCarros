﻿// MAXIMILIANO JOSE DE LEON CERA
// Etapa 3 - Jerarquía de clases y métodos
// GRUPO 213023_30

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
            List<Venta> ventas = new List<Venta>();  // Lista para registrar las ventas

            // Crear algunos empleados iniciales
            {
                empleados.Add(new Vendedor("01", "Maximiliano", "Vendedor"));
                empleados.Add(new Gerente("02", "Jose", "Gerente"));

            };

            // Realizo un menu interativo donde se pueden realizar diferente acciones

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Selecciona una opcion: \n");
                Console.WriteLine("1. Agregar Vehiculo: \n");
                Console.WriteLine("2. Actualizar Vehiculo: \n");
                Console.WriteLine("3. Ver Historial de Vehiculo: \n");
                Console.WriteLine("4. Agregar cliente: \n");
                Console.WriteLine("5. Gestionar empleado: \n");
                Console.WriteLine("6. Registrar venta de Vehículo: \n"); // nueva opcion para venta
                Console.WriteLine("0. Salir: \n");


                int opcion = int.Parse(Console.ReadLine());
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

                    case 6:
                        RegistrarVenta(ventas, vehiculos, clientes, empleados);  // Llamar función de ventas
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

        static void RegistrarVenta(List<Venta> ventas, List<Vehiculo> vehiculos, List<Cliente> clientes, List<Empleado> empleados)
        {
            {
                Console.WriteLine("Registrar Venta");

                // Buscar el vehículo
                Console.Write("Ingrese el número de serie del vehículo: ");
                string numeroSerie = Console.ReadLine();
                Vehiculo vehiculo = vehiculos.Find(v => v.NumeroSerie == numeroSerie);
                if (vehiculo == null || vehiculo.Estado != "Disponible")
                {
                    Console.WriteLine("Vehículo no encontrado o no disponible.");
                    return;
                }

                // Buscar el cliente
                Console.Write("Ingrese ID del cliente: ");
                string idCliente = Console.ReadLine();
                Cliente cliente = clientes.Find(c => c.IdCliente == idCliente);
                if (cliente == null)
                {
                    Console.WriteLine("Cliente no encontrado.");
                    return;
                }

                // Buscar el empleado
                Console.Write("Ingrese ID del empleado: ");
                string idEmpleado = Console.ReadLine();
                Empleado empleado = empleados.Find(e => e.IdEmpleado == idEmpleado);
                if (empleado == null)
                {
                    Console.WriteLine("Empleado no encontrado.");
                    return;
                }

                // Generar un ID único para la venta
                string idVenta = Guid.NewGuid().ToString(); // Esto genera un ID único y aleatorio

                // Pedir el precio final de la venta
                Console.Write("Ingrese el precio final de la venta: ");
                double precioFinal = double.Parse(Console.ReadLine());

                // Crear la venta con todos los parámetros necesarios
                Venta nuevaVenta = new Venta(idVenta, vehiculo, cliente, empleado, precioFinal);
                ventas.Add(nuevaVenta);

                // Cambiar el estado del vehículo a vendido
                vehiculo.Estado = "Vendido";
                vehiculo.AgregarAlHistorial($"Vehículo vendido a {cliente.Nombre} por {empleado.Nombre} el {nuevaVenta.FechaVenta}");

                Console.WriteLine("Venta registrada con éxito.");
            }


        }

    }
}