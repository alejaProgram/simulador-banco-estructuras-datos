using System;
using Logica;
using Validacion;

namespace Interfaz
{
    public partial class Menu
    {
        private Banco banco;

        public Menu()
        {
            banco = new Banco();
        }

        public void MostrarMenuPrincipal()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine($"=== {Banco.NombreBanco} ===");
                    Console.WriteLine("1. Registrar cliente");
                    Console.WriteLine("2. Listar clientes");
                    Console.WriteLine("3. Buscar cliente");
                    Console.WriteLine("4. Agregar cliente a la cola de atención");
                    Console.WriteLine("5. Atender siguiente cliente");
                    Console.WriteLine("6. Realizar depósito");
                    Console.WriteLine("7. Realizar retiro");
                    Console.WriteLine("8. Consultar saldo");
                    Console.WriteLine("9. Deshacer última transacción");
                    Console.WriteLine("10. Mostrar cola de atención");
                    Console.WriteLine("11. Mostrar total de clientes");
                    Console.WriteLine("12. Mostrar total de dinero del banco");
                    Console.WriteLine("13. Salir");
                    Console.Write("Seleccione una opción: ");

                    string? lineaOpcion = Console.ReadLine();
                    if (!ValidacionesSistema.EsOpcionMenuValida(lineaOpcion, out int numeroOpcion))
                    {
                        Console.WriteLine(ValidacionesSistema.MsgOpcionInvalida);
                        Console.WriteLine("Presione Enter para continuar...");
                        Console.ReadLine();
                        continue;
                    }

                    switch (numeroOpcion)
                    {
                        case 1:
                            OpcionRegistrarCliente();
                            break;
                        case 2:
                            OpcionListarClientes();
                            break;
                        case 3:
                            OpcionBuscarCliente();
                            break;
                        case 4:
                            OpcionAgregarACola();
                            break;
                        case 5:
                            OpcionAtenderSiguiente();
                            break;
                        case 6:
                            OpcionRealizarDeposito();
                            break;
                        case 7:
                            OpcionRealizarRetiro();
                            break;
                        case 8:
                            OpcionConsultarSaldo();
                            break;
                        case 9:
                            OpcionDeshacerTransaccion();
                            break;
                        case 10:
                            OpcionMostrarCola();
                            break;
                        case 11:
                            OpcionMostrarTotalClientes();
                            break;
                        case 12:
                            OpcionMostrarTotalDinero();
                            break;
                        case 13:
                            Console.WriteLine($"¡Gracias por usar {Banco.NombreBanco}!");
                            return;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(ValidacionesSistema.MsgErrorInesperado);
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ReadLine();
                }
            }
        }
    }
}
