using Entidades;
using System;

namespace Estructuras
{
    // TODO: Salo debe implementar esta clase
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
            // Implementación pendiente - Salo
        }

        public Cliente Desencolar()
        {
            // Implementación pendiente - Salo
            return null;
        }

        public Cliente VerSiguiente()
        {
            // Implementación pendiente - Salo
            return null;
        }

        public int ContarClientesEnCola()
        {
            // Implementación pendiente - Salo
            return 0;
        }

        public Cliente[] ObtenerClientesEnCola()
        {
            // Implementación pendiente - Salo
            return null;
        }
    }
}
