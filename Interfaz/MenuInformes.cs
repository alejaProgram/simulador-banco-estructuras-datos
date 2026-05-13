using System;
using Logica;
using Validacion;

namespace Interfaz
{
    public partial class Menu
    {
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
