using System;
using Validacion;

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

        public void Depositar(decimal monto)
        {
            if (monto > 0)
            {
                Saldo += monto;
            }
        }

        public bool Retirar(decimal monto)
        {
            if (monto > 0 && Saldo >= monto)
            {
                Saldo -= monto;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"ID: {Identificacion} | Nombre: {NombreCompleto} | Cuenta: {NumeroCuenta} | Saldo: {ValidacionesSistema.FormatearMonedaCOP(Saldo)}";
        }
    }
}
