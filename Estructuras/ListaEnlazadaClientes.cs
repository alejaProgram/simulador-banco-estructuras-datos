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

            return null;
        }

        public bool ExisteCliente(string identificacion, string numeroCuenta)
        {
  
            return false;
        }

        public int ContarClientes()
        {
  
            return 0;
        }

        public decimal CalcularTotalDinero()
        {

            return 0;
        }

        public Cliente[] ObtenerTodosLosClientes()
        {
  
            return null;
        }
    }
}
