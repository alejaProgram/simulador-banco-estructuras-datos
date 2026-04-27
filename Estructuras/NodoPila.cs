using Entidades;

namespace Estructuras
{
    // TODO: Salo debe implementar esta clase
    public class NodoPila
    {
        public Transaccion Transaccion { get; set; }
        public NodoPila Siguiente { get; set; }

        public NodoPila(Transaccion transaccion)
        {
            Transaccion = transaccion;
            Siguiente = null;
        }
    }
}
