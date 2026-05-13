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
            Console.WriteLine("=== REGISTRAR CLIENTE ===");
            
            Console.Write("Ingrese identificación: ");
            string identificacion = Console.ReadLine()?.Trim() ?? "";
            
            if (string.IsNullOrEmpty(identificacion))
            {
                Console.WriteLine("La identificación no puede estar vacía.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            Console.Write("Ingrese nombre completo: ");
            string nombreCompleto = Console.ReadLine()?.Trim() ?? "";
            
            if (string.IsNullOrEmpty(nombreCompleto))
            {
                Console.WriteLine("El nombre completo no puede estar vacío.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            Console.Write("Ingrese número de cuenta: ");
            string numeroCuenta = Console.ReadLine()?.Trim() ?? "";
            
            if (string.IsNullOrEmpty(numeroCuenta))
            {
                Console.WriteLine("El número de cuenta no puede estar vacío.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            Console.Write("Ingrese saldo inicial (opcional, presione Enter para 0): ");
            string saldoStr = Console.ReadLine()?.Trim() ?? "0";
            
            decimal saldoInicial = 0;
            if (!string.IsNullOrEmpty(saldoStr) && !decimal.TryParse(saldoStr, out saldoInicial))
            {
                Console.WriteLine("Saldo inválido. Se usará 0.");
                saldoInicial = 0;
            }
            
            if (saldoInicial < 0)
            {
                Console.WriteLine("El saldo inicial no puede ser negativo. Se usará 0.");
                saldoInicial = 0;
            }
            
            bool exito = banco.RegistrarCliente(identificacion, nombreCompleto, numeroCuenta, saldoInicial);
            
            if (exito)
            {
                Console.WriteLine("Cliente registrado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: Ya existe un cliente con esa identificación o número de cuenta.");
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
                Console.WriteLine("No hay clientes registrados.");
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
            
            Console.Write("Ingrese identificación del cliente: ");
            string identificacion = Console.ReadLine()?.Trim() ?? "";
            
            if (string.IsNullOrEmpty(identificacion))
            {
                Console.WriteLine("La identificación no puede estar vacía.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            Cliente cliente = banco.BuscarCliente(identificacion);
            
            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
            }
            else
            {
                Console.WriteLine("Cliente encontrado:");
                Console.WriteLine(cliente);
            }
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
        private void OpcionAgregarACola()
        {
            Console.WriteLine("=== AGREGAR CLIENTE A COLA DE ATENCIÓN ===");
            
            Console.Write("Ingrese identificación del cliente: ");
            string identificacion = Console.ReadLine()?.Trim() ?? "";
            
            if (string.IsNullOrEmpty(identificacion))
            {
                Console.WriteLine("La identificación no puede estar vacía.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            bool exito = banco.AgregarClienteACola(identificacion);
            
            if (exito)
            {
                Console.WriteLine("Cliente agregado a la cola de atención exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: Cliente no encontrado.");
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
                Console.WriteLine("No hay clientes en la cola de atención.");
            }
            else
            {
                Console.WriteLine("Cliente atendido:");
                Console.WriteLine(cliente);
            }
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionRealizarDeposito()
        {
            Console.WriteLine("=== REALIZAR DEPÓSITO ===");
            
            Console.Write("Ingrese número de cuenta: ");
            string numeroCuenta = Console.ReadLine()?.Trim() ?? "";
            
            if (string.IsNullOrEmpty(numeroCuenta))
            {
                Console.WriteLine("El número de cuenta no puede estar vacío.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            Console.Write("Ingrese monto a depositar: ");
            string montoStr = Console.ReadLine()?.Trim() ?? "";
            
            if (!decimal.TryParse(montoStr, out decimal monto) || monto <= 0)
            {
                Console.WriteLine("Monto inválido. Debe ser un número positivo.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            bool exito = banco.RealizarDeposito(numeroCuenta, monto);
            
            if (exito)
            {
                Console.WriteLine($"Depósito de ${monto:F2} realizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: No se pudo realizar el depósito. Verifique el número de cuenta.");
            }
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionRealizarRetiro()
        {
            Console.WriteLine("=== REALIZAR RETIRO ===");
            
            Console.Write("Ingrese número de cuenta: ");
            string numeroCuenta = Console.ReadLine()?.Trim() ?? "";
            
            if (string.IsNullOrEmpty(numeroCuenta))
            {
                Console.WriteLine("El número de cuenta no puede estar vacío.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            Console.Write("Ingrese monto a retirar: ");
            string montoStr = Console.ReadLine()?.Trim() ?? "";
            
            if (!decimal.TryParse(montoStr, out decimal monto) || monto <= 0)
            {
                Console.WriteLine("Monto inválido. Debe ser un número positivo.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            bool exito = banco.RealizarRetiro(numeroCuenta, monto);
            
            if (exito)
            {
                Console.WriteLine($"Retiro de ${monto:F2} realizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: No se pudo realizar el retiro. Verifique el número de cuenta y el saldo disponible.");
            }
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionConsultarSaldo()
        {
            Console.WriteLine("=== CONSULTAR SALDO ===");
            
            Console.Write("Ingrese número de cuenta: ");
            string numeroCuenta = Console.ReadLine()?.Trim() ?? "";
            
            if (string.IsNullOrEmpty(numeroCuenta))
            {
                Console.WriteLine("El número de cuenta no puede estar vacío.");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }
            
            Cliente cliente = banco.BuscarClientePorCuenta(numeroCuenta);
            
            if (cliente == null)
            {
                Console.WriteLine("Cuenta no encontrada.");
            }
            else
            {
                Console.WriteLine($"Saldo actual: ${cliente.Saldo:F2}");
            }
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionDeshacerTransaccion()
        {
            Console.WriteLine("=== DESHACER ÚLTIMA TRANSACCIÓN ===");
            
            Transaccion? transaccion = banco.DeshacerUltimaTransaccion();
            
            if (transaccion == null)
            {
                Console.WriteLine("No hay transacciones para deshacer.");
            }
            else
            {
                Console.WriteLine("Transacción deshecha:");
                Console.WriteLine(transaccion);
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
                Console.WriteLine("No hay clientes en la cola de atención.");
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

        private void OpcionMostrarTotalClientes()
        {
            Console.WriteLine("=== TOTAL DE CLIENTES ===");
            
            int totalClientes = banco.ObtenerTotalClientes();
            Console.WriteLine($"Total de clientes registrados: {totalClientes}");
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionMostrarTotalDinero()
        {
            Console.WriteLine("=== TOTAL DE DINERO DEL BANCO ===");
            
            decimal totalDinero = banco.ObtenerTotalDinero();
            Console.WriteLine($"Total de dinero en todas las cuentas: ${totalDinero:F2}");
            
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
