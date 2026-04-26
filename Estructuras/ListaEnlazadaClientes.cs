using Entidades;
using System;

namespace Estructuras
{
    public class ListaEnlazadaClientes
    {
        private NodoCliente cabeza;

        public ListaEnlazadaClientes()
        {
            cabeza = null;
        }

        public bool EstaVacia()
        {
            return cabeza == null;
        }

        public void Limpiar()
        {
            cabeza = null;
        }

        public int Contar()
        {
            return ContarClientes();
        }

        public void Insertar(Cliente cliente)
        {
            NodoCliente nuevoNodo = new NodoCliente(cliente);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                NodoCliente actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
        }

        public Cliente BuscarPorIdentificacion(string identificacion)
        {
            NodoCliente actual = cabeza;
            while (actual != null)
            {
                if (actual.Cliente.Identificacion == identificacion)
                {
                    return actual.Cliente;
                }
                actual = actual.Siguiente;
            }
            return null;
        }

        public Cliente BuscarPorCuenta(string numeroCuenta)
        {
            NodoCliente actual = cabeza;
            while (actual != null)
            {
                if (actual.Cliente.NumeroCuenta == numeroCuenta)
                {
                    return actual.Cliente;
                }
                actual = actual.Siguiente;
            }
            return null;
        }

        public bool ExisteCliente(string identificacion, string numeroCuenta)
        {
            return BuscarPorIdentificacion(identificacion) != null || BuscarPorCuenta(numeroCuenta) != null;
        }

        public int ContarClientes()
        {
            int contador = 0;
            NodoCliente actual = cabeza;
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }

        public decimal CalcularTotalDinero()
        {
            decimal total = 0;
            NodoCliente actual = cabeza;
            while (actual != null)
            {
                total += actual.Cliente.Saldo;
                actual = actual.Siguiente;
            }
            return total;
        }

        public Cliente[] ObtenerTodos()
        {
            return ObtenerTodosLosClientes();
        }

        public Cliente Buscar(string criterio)
        {
            return BuscarPorIdentificacion(criterio);
        }

        public bool Existe(string criterio)
        {
            return Buscar(criterio) != null;
        }

        public Cliente[] ObtenerTodosLosClientes()
        {
            int cantidad = ContarClientes();
            Cliente[] clientes = new Cliente[cantidad];
            
            NodoCliente actual = cabeza;
            int indice = 0;
            
            while (actual != null)
            {
                clientes[indice] = actual.Cliente;
                actual = actual.Siguiente;
                indice++;
            }
            
            return clientes;
        }
    }
}
