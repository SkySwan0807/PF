﻿using ProyectoFinal.Composite;
using ProyectoFinal.Mediator;
using ProyectoFinal.Observer;
using ProyectoFinal.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.AbstractFactory
{
	public abstract class Aeronave : ISuscriptorTorre
	{
		public string Placa;
		public string Modelo { get; set; }
		public string Fabricante { get; set; }
		public double CostoVuelo { get; set; }
		public int Vuelos { get; set; }
		public Itramo Ruta { get; set; }

		protected Aeronave(string placa, string modelo, string fabricante, double costoVuelo)
		{
			Placa = placa;
			Modelo = modelo;
			Fabricante = fabricante;
			CostoVuelo = costoVuelo;
			Vuelos = 0;
		}

		public abstract void Accept(IVisitor visitor);

		public void AsignarRuta(Itramo ruta)
		{
			Ruta = ruta;
			Console.WriteLine("Asignacion de ruta Completada");
		}

		public void Volar()
		{
			if(Ruta == null)
			{
				Console.WriteLine("Este Vehiculo Aereo no tiene una ruta asignada");

			}
			else
			{
				Vuelos++;
				Console.WriteLine($"El Vehiculo Aereo con placa {Placa} recorre la siguiente ruta:");
				Console.WriteLine(Ruta.ObtenerDescripcion());
				Console.WriteLine($"{Modelo} ({Placa}) ha completado un vuelo. Vuelos totales: {Vuelos}");
			}
			
		}

		public string GetPlaca()
		{
			return Placa;
		}

		public void SetPlaca(string placa)
		{
			Placa = placa;
		}

		public virtual void RecibirNotificacionAlerta(string codigoAlerta, string detallesAlerta)
		{
			// Implementación base: Simplemente registra la recepción de la alerta.
			Console.WriteLine($"--- ALERTA RECIBIDA por {Modelo} ({Placa}) ---");
			Console.WriteLine($"Código: {codigoAlerta}");
			Console.WriteLine($"Detalles: {detallesAlerta}");
			Console.WriteLine($"Acción por defecto: Registrar y continuar operación normal.");
			Console.WriteLine($"---------------------------------------------");
		}
	}

	public abstract class Avion : Aeronave
	{
		protected Avion(string placa, string modelo, string fabricante, double costoVuelo)
		: base(placa, modelo, fabricante, costoVuelo) { }

		public override void Accept(IVisitor visitor)
		{
			visitor.VisitAvion(this);
		}
	}

	public abstract class Avioneta : Aeronave
	{
		protected Avioneta(string placa, string modelo, string fabricante, double costoVuelo)
		: base(placa, modelo, fabricante, costoVuelo) { }

		public override void Accept(IVisitor visitor)
		{
			visitor.VisitAvioneta(this);
		}
	}

	public abstract class Helicoptero : Aeronave
	{
		protected Helicoptero(string placa, string modelo, string fabricante, double costoVuelo)
		: base(placa, modelo, fabricante, costoVuelo) { }

		public override void Accept(IVisitor visitor)
		{
			visitor.VisitHelicoptero(this);
		}
	}

	public abstract class Dron : Aeronave
	{
		protected ICentralMando central { get; set; }

		protected Dron(string placa, string modelo, string fabricante, double costoVuelo, ICentralMando centralMando)
			: base(placa, modelo, fabricante, costoVuelo)
		{
			central = centralMando;
			central.RegistrarDron(this);
		}

		public void AsignarRutaDesdeCentral(Itramo ruta)
		{
			central.AsignarRuta(ruta);  // Central handles the assignment
		}

		public void EnviarMensaje(string mensaje)
		{
			Console.WriteLine($"{Modelo} ({Placa}) enviando mensaje: {mensaje}");
			central.EnviarMensaje(this, mensaje);
		}

		public void RecibirMensaje(string mensaje)
		{
			Console.WriteLine($"{Modelo} ({Placa}) recibió mensaje: {mensaje}");
		}

		public new void Volar()
		{
			Vuelos++;
			Console.WriteLine($"{Modelo} ({Placa}) está volando. Total vuelos: {Vuelos}");
		}

		public override void Accept(IVisitor visitor)
		{
			visitor.VisitDron(this);
		}
	}
}
