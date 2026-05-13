using System;
using Interfaz;
using Logica;

namespace SimuladorBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"=== {Banco.NombreBanco} — SIMULADOR BANCARIO ===");
            Console.WriteLine("Proyecto Final - Estructuras de Datos");
            Console.WriteLine();
            
            Menu menu = new Menu();
            menu.MostrarMenuPrincipal();
        }
    }
}
