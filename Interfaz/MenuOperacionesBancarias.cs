using System;
using Entidades;
using Logica;
using Validacion;

namespace Interfaz
{
    public partial class Menu
    {
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
    }
}
