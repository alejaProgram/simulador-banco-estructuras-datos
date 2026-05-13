using System;
using System.Text;
using Entidades;
using Logica;
using Validacion;

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
                try
                {
                    Console.Clear();
                    Console.WriteLine($"=== {Banco.NombreBanco} ===");
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

                    string? lineaOpcion = Console.ReadLine();
                    if (!ValidacionesSistema.EsOpcionMenuValida(lineaOpcion, out int numeroOpcion))
                    {
                        Console.WriteLine(ValidacionesSistema.MsgOpcionInvalida);
                        Console.WriteLine("Presione Enter para continuar...");
                        Console.ReadLine();
                        continue;
                    }

                    switch (numeroOpcion)
                    {
                        case 1:
                            OpcionRegistrarCliente();
                            break;
                        case 2:
                            OpcionListarClientes();
                            break;
                        case 3:
                            OpcionBuscarCliente();
                            break;
                        case 4:
                            OpcionAgregarACola();
                            break;
                        case 5:
                            OpcionAtenderSiguiente();
                            break;
                        case 6:
                            OpcionRealizarDeposito();
                            break;
                        case 7:
                            OpcionRealizarRetiro();
                            break;
                        case 8:
                            OpcionConsultarSaldo();
                            break;
                        case 9:
                            OpcionDeshacerTransaccion();
                            break;
                        case 10:
                            OpcionMostrarCola();
                            break;
                        case 11:
                            OpcionMostrarTotalClientes();
                            break;
                        case 12:
                            OpcionMostrarTotalDinero();
                            break;
                        case 13:
                            Console.WriteLine($"¡Gracias por usar {Banco.NombreBanco}!");
                            return;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(ValidacionesSistema.MsgErrorInesperado);
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ReadLine();
                }
            }
        }

        private static string LeerDigitosConsola(int maxDigitos)
        {
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                ConsoleKeyInfo tecla = Console.ReadKey(intercept: true);

                if (tecla.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                if (tecla.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        sb.Length--;
                        Console.Write("\b \b");
                    }
                    continue;
                }

                if (char.IsDigit(tecla.KeyChar) && sb.Length < maxDigitos)
                {
                    sb.Append(tecla.KeyChar);
                    Console.Write(tecla.KeyChar);
                }
            }

            return sb.ToString();
        }

        private static string PedirCedulaHastaValido()
        {
            bool mostrarRecordatorio = false;

            while (true)
            {
                if (mostrarRecordatorio)
                    Console.WriteLine(ValidacionesSistema.MsgReintentoCedula);

                Console.Write("Cédula: ");
                string cedula = LeerDigitosConsola(ValidacionesSistema.MaxDigitosCedula);

                if (ValidacionesSistema.EsCedulaValida(cedula, out string normalizada, out _))
                    return normalizada;

                mostrarRecordatorio = true;
            }
        }

        private static string PedirNumeroCuentaHastaValido()
        {
            bool mostrarRecordatorio = false;

            while (true)
            {
                if (mostrarRecordatorio)
                    Console.WriteLine(ValidacionesSistema.MsgReintentoCuenta);

                Console.Write("Número de cuenta: ");
                string numeroCuenta = LeerDigitosConsola(ValidacionesSistema.DigitosNumeroCuenta);

                if (ValidacionesSistema.EsNumeroCuentaValido(numeroCuenta, out _))
                    return numeroCuenta.Trim();

                mostrarRecordatorio = true;
            }
        }

        private static string PedirNombreHastaValido()
        {
            while (true)
            {
                Console.Write("Nombre completo: ");
                string? linea = Console.ReadLine();
                if (ValidacionesSistema.EsNombreValido(linea, out string nombre, out string error))
                    return nombre;

                Console.WriteLine(error);
            }
        }

        private static decimal PedirSaldoInicialHastaValido()
        {
            while (true)
            {
                Console.WriteLine("Saldo inicial en pesos colombianos (COP).");
                Console.WriteLine($"Pulse solo Enter para {ValidacionesSistema.FormatearMonedaCOP(0)}.");
                Console.WriteLine($"Si escribe un importe, debe ser al menos {ValidacionesSistema.FormatearMonedaCOP(ValidacionesSistema.SaldoInicialMinimoCopsSiNoEsCero)} (ej. 1000, 1.000, 500000).");
                Console.Write("Importe en COP: ");
                string? linea = Console.ReadLine();
                if (ValidacionesSistema.EsSaldoInicialValido(linea, out decimal saldo, out string error))
                    return saldo;

                Console.WriteLine(error);
                Console.WriteLine();
            }
        }

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

        private void OpcionRealizarDeposito()
        {
            Console.WriteLine("=== REALIZAR DEPÓSITO ===");

            string numeroCuenta = PedirNumeroCuentaHastaValido();

            Cliente? clientePrevio = banco.BuscarClientePorCuenta(numeroCuenta);
            if (clientePrevio == null)
            {
                Console.WriteLine(ValidacionesSistema.MsgCuentaNoExiste);
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.Write("Ingrese monto a depositar: ");
            if (!ValidacionesSistema.EsMontoTransaccionValido(Console.ReadLine(), out decimal monto, out string errorMonto))
            {
                Console.WriteLine(errorMonto);
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            if (!ValidacionesSistema.SaldoResultanteValidoTrasDeposito(clientePrevio.Saldo, monto, out string errorSaldo))
            {
                Console.WriteLine(errorSaldo);
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            bool exito = banco.RealizarDeposito(numeroCuenta, monto, out Transaccion? transaccion);

            if (exito && transaccion != null)
            {
                Console.WriteLine($"Depósito de {ValidacionesSistema.FormatearMonedaCOP(monto)} realizado exitosamente.");
                Console.WriteLine($"Fecha de la transacción: {transaccion.Fecha:dd/MM/yyyy HH:mm:ss}");
            }
            else
            {
                Console.WriteLine(ValidacionesSistema.MsgDepositoNoCompletado);
            }

            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionRealizarRetiro()
        {
            Console.WriteLine("=== REALIZAR RETIRO ===");

            string numeroCuenta = PedirNumeroCuentaHastaValido();

            Cliente? cliente = banco.BuscarClientePorCuenta(numeroCuenta);
            if (cliente == null)
            {
                Console.WriteLine(ValidacionesSistema.MsgCuentaNoExiste);
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.Write("Ingrese monto a retirar: ");
            if (!ValidacionesSistema.EsMontoTransaccionValido(Console.ReadLine(), out decimal monto, out string errorMonto))
            {
                Console.WriteLine(errorMonto);
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            if (!ValidacionesSistema.HaySaldoSuficiente(cliente.Saldo, monto, out string errorSaldo))
            {
                Console.WriteLine(errorSaldo);
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Console.Write("¿Desea confirmar el retiro? (S/N): ");
            if (!ValidacionesSistema.EsConfirmacionSi(Console.ReadLine()))
            {
                Console.WriteLine(ValidacionesSistema.MsgOperacionCancelada);
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            Cliente? clienteConfirmacion = banco.BuscarClientePorCuenta(numeroCuenta);
            if (clienteConfirmacion == null)
            {
                Console.WriteLine(ValidacionesSistema.MsgCuentaNoExiste);
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            if (!ValidacionesSistema.HaySaldoSuficiente(clienteConfirmacion.Saldo, monto, out string errorSaldoConfirmacion))
            {
                Console.WriteLine(errorSaldoConfirmacion);
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
                return;
            }

            bool exito = banco.RealizarRetiro(numeroCuenta, monto, out Transaccion? transaccion);

            if (exito && transaccion != null)
            {
                Console.WriteLine($"Retiro de {ValidacionesSistema.FormatearMonedaCOP(monto)} realizado exitosamente.");
                Console.WriteLine($"Fecha de la transacción: {transaccion.Fecha:dd/MM/yyyy HH:mm:ss}");
            }
            else
            {
                Console.WriteLine(ValidacionesSistema.MsgRetiroNoCompletado);
            }

            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        private void OpcionConsultarSaldo()
        {
            Console.WriteLine("=== CONSULTAR SALDO ===");

            string numeroCuenta = PedirNumeroCuentaHastaValido();

            Cliente? cliente = banco.BuscarClientePorCuenta(numeroCuenta);

            if (cliente == null)
            {
                Console.WriteLine(ValidacionesSistema.MsgCuentaNoExiste);
            }
            else
            {
                Console.WriteLine($"Saldo actual: {ValidacionesSistema.FormatearMonedaCOP(cliente.Saldo)}");
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
                Console.WriteLine(ValidacionesSistema.MsgSinTransacciones);
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
            Console.WriteLine($"Total de dinero en todas las cuentas de {Banco.NombreBanco}: {ValidacionesSistema.FormatearMonedaCOP(totalDinero)}");

            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
