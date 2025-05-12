using ProyectoFinal.Composite;
using ProyectoFinal.AbstractFactory;
using ProyectoFinal.Observer;
using ProyectoFinal.Visitor;
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
		private List<Aeronave> _aeronavesDelSistema = new List<Aeronave>();
		private TorreDeControl _torreDeControlPrincipal;

		private void InicializarComponentesAeronauticos()
		{
			Console.WriteLine("\nInicializando componentes aeronáuticos del sistema...");

			// 1. Crear Fábricas
			AbstractFactory.AbstractFactory fabricaCivil = new SimulacionCivil();
			AbstractFactory.AbstractFactory fabricaMilitar = new SimulacionMilitar();

			// 2. Crear familias de aeronaves y añadirlas a la lista global
			Console.WriteLine("Creando familia de aeronaves civiles...");
			_aeronavesDelSistema.AddRange(fabricaCivil.crearFamilia());
			Console.WriteLine("Creando familia de aeronaves militares...");
			_aeronavesDelSistema.AddRange(fabricaMilitar.crearFamilia());

			Console.WriteLine($"Total aeronaves creadas: {_aeronavesDelSistema.Count}");
			foreach (var aeronave in _aeronavesDelSistema)
			{
				Console.WriteLine($"- {aeronave.Modelo} ({aeronave.GetPlaca()}), Tipo: {aeronave.GetType().BaseType.Name}");
			}


			// 3. Crear la Torre de Control
			_torreDeControlPrincipal = new TorreDeControl();
			Console.WriteLine("Torre de Control Principal creada.");

			// 4. Suscribir TODAS las aeronaves a la torre de control
			if (_aeronavesDelSistema.Any())
			{
				Console.WriteLine("Suscribiendo aeronaves a la Torre de Control Principal...");
				foreach (var aeronave in _aeronavesDelSistema)
				{
					_torreDeControlPrincipal.Suscribir(aeronave);
				}
			}
			else
			{
				Console.WriteLine("No hay aeronaves para suscribir a la torre de control.");
			}
			Console.WriteLine("Componentes aeronáuticos inicializados.\n");
		}

		public void Validacion(string usuario, string password)
		{
			Console.WriteLine("Revisando el control de mando...");
			Console.WriteLine("Revisando el control de clima...");
			Console.WriteLine("Revisando conexión con la torre de control... \nCONEXION ESTABLECIDA");
			InicializarComponentesAeronauticos();
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
				Console.WriteLine("1. Manejo de Rutas");
				Console.WriteLine("2. Operaciones de Aeronaves");
				Console.WriteLine("3. Emitir Alerta desde Torre de Control");
				Console.WriteLine("4. Mostrar Estadísticas de Vuelo (Visitor)");
				Console.WriteLine("5. Salir del Sistema");

				opcion = Convert.ToInt32(Console.ReadLine());
				switch (opcion)
				{
					case 1:
						EjecutarComposite();
						break;

					case 2:
						MenuOperacionesAeronaves();
						break;

					case 3:
						EmitirAlertaTorre();
						break;

					case 4:
						MostrarEstadisticasVisitor();
						break;

					case 5:
						Console.WriteLine("Cerrando sesión y saliendo del sistema...");
						break;

					default:

						break;
				}


			} while (opcion != 5);

		}
		private void MenuOperacionesAeronaves()
		{
			int opcionAeronave;
			do
			{
				Console.WriteLine("\n--- Operaciones de Aeronaves ---");
				Console.WriteLine("Aeronaves disponibles:");
				MostrarAeronavesGuaradas();
				Console.WriteLine("0. Volver al menú principal");
				Console.Write("Seleccione una aeronave para operar (número) o 0 para volver: ");

				if (!int.TryParse(Console.ReadLine(), out opcionAeronave))
				{
					Console.WriteLine("Entrada inválida.");
					continue;
				}

				if (opcionAeronave == 0) break;

				if (opcionAeronave > 0 && opcionAeronave <= _aeronavesDelSistema.Count)
				{
					Aeronave seleccionada = _aeronavesDelSistema[opcionAeronave - 1];
					OperarAeronaveEspecifica(seleccionada);
				}
				else
				{
					Console.WriteLine("Selección de aeronave no válida.");
				}

			} while (true);
		}

		private void OperarAeronaveEspecifica(Aeronave aeronave)
		{
			Console.WriteLine($"\n--- Operando {aeronave.Modelo} ({aeronave.Placa}) ---");
			Console.WriteLine("1. Realizar Vuelo");
			if (aeronave is Dron) // Si es un Dron, podemos usar sus métodos específicos
			{
				Console.WriteLine("2. Enviar Mensaje Táctico (Drones)");
			}
			Console.WriteLine("0. Volver");
			Console.Write("Opción: ");
			int opcion;
			if (!int.TryParse(Console.ReadLine(), out opcion))
			{
				Console.WriteLine("Entrada inválida.");
				return;
			}

			switch (opcion)
			{
				case 1:
					aeronave.Volar();
					break;
				case 2:
					if (aeronave is Dron dronSeleccionado)
					{
						Console.Write("Ingrese mensaje táctico a enviar: ");
						string mensaje = Console.ReadLine();
						dronSeleccionado.EnviarMensaje(mensaje);
					}
					else
					{
						Console.WriteLine("Esta opción es solo para drones.");
					}
					break;
				case 0:
					return;
				default:
					Console.WriteLine("Opción no válida.");
					break;
			}
		}

		private void EmitirAlertaTorre()
		{
			if (_torreDeControlPrincipal == null)
			{
				Console.WriteLine("La Torre de Control Principal no ha sido inicializada.");
				return;
			}
			Console.WriteLine("\n--- Emitir Alerta desde Torre de Control ---");
			Console.WriteLine("Códigos de alerta disponibles (ejemplos): A1, B3, M5, X7");
			Console.Write("Ingrese el código de alerta a emitir: ");
			string codigo = Console.ReadLine()?.Trim().ToUpper();

			if (!string.IsNullOrEmpty(codigo))
			{
				_torreDeControlPrincipal.EmitirAlerta(codigo);
			}
			else
			{
				Console.WriteLine("Código de alerta no puede estar vacío.");
			}
		}

		private void MostrarEstadisticasVisitor()
		{
			if (!_aeronavesDelSistema.Any())
			{
				Console.WriteLine("No hay aeronaves para generar estadísticas.");
				return;
			}

			Console.WriteLine("\n--- Generando Estadísticas de Vuelo (Visitor) ---");

			EstadisticasVueloVisitor visitorEstadisticas = new EstadisticasVueloVisitor();

			foreach (var aeronave in _aeronavesDelSistema)
			{
				aeronave.Accept(visitorEstadisticas);
			}

			visitorEstadisticas.MostrarReporteEstadisticas();
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
				Console.WriteLine("4. Asignar rutas");
				Console.WriteLine("0. Salir ");

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
						AsignarRuta();
						break;
					case 0:
						Console.WriteLine("Saliendo del sistema...");
						break;

					default:
						Console.WriteLine("Opción no válida");
						break;
				}


			} while (opcion != 4);
		}

		private void AsignarRuta()
		{
			int opcionAeronave;
			int opcionRuta = 0;

			do
			{
				do
				{
					Console.WriteLine("\n--- Asignacion de Ruta a Aeronaves ---");
					Console.WriteLine("Aeronaves disponibles:");
					MostrarAeronavesGuaradas();
					Console.WriteLine("0. Volver al menú principal");
					Console.Write("Seleccione una aeronave para asignar (número) o 0 para volver: ");

					if (!int.TryParse(Console.ReadLine(), out opcionAeronave))
					{
						Console.WriteLine("Entrada inválida.");
						continue;
					}

					if (opcionAeronave == 0)
					{
						break;
					}
					else if (opcionAeronave > _aeronavesDelSistema.Count())
					{
						Console.WriteLine("Selección de aeronave no válida.");
						continue;
					}
					break;

				} while (true);

				while (opcionAeronave != 0)
				{
					MostrarRutasGuardadas();
					Console.WriteLine("0. Volver al menú principal");
					Console.Write("Seleccione una ruta para asignar (número) o 0 para volver: ");

					if (!int.TryParse(Console.ReadLine(), out opcionRuta))
					{
						Console.WriteLine("Entrada inválida.");
						continue;
					}

					if (opcionRuta == 0)
						break;
					else if(opcionRuta > _rutasGuardadas.Count())
					{
						Console.WriteLine("Selección de ruta no válida.");
						continue;
					}
					else
					{
						_aeronavesDelSistema[opcionAeronave - 1].AsignarRuta(_rutasGuardadas[opcionRuta - 1]);
						break;
					}

				}

			} while ((opcionRuta != 0) && opcionAeronave != 0);
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
				Console.WriteLine($"{i + 1}. {_rutasGuardadas[i].ObtenerDescripcion()}");
			}
		}

		private	void MostrarAeronavesGuaradas()
		{
			if (!_aeronavesDelSistema.Any())
			{
				Console.WriteLine("No hay aeronaves en el sistema para operar.");
				return;
			}

			for (int i = 0; i < _aeronavesDelSistema.Count; i++)
			{
				var a = _aeronavesDelSistema[i];
				Console.WriteLine($"{i + 1}. {a.Modelo} ({a.Placa}) - Vuelos: {a.Vuelos}");
			}
		}


	}
}
