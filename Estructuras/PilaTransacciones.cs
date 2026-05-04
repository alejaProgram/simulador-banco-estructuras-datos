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
            NodoPila nuevo = new NodoPila(transaccion);
            
            nuevo.Siguiente = cima;
            cima = nuevo;
        }
    }
}

       