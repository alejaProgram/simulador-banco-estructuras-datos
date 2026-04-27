using Entidades;
using Estructuras;

namespace Logica
{
    public class Banco
    {
        private ListaEnlazadaClientes clientes;

        public Banco()
        {
            clientes = new ListaEnlazadaClientes();
        }
        public bool RegistrarCliente(string identificacion, string nombreCompleto, string numeroCuenta, decimal saldoInicial = 0)
        {
            return false;
        }

        public Cliente BuscarCliente(string identificacion)
        {
            return null;
        }

        public Cliente[] ListarClientes()
        {
            return null;
        }

        public int ObtenerTotalClientes()
        {
            return 0;
        }

        public decimal ObtenerTotalDinero()
        {
            return 0;
        }

        public bool AgregarACola(string identificacion)
        {
            return false;
        }

        public Cliente AtenderSiguiente()
        {
            return null;
        }

        public bool RealizarDeposito(string numeroCuenta, decimal monto)
        {
            return false;
        }

        public bool RealizarRetiro(string numeroCuenta, decimal monto)
        {
            return false;
        }

        public decimal ConsultarSaldo(string numeroCuenta)
        {
            return 0;
        }

        public bool DeshacerUltimaTransaccion()
        {
            return false;
        }
    }
}
