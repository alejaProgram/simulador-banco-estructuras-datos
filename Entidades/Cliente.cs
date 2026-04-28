using System;

namespace Entidades
{
    public class Cliente
    {
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }

        public Cliente(string identificacion, string nombreCompleto, string numeroCuenta, decimal saldoInicial = 0)
        {
            Identificacion = identificacion;
            NombreCompleto = nombreCompleto;
            NumeroCuenta = numeroCuenta;
            Saldo = saldoInicial;
        }
    }
}
