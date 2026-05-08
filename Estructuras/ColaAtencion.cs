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
            NodoCola nuevo = new NodoCola(cliente);

            if (EstaVacia())
            {
                frente = nuevo;
                final = nuevo;
            }
            else
            {
                final.Siguiente = nuevo;
                final = nuevo;
            }
        }

        public Cliente Desencolar()
        {
            if (EstaVacia())
            {
                return null;
            }
            
            Cliente cliente = frente.Cliente;
            frente = frente.Siguiente;

            if (frente == null)
                final = null;

                return cliente;
        }

        public Cliente VerSiguiente()
        {
            if (EstaVacia())
                return null;

            return frente.Cliente;
        }

        public int ContarClienteEncola()
        {
           int contador = 0;
           NodoCola actual = frente;

           while (actual != null)
           {
                contador++;
                actual = actual.Siguiente;
            } 
            return contador;
        }

        public Cliente[] ObtenerClienteEncola()
        {
            int cantidad = ContarClienteEncola();

            if (cantidad == 0)
                return new Cliente[0];

            Cliente[] clientes = new Cliente[cantidad];

            NodoCola actual = frente;
            int i = 0;

            while (actual != null)
            {
                clientes[i] = actual.Cliente;
                actual = actual.Siguiente;
                i++;
            }

            return clientes;
        }

        public void MostrarCola()
        {
            if (EstaVacia())
            {
                Console.WriteLine("No hay clientes en la cola");
                return;
            }

            NodoCola actual = frente;

            Console.WriteLine("Clientes en la cola: ");

            while (actual != null)
            {
                Console.WriteLine("- " + actual.Cliente.Nombre + " | Cuenta: " + actual.Cliente.NumeroCuenta);

                actual = actual.Siguiente;
            }
        }
    }
}