using Entidades;

namespace Estructuras
{
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
