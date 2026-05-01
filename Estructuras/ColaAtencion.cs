using Entidades;
using System;

namespace Estructuras
{
    public class ColaAtencion
    {
        private NodoCola frente;
        private NodoCola final;

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
            NodoCola nuevo = new NodoCola(cliente);

            if (EstaVacia())
            {
                frente = nuevo;
                final = nuevo;
            }
            else
            {
                final.Siguiente = nuevo;
                final = nuevo;
            }
        }

        public Cliente Desencolar()
        {
            if (EstaVacia())
            return null;

            Cliente cliente = frente.Cliente;
            frente = frente.Siguiente;

            if (frente == null)
                final = null;

                return cliente;
        }

        public Cliente VerSiguiente()
        {
            if (EstaVacia())
                return null;

            return frente.Cliente;
        }

        public int ContarClienteEncola()
        {
           int contador = 0;
           NodoCola actual = frente;

           while (actual != null)
           {
                contador++;
                actual = actual.Siguiente;
            } 
            return contador;
        }
    }
}