using System;
using System.Text;
using Validacion;

namespace Interfaz
{
    public partial class Menu
    {
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
    }
}
