using System;
using Entidades;
using Logica;
using Validacion;

namespace Interfaz
{
    public partial class Menu
    {
        private void OpcionRegistrarCliente()
        {
            Console.WriteLine("=== REGISTRAR CLIENTE ===");

            string identificacion = PedirCedulaHastaValido();
            string numeroCuenta = PedirNumeroCuentaHastaValido();

            if (banco.ExisteClienteConIdentificacion(identificacion))
            {
                Console.WriteLine(ValidacionesSistema.MsgCedulaDuplicada);
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            if (banco.ExisteClienteConNumeroCuenta(numeroCuenta))
            {
                Console.WriteLine(ValidacionesSistema.MsgCuentaDuplicada);
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            string nombreCompleto = PedirNombreHastaValido();
            decimal saldoInicial = PedirSaldoInicialHastaValido();

            bool exito = banco.RegistrarCliente(identificacion, nombreCompleto, numeroCuenta, saldoInicial);

            if (exito)
            {
                Console.WriteLine("Cliente registrado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se pudo registrar el cliente. Verifique los datos.");
            }

            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionListarClientes()
        {
            Console.WriteLine("=== LISTA DE CLIENTES ===");

            Cliente[] clientes = banco.ListarClientes();

            if (clientes.Length == 0)
            {
                Console.WriteLine(ValidacionesSistema.MsgListaClientesVacia);
            }
            else
            {
                Console.WriteLine($"Total de clientes: {clientes.Length}");
                Console.WriteLine();

                for (int i = 0; i < clientes.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {clientes[i]}");
                }
            }

            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionBuscarCliente()
        {
            Console.WriteLine("=== BUSCAR CLIENTE ===");

            string identificacion = PedirCedulaHastaValido();

            Cliente? cliente = banco.BuscarCliente(identificacion);

            if (cliente == null)
            {
                Console.WriteLine(ValidacionesSistema.MsgClienteNoEncontrado);
            }
            else
            {
                Console.WriteLine("Cliente encontrado:");
                Console.WriteLine(cliente);
            }

            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
