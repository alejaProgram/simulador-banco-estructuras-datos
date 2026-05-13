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
            if (clientes.ExisteCliente(identificacion, numeroCuenta))
            {
                return false;
            }

            Cliente nuevoCliente = new Cliente(identificacion, nombreCompleto, numeroCuenta, saldoInicial);
            clientes.Insertar(nuevoCliente);
            return true;
        }

        public Cliente BuscarCliente(string identificacion)
        {
            return clientes.BuscarPorIdentificacion(identificacion);
        }

        public Cliente BuscarClientePorCuenta(string numeroCuenta)
        {
            return clientes.BuscarPorCuenta(numeroCuenta);
        }

        public Cliente[] ListarClientes()
        {
            return clientes.ObtenerTodosLosClientes();
        }

        public int ObtenerTotalClientes()
        {
            return clientes.ContarClientes();
        }

        public decimal ObtenerTotalDinero()
        {
            return clientes.CalcularTotalDinero();
        }


    }
}
