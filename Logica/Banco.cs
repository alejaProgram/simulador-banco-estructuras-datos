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

        public bool AgregarACola(string identificacion)
        {
            Cliente cliente = clientes.BuscarPorIdentificacion(identificacion);
            if (cliente != null)
            {
                colaAtencion.Encolar(cliente);
                return true;
            }
            return false;
        }

        public Cliente AtenderSiguiente()
        {
            return colaAtencion.Desencolar();
        }

        public Cliente VerSiguienteEnCola()
        {
            return colaAtencion.VerSiguiente();
        }

        public Cliente[] VerColaActual()
        {
            return colaAtencion.ObtenerClientesEnCola();
        }

        public int ContarClientesEnCola()
        {
            return colaAtencion.ContarClientesEnCola();
        }

        public bool RealizarDeposito(string numeroCuenta, decimal monto)
        {
            Cliente cliente = clientes.BuscarPorCuenta(numeroCuenta);
            if (cliente != null && monto > 0)
            {
                decimal saldoAnterior = cliente.Saldo;
                cliente.Depositar(monto);
                
                Transaccion transaccion = new Transaccion(numeroCuenta, monto, TipoTransaccion.Deposito, saldoAnterior, cliente.Saldo);
                historialTransacciones.Apilar(transaccion);
                
                return true;
            }
            return false;
        }

        public bool RealizarRetiro(string numeroCuenta, decimal monto)
        {
            Cliente cliente = clientes.BuscarPorCuenta(numeroCuenta);
            if (cliente != null && monto > 0 && cliente.Saldo >= monto)
            {
                decimal saldoAnterior = cliente.Saldo;
                cliente.Retirar(monto);
                
                Transaccion transaccion = new Transaccion(numeroCuenta, monto, TipoTransaccion.Retiro, saldoAnterior, cliente.Saldo);
                historialTransacciones.Apilar(transaccion);
                
                return true;
            }
            return false;
        }

        public decimal ConsultarSaldo(string numeroCuenta)
        {
            Cliente cliente = clientes.BuscarPorCuenta(numeroCuenta);
            return cliente?.Saldo ?? 0;
        }

        public bool DeshacerUltimaTransaccion()
        {
            Transaccion ultimaTransaccion = historialTransacciones.Desapilar();
            if (ultimaTransaccion != null)
            {
                Cliente cliente = clientes.BuscarPorCuenta(ultimaTransaccion.NumeroCuenta);
                if (cliente != null)
                {
                    if (ultimaTransaccion.Tipo == TipoTransaccion.Deposito)
                    {
                        cliente.Retirar(ultimaTransaccion.Monto);
                    }
                    else
                    {
                        cliente.Depositar(ultimaTransaccion.Monto);
                    }
                    return true;
                }
            }
            return false;
        }

        public Transaccion VerUltimaTransaccion()
        {
            return historialTransacciones.VerUltimaTransaccion();
        }

        public bool HayTransaccionesPendientes()
        {
            return !historialTransacciones.EstaVacia();
        }
    }
}
