using Entidades;
using System;

namespace Estructuras
{
    public class ColaAtencion
    {
        private NodoCola? frente;
        private NodoCola? final;

        public ColaAtencion()
        {
            frente = null;
            final = null;
        }

        public bool EstaVacia()
        {
            return frente == null;
        }

        public void Encolar(Cliente cliente)
        {
            NodoCola nuevoNodo = new NodoCola(cliente);
            
            if (frente == null)
            {
                frente = nuevoNodo;
                final = nuevoNodo;
            }
            else
            {
                final!.Siguiente = nuevoNodo;
                final = nuevoNodo;
            }
        }

        public Cliente? Desencolar()
        {
            if (frente == null)
            {
                return null;
            }
            
            Cliente cliente = frente.Cliente;
            frente = frente.Siguiente;
            
            if (frente == null)
            {
                final = null;
            }
            
            return cliente;
        }

        public Cliente? VerSiguiente()
        {
            return frente?.Cliente;
        }

        public int ContarClientesEnCola()
        {
            int contador = 0;
            NodoCola? actual = frente;
            
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            
            return contador;
        }

        public Cliente[] ObtenerClientesEnCola()
        {
            int cantidad = ContarClientesEnCola();
            Cliente[] clientes = new Cliente[cantidad];
            
            NodoCola? actual = frente;
            int indice = 0;
            
            while (actual != null)
            {
                clientes[indice] = actual.Cliente;
                actual = actual.Siguiente;
                indice++;
            }
            
            return clientes;
        }

        public bool ContieneClienteConIdentificacion(string identificacion)
        {
            NodoCola? actual = frente;
            while (actual != null)
            {
                if (actual.Cliente.Identificacion == identificacion)
                    return true;
                actual = actual.Siguiente;
            }

            return false;
        }
    }
}
