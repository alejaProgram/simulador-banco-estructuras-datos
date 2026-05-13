using Entidades;
using Estructuras;

namespace Logica
{
    public class Banco
    {
        private ListaEnlazadaClientes clientes;
        private ColaAtencion colaAtencion;
        private PilaTransacciones historialTransacciones;

        public Banco()
        {
            clientes = new ListaEnlazadaClientes();
            colaAtencion = new ColaAtencion();
            historialTransacciones = new PilaTransacciones();
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

        public Cliente? BuscarCliente(string identificacion)
        {
            return clientes.BuscarPorIdentificacion(identificacion);
        }

        public Cliente? BuscarClientePorCuenta(string numeroCuenta)
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

        public bool AgregarClienteACola(string identificacion)
        {
            Cliente cliente = BuscarCliente(identificacion);
            if (cliente == null)
            {
                return false;
            }
            
            colaAtencion.Encolar(cliente);
            return true;
        }

        public Cliente? AtenderSiguienteCliente()
        {
            return colaAtencion.Desencolar();
        }

        public Cliente? VerSiguienteCliente()
        {
            return colaAtencion.VerSiguiente();
        }

        public int ObtenerCantidadClientesEnCola()
        {
            return colaAtencion.ContarClientesEnCola();
        }

        public Cliente[] ObtenerClientesEnCola()
        {
            return colaAtencion.ObtenerClientesEnCola();
        }

        public bool RealizarDeposito(string numeroCuenta, decimal monto)
        {
            if (monto <= 0)
            {
                return false;
            }

            Cliente cliente = BuscarClientePorCuenta(numeroCuenta);
            if (cliente == null)
            {
                return false;
            }

            decimal saldoAnterior = cliente.Saldo;
            cliente.Depositar(monto);
            decimal saldoNuevo = cliente.Saldo;

            Transaccion transaccion = new Transaccion(numeroCuenta, monto, TipoTransaccion.Deposito, saldoAnterior, saldoNuevo);
            historialTransacciones.Apilar(transaccion);

            return true;
        }

        public bool RealizarRetiro(string numeroCuenta, decimal monto)
        {
            if (monto <= 0)
            {
                return false;
            }

            Cliente cliente = BuscarClientePorCuenta(numeroCuenta);
            if (cliente == null)
            {
                return false;
            }

            decimal saldoAnterior = cliente.Saldo;
            bool exito = cliente.Retirar(monto);
            
            if (!exito)
            {
                return false;
            }

            decimal saldoNuevo = cliente.Saldo;

            Transaccion transaccion = new Transaccion(numeroCuenta, monto, TipoTransaccion.Retiro, saldoAnterior, saldoNuevo);
            historialTransacciones.Apilar(transaccion);

            return true;
        }

        public Transaccion? DeshacerUltimaTransaccion()
        {
            Transaccion? transaccion = historialTransacciones.Desapilar();
            if (transaccion == null)
            {
                return null;
            }

            Cliente cliente = BuscarClientePorCuenta(transaccion.NumeroCuenta);
            if (cliente == null)
            {
                return transaccion;
            }

            if (transaccion.Tipo == TipoTransaccion.Deposito)
            {
                cliente.Saldo = transaccion.SaldoAnterior;
            }
            else if (transaccion.Tipo == TipoTransaccion.Retiro)
            {
                cliente.Saldo = transaccion.SaldoAnterior;
            }

            return transaccion;
        }

        public Transaccion? VerUltimaTransaccion()
        {
            return historialTransacciones.VerUltimaTransaccion();
        }

        public bool HayTransaccionesPendientes()
        {
            return !historialTransacciones.EstaVacia();
        }

        public bool HayClientesEnCola()
        {
            return !colaAtencion.EstaVacia();
        }

    }
}
