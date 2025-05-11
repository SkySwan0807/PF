using ProyectoFinal.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.AbstractFactory
{
	public abstract class Aeronave
	{
		public string Placa {  get; set; }
		public string Modelo { get; set; }
		public string Fabricante { get; set; }
		public double CostoVuelo { get; set; }
		public int Vuelos { get; set; }

		protected Aeronave(string placa, string modelo, string fabricante, double costoVuelo)
		{
			Placa = placa;
			Modelo = modelo;
			Fabricante = fabricante;
			CostoVuelo = costoVuelo;
			Vuelos = 0;
		}

		public abstract void Accept(IVisitor visitor);
		public void Volar()
		{
			Vuelos++;
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
		private ICentralMando central;

		protected Dron(string placa, string modelo, string fabricante, double costoVuelo, ICentralMando centralMando)
			: base(placa, modelo, fabricante, costoVuelo)
		{
			central = centralMando;
			central.RegistrarDron(this);
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
