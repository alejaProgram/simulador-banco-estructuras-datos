using Entidades;
using Estructuras;

namespace Logica
{
    public class Banco
    {
        private ListaEnlazadaClientes clientes;
        // TODO: Salo debe agregar estas estructuras
        // private ColaAtencion colaAtencion;
        // private PilaTransacciones historialTransacciones;

        public Banco()
        {
            clientes = new ListaEnlazadaClientes();
            // TODO: Salo debe inicializar estas estructuras
            // colaAtencion = new ColaAtencion();
            // historialTransacciones = new PilaTransacciones();
        }

        // TODO: Aleja debe implementar estos métodos (parte 1)
        public bool RegistrarCliente(string identificacion, string nombreCompleto, string numeroCuenta, decimal saldoInicial = 0)
        {
            // Implementación pendiente - Commit 14
            return false;
        }

        public Cliente BuscarCliente(string identificacion)
        {
            // Implementación pendiente - Commit 15
            return null;
        }

        public Cliente[] ListarClientes()
        {
            // Implementación pendiente - Commit 15
            return null;
        }

        public int ObtenerTotalClientes()
        {
            // Implementación pendiente - Commit 16
            return 0;
        }

        public decimal ObtenerTotalDinero()
        {
            // Implementación pendiente - Commit 16
            return 0;
        }

        // TODO: Salo debe implementar estos métodos (parte 2)
        public bool AgregarACola(string identificacion)
        {
            // Implementación pendiente - Salo
            return false;
        }

        public Cliente AtenderSiguiente()
        {
            // Implementación pendiente - Salo
            return null;
        }

        public bool RealizarDeposito(string numeroCuenta, decimal monto)
        {
            // Implementación pendiente - Salo
            return false;
        }

        public bool RealizarRetiro(string numeroCuenta, decimal monto)
        {
            // Implementación pendiente - Salo
            return false;
        }

        public decimal ConsultarSaldo(string numeroCuenta)
        {
            // Implementación pendiente - Salo
            return 0;
        }

        public bool DeshacerUltimaTransaccion()
        {
            // Implementación pendiente - Salo
            return false;
        }
    }
}
