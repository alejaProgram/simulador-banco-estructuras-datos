using Entidades;

namespace Estructuras
{
    public class PilaTransacciones
    {
        private NodoPila? cima;

        public PilaTransacciones()
        {
            cima = null;
        }

        public bool EstaVacia()
        {
            return cima == null;
        }

        public void Apilar(Transaccion transaccion)
        {
            NodoPila nuevoNodo = new NodoPila(transaccion);
            nuevoNodo.Siguiente = cima;
            cima = nuevoNodo;
        }

        public Transaccion? Desapilar()
        {
            if (cima == null)
            {
                return null;
            }
            
            Transaccion transaccion = cima.Transaccion;
            cima = cima.Siguiente;
            
            return transaccion;
        }

        public Transaccion? VerUltimaTransaccion()
        {
            return cima?.Transaccion;
        }
    }
}
