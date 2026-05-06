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

        public Cliente BuscarClientePorCuenta(string numeroCuenta)
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


    }
}
