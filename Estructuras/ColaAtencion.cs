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
        }

        public Cliente Desencolar()
        {
            return null;
        }

        public Cliente VerSiguiente()
        {
            return null;
        }

        public int ContarClientesEnCola()
        {
            return 0;
        }

        public Cliente[] ObtenerClientesEnCola()
        {
            return null;
        }
    }
}
