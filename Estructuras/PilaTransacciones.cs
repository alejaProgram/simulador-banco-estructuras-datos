using Entidades;

namespace Estructuras
{
    public class PilaTransacciones
    {
        private NodoPila cima;

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

        public Transaccion Desapilar()
        {
            if (EstaVacia())
            {
                return null;
            }

            Transaccion transaccion = cima.Transaccion;
            cima = cima.Siguiente;
            
            return transaccion;
        }

        public Transaccion VerUltimaTransaccion()
        {
            if (EstaVacia())
            {
                return null;
            }

            return cima.Transaccion;
        }

        public int ContarTransacciones()
        {
            int contador = 0;
            NodoPila actual = cima;
            
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            
            return contador;
        }

        public void Limpiar()
        {
            cima = null;
        }

        public int Contar()
        {
            return ContarTransacciones();
        }
    }
}
