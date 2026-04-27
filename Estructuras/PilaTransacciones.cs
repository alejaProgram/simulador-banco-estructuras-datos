using Entidades;

namespace Estructuras
{
    // TODO: Salo debe implementar esta clase
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
            // Implementación pendiente - Salo
        }

        public Transaccion Desapilar()
        {
            // Implementación pendiente - Salo
            return null;
        }

        public Transaccion VerUltimaTransaccion()
        {
            // Implementación pendiente - Salo
            return null;
        }
    }
}
