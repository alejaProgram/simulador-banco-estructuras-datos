using System;
using Entidades;
using Logica;

namespace Interfaz
{
    public class Menu
    {
        private Banco banco;

        public Menu()
        {
            banco = new Banco();
        }

        public void MostrarMenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SIMULADOR BANCARIO ===");
                Console.WriteLine("1. Registrar cliente");
                Console.WriteLine("2. Listar clientes");
                Console.WriteLine("3. Buscar cliente");
                Console.WriteLine("4. Agregar cliente a la cola de atención");
                Console.WriteLine("5. Atender siguiente cliente");
                Console.WriteLine("6. Realizar depósito");
                Console.WriteLine("7. Realizar retiro");
                Console.WriteLine("8. Consultar saldo");
                Console.WriteLine("9. Deshacer última transacción");
                Console.WriteLine("10. Mostrar cola de atención");
                Console.WriteLine("11. Mostrar total de clientes");
                Console.WriteLine("12. Mostrar total de dinero del banco");
                Console.WriteLine("13. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        OpcionRegistrarCliente();
                        break;
                    case "2":
                        OpcionListarClientes();
                        break;
                    case "3":
                        OpcionBuscarCliente();
                        break;
                    case "4":
                        OpcionAgregarACola();
                        break;
                    case "5":
                        OpcionAtenderSiguiente();
                        break;
                    case "6":
                        OpcionRealizarDeposito();
                        break;
                    case "7":
                        OpcionRealizarRetiro();
                        break;
                    case "8":
                        OpcionConsultarSaldo();
                        break;
                    case "9":
                        OpcionDeshacerTransaccion();
                        break;
                    case "10":
                        OpcionMostrarCola();
                        break;
                    case "11":
                        OpcionMostrarTotalClientes();
                        break;
                    case "12":
                        OpcionMostrarTotalDinero();
                        break;
                    case "13":
                        Console.WriteLine("¡Gracias por usar el simulador bancario!");
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Presione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // TODO: Aleja debe implementar estas opciones (parte 1)
        private void OpcionRegistrarCliente()
        {
            // Implementación pendiente - Commit 17
            Console.WriteLine("Opción en desarrollo...");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionListarClientes()
        {
            // Implementación pendiente - Commit 18
            Console.WriteLine("Opción en desarrollo...");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionBuscarCliente()
        {
            // Implementación pendiente - Commit 19
            Console.WriteLine("Opción en desarrollo...");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        // TODO: Salo debe implementar estas opciones (parte 2)
        private void OpcionAgregarACola()
        {
            // Implementación pendiente - Salo
            Console.WriteLine("Opción en desarrollo...");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionAtenderSiguiente()
        {
            // Implementación pendiente - Salo
            Console.WriteLine("Opción en desarrollo...");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionRealizarDeposito()
        {
            // Implementación pendiente - Salo
            Console.WriteLine("Opción en desarrollo...");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionRealizarRetiro()
        {
            // Implementación pendiente - Salo
            Console.WriteLine("Opción en desarrollo...");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionConsultarSaldo()
        {
            // Implementación pendiente - Salo
            Console.WriteLine("Opción en desarrollo...");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionDeshacerTransaccion()
        {
            // Implementación pendiente - Salo
            Console.WriteLine("Opción en desarrollo...");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionMostrarCola()
        {
            // Implementación pendiente - Salo
            Console.WriteLine("Opción en desarrollo...");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionMostrarTotalClientes()
        {
            // Implementación pendiente - Aleja - Commit 20
            Console.WriteLine("Opción en desarrollo...");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionMostrarTotalDinero()
        {
            // Implementación pendiente - Aleja - Commit 20
            Console.WriteLine("Opción en desarrollo...");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
