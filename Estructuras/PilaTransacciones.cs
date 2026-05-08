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

         public Transaccion Desapilar()
        {
            if (EstaVacia())
                return null;

            Transaccion t = cima.Transaccion;
            cima = cima.Siguiente;

            return t;
        }

         public Transaccion VerUltima()
        {
            if (EstaVacia())
                return null;

            return cima.Transaccion;
        }

        public void MostrarHistorial()
        {
            if(EstaVacia())
            {
                Console.WriteLine ("No hay transacciones registrada");
                return;
            }

            NodoPila actual = cima;

            Console.WriteLine("Historial de transacciones: ");

            while (actual!= null)
            {
                 Console.WriteLine(actual.Transaccion);
                 actual = actual.Siguiente;
            }
        }
    }
}

       