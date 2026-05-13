using System;
using Validacion;

namespace Entidades
{

    public enum TipoTransaccion
    {
        Deposito,
        Retiro
    }

    public class Transaccion
    {
        public string NumeroCuenta { get; set; }
        public decimal Monto { get; set; }
        public TipoTransaccion Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal SaldoNuevo { get; set; }

        public Transaccion(string numeroCuenta, decimal monto, TipoTransaccion tipo, decimal saldoAnterior, decimal saldoNuevo)
        {
            NumeroCuenta = numeroCuenta;
            Monto = monto;
            Tipo = tipo;
            Fecha = DateTime.Now;
            SaldoAnterior = saldoAnterior;
            SaldoNuevo = saldoNuevo;
        }

        public override string ToString()
        {
            string tipoStr = Tipo == TipoTransaccion.Deposito ? "DEPÓSITO" : "RETIRO";
            return $"{Fecha:dd/MM/yyyy HH:mm:ss} | Cuenta: {NumeroCuenta} | {tipoStr}: {ValidacionesSistema.FormatearMonedaCOP(Monto)} | Saldo: {ValidacionesSistema.FormatearMonedaCOP(SaldoAnterior)} -> {ValidacionesSistema.FormatearMonedaCOP(SaldoNuevo)}";
        }
    }
}
