using System;
using Entidades;
using Logica;
using Validacion;

namespace Interfaz
{
    public partial class Menu
    {
        private void OpcionAgregarACola()
        {
            Console.WriteLine("=== AGREGAR CLIENTE A COLA DE ATENCIÓN ===");

            string identificacion = PedirCedulaHastaValido();

            ResultadoEncolarCliente resultado = banco.AgregarClienteACola(identificacion);

            switch (resultado)
            {
                case ResultadoEncolarCliente.Exito:
                    Console.WriteLine("Cliente agregado a la cola de atención exitosamente.");
                    break;
                case ResultadoEncolarCliente.ClienteNoExiste:
                    Console.WriteLine(ValidacionesSistema.MsgClienteNoExisteCola);
                    break;
                case ResultadoEncolarCliente.YaEstaEnCola:
                    Console.WriteLine(ValidacionesSistema.MsgClienteYaEnCola);
                    break;
            }

            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionAtenderSiguiente()
        {
            Console.WriteLine("=== ATENDER SIGUIENTE CLIENTE ===");

            Cliente? cliente = banco.AtenderSiguienteCliente();

            if (cliente == null)
            {
                Console.WriteLine(ValidacionesSistema.MsgColaVaciaAtender);
            }
            else
            {
                Console.WriteLine("Cliente atendido:");
                Console.WriteLine(cliente);
            }

            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionMostrarCola()
        {
            Console.WriteLine("=== COLA DE ATENCIÓN ===");

            Cliente[] clientesEnCola = banco.ObtenerClientesEnCola();

            if (clientesEnCola.Length == 0)
            {
                Console.WriteLine(ValidacionesSistema.MsgColaVaciaMostrar);
            }
            else
            {
                Console.WriteLine($"Clientes en cola: {clientesEnCola.Length}");
                Console.WriteLine();

                for (int i = 0; i < clientesEnCola.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {clientesEnCola[i]}");
                }
            }

            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
