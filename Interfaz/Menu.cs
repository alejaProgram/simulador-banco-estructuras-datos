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

        private void OpcionRegistrarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR CLIENTE ===");
            
            Console.Write("Identificación: ");
            string identificacion = Console.ReadLine();
            
            Console.Write("Nombre completo: ");
            string nombre = Console.ReadLine();
            
            Console.Write("Número de cuenta: ");
            string numeroCuenta = Console.ReadLine();
            
            Console.Write("Saldo inicial (opcional, presione Enter para 0): ");
            string saldoStr = Console.ReadLine();
            decimal saldo = 0;
            if (!string.IsNullOrEmpty(saldoStr) && decimal.TryParse(saldoStr, out saldo))
            {
                // Saldo válido
            }

            if (banco.RegistrarCliente(identificacion, nombre, numeroCuenta, saldo))
            {
                Console.WriteLine("✓ Cliente registrado exitosamente.");
            }
            else
            {
                Console.WriteLine("✗ Error: Ya existe un cliente con esa identificación o número de cuenta.");
            }
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionListarClientes()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE CLIENTES ===");
            
            Cliente[] clientes = banco.ListarClientes();
            
            if (clientes.Length == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
            }
            else
            {
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
            Console.Clear();
            Console.WriteLine("=== BUSCAR CLIENTE ===");
            
            Console.Write("Ingrese identificación del cliente: ");
            string identificacion = Console.ReadLine();
            
            Cliente cliente = banco.BuscarCliente(identificacion);
            
            if (cliente != null)
            {
                Console.WriteLine($"Cliente encontrado: {cliente}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionAgregarACola()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR CLIENTE A COLA DE ATENCIÓN ===");
            
            Console.Write("Ingrese identificación del cliente: ");
            string identificacion = Console.ReadLine();
            
            if (banco.AgregarACola(identificacion))
            {
                Console.WriteLine("✓ Cliente agregado a la cola de atención.");
            }
            else
            {
                Console.WriteLine("✗ Error: Cliente no encontrado o ya está en la cola.");
            }
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionAtenderSiguiente()
        {
            Console.Clear();
            Console.WriteLine("=== ATENDER SIGUIENTE CLIENTE ===");
            
            Cliente cliente = banco.AtenderSiguiente();
            
            if (cliente != null)
            {
                Console.WriteLine($"✓ Atendiendo a: {cliente.NombreCompleto} (ID: {cliente.Identificacion})");
            }
            else
            {
                Console.WriteLine("✗ No hay clientes en la cola de atención.");
            }
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionRealizarDeposito()
        {
            Console.Clear();
            Console.WriteLine("=== REALIZAR DEPÓSITO ===");
            
            Console.Write("Número de cuenta: ");
            string numeroCuenta = Console.ReadLine();
            
            Console.Write("Monto a depositar: ");
            string montoStr = Console.ReadLine();
            
            if (decimal.TryParse(montoStr, out decimal monto) && monto > 0)
            {
                if (banco.RealizarDeposito(numeroCuenta, monto))
                {
                    Console.WriteLine($"✓ Depósito de ${monto:F2} realizado exitosamente.");
                }
                else
                {
                    Console.WriteLine("✗ Error: No se pudo realizar el depósito (cuenta no encontrada).");
                }
            }
            else
            {
                Console.WriteLine("✗ Error: Monto inválido.");
            }
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionRealizarRetiro()
        {
            Console.Clear();
            Console.WriteLine("=== REALIZAR RETIRO ===");
            
            Console.Write("Número de cuenta: ");
            string numeroCuenta = Console.ReadLine();
            
            Console.Write("Monto a retirar: ");
            string montoStr = Console.ReadLine();
            
            if (decimal.TryParse(montoStr, out decimal monto) && monto > 0)
            {
                if (banco.RealizarRetiro(numeroCuenta, monto))
                {
                    Console.WriteLine($"✓ Retiro de ${monto:F2} realizado exitosamente.");
                }
                else
                {
                    Console.WriteLine("✗ Error: No se pudo realizar el retiro (cuenta no encontrada o saldo insuficiente).");
                }
            }
            else
            {
                Console.WriteLine("✗ Error: Monto inválido.");
            }
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionConsultarSaldo()
        {
            Console.Clear();
            Console.WriteLine("=== CONSULTAR SALDO ===");
            
            Console.Write("Número de cuenta: ");
            string numeroCuenta = Console.ReadLine();
            
            decimal saldo = banco.ConsultarSaldo(numeroCuenta);
            
            if (saldo >= 0)
            {
                Console.WriteLine($"Saldo actual: ${saldo:F2}");
            }
            else
            {
                Console.WriteLine("✗ Error: Cuenta no encontrada.");
            }
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionDeshacerTransaccion()
        {
            Console.Clear();
            Console.WriteLine("=== DESHACER ÚLTIMA TRANSACCIÓN ===");
            
            if (banco.HayTransaccionesPendientes())
            {
                Transaccion ultimaTransaccion = banco.VerUltimaTransaccion();
                Console.WriteLine($"Última transacción: {ultimaTransaccion}");
                
                Console.Write("¿Desea deshacer esta transacción? (S/N): ");
                string confirmacion = Console.ReadLine();
                
                if (confirmacion.ToUpper() == "S")
                {
                    if (banco.DeshacerUltimaTransaccion())
                    {
                        Console.WriteLine("✓ Transacción deshecha exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("✗ Error: No se pudo deshacer la transacción.");
                    }
                }
                else
                {
                    Console.WriteLine("Operación cancelada.");
                }
            }
            else
            {
                Console.WriteLine("✗ No hay transacciones para deshacer.");
            }
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionMostrarCola()
        {
            Console.Clear();
            Console.WriteLine("=== COLA DE ATENCIÓN ===");
            
            Cliente[] clientesEnCola = banco.VerColaActual();
            
            if (clientesEnCola.Length == 0)
            {
                Console.WriteLine("No hay clientes en la cola de atención.");
            }
            else
            {
                Console.WriteLine($"Clientes en espera: {clientesEnCola.Length}");
                for (int i = 0; i < clientesEnCola.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {clientesEnCola[i].NombreCompleto} (ID: {clientesEnCola[i].Identificacion})");
                }
            }
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionMostrarTotalClientes()
        {
            Console.Clear();
            Console.WriteLine("=== TOTAL DE CLIENTES ===");
            
            int total = banco.ObtenerTotalClientes();
            Console.WriteLine($"Total de clientes registrados: {total}");
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionMostrarTotalDinero()
        {
            Console.Clear();
            Console.WriteLine("=== TOTAL DE DINERO DEL BANCO ===");
            
            decimal total = banco.ObtenerTotalDinero();
            Console.WriteLine($"Total de dinero en todas las cuentas: ${total:F2}");
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
