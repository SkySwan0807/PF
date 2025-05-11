using ProyectoFinal.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.PatProxy
{
    public class Sistema : ISubject
    {
        private List<Itramo> _rutasGuardadas = new List<Itramo>();
        public void Validacion(string usuario, string password)
        {
            Console.WriteLine("Revisando el control de mando...");
            Console.WriteLine("Revisando el control de clima...");
            Console.WriteLine("Revisando conexión con la torre de control... \nCONEXION ESTABLECIDA" );
            Itramo rutaLaPaz = new TramoSimple("La Paz", 50);
            Itramo rutaBuenosAires = new TramoSimple("Buenos Aires", 75.4);
            Itramo rutaCiudadMexico = new TramoSimple("Ciudad de Mexico", 95.8);
            _rutasGuardadas.Add(rutaLaPaz);
            _rutasGuardadas.Add(rutaBuenosAires);
            _rutasGuardadas.Add(rutaCiudadMexico);
            int opcion;
            do
            {
                Console.WriteLine("Bienvenido al Sistema de Aeronaves");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Crear Rutas");
                Console.WriteLine("2. ....");
                Console.WriteLine("3. ....");

                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        EjecutarComposite();
                        break;

                    case 2:
                        
                        break;

                    case 3:
                        
                        break;

                    case 4:
                        
                        break;

                    default:
                        
                        break;
                }


            } while (opcion != 4);
         
        }

        public void EjecutarComposite()
        {
            int opcion;
            do
            {
                Console.WriteLine("Selecciona una opcion");
                Console.WriteLine("1. Crear tramo simple");
                Console.WriteLine("2. Crear ruta compuesta");
                Console.WriteLine("3. Mostrar rutas creadas");
                Console.WriteLine("4. Salir ");

                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        CrearRutaSimple();
                        break;

                    case 2:
                        CrearRutaCompuesta();
                        break;

                    case 3:
                        MostrarRutasGuardadas();
                        break;

                    case 4:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }


            } while (opcion != 4);
        }
        private void CrearRutaSimple()
        {
            Console.Write("Ingrese destino: ");
            string destino = Console.ReadLine();
            Console.Write("Ingrese precio: ");
            double precio = Convert.ToDouble(Console.ReadLine());

            Itramo rutaSimple = new TramoSimple(destino, precio);
            _rutasGuardadas.Add(rutaSimple); 

            Console.WriteLine($"Ruta simple creada: {rutaSimple.ObtenerDescripcion()}");
        }

        private void CrearRutaCompuesta()
        {
            RutaCompuesta rutaCompuesta = new RutaCompuesta();
            string agregarOtraRuta;

            do
            {
                Console.WriteLine("¿Desea agregar una nueva ruta (1) o reutilizar una existente (2)?");
                int tipoRuta = Convert.ToInt32(Console.ReadLine());

                if (tipoRuta == 1)
                {
                    Console.Write("Ingrese destino: ");
                    string destinoRuta = Console.ReadLine();
                    Console.Write("Ingrese precio: ");
                    double precioRuta = Convert.ToDouble(Console.ReadLine());

                    rutaCompuesta.AgregarRuta(new TramoSimple(destinoRuta, precioRuta));
                }
                else if (tipoRuta == 2)
                {
                    MostrarRutasGuardadas();

                    Console.Write("Ingrese el número de la ruta a reutilizar: ");
                    int seleccion = Convert.ToInt32(Console.ReadLine());

                    if (seleccion >= 0 && seleccion < _rutasGuardadas.Count)
                    {
                        rutaCompuesta.AgregarRuta(_rutasGuardadas[seleccion]);
                        Console.WriteLine("Ruta agregada exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Número de ruta inválido.");
                    }
                }

                Console.Write("¿Desea agregar otra ruta a la ruta compuesta? (si/no): ");
                agregarOtraRuta = Console.ReadLine().ToLower();
            }
            while (agregarOtraRuta == "si");

            _rutasGuardadas.Add(rutaCompuesta);
            Console.WriteLine($"Ruta compuesta creada:\n{rutaCompuesta.ObtenerDescripcion()}");
        }

        private void MostrarRutasGuardadas()
        {
            Console.WriteLine("Listado de rutas almacenadas:");

            if (_rutasGuardadas.Count == 0)
            {
                Console.WriteLine("No hay rutas registradas.");
                return;
            }

            for (int i = 0; i < _rutasGuardadas.Count; i++)
            {
                Console.WriteLine($"[{i}] {_rutasGuardadas[i].ObtenerDescripcion()}");
            }
        }


    }
}
