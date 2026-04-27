using Entidades;

namespace Estructuras
{
    // TODO: Salo debe implementar esta clase
    public class NodoCola
    {
        public Cliente Cliente { get; set; }
        public NodoCola Siguiente { get; set; }

        public NodoCola(Cliente cliente)
        {
            Cliente = cliente;
            Siguiente = null;
        }
    }
}
