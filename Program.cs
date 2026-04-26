using System;
using Interfaz;

namespace SimuladorBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SIMULADOR BANCARIO - ESTRUCTURAS DE DATOS ===");
            Console.WriteLine("Proyecto Final - Estructuras de Datos");
            Console.WriteLine();
            
            Menu menu = new Menu();
            menu.MostrarMenuPrincipal();
        }
    }
}
