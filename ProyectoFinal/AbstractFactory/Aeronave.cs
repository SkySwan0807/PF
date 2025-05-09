using ProyectoFinal.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.AbstractFactory
{
	public abstract class Aeronave
	{
		public string placa {  get; set; }
		public string modelo { get; set; }
		public string fabricante { get; set; }
		public double costoVuelo { get; set; }

		public abstract void Accept(IVisitor visitor);
		public abstract void Volar();

	}

	public abstract class Avion : Aeronave
	{
		public Avion() { }

		public override void Accept(IVisitor visitor)
		{
			visitor.VisitAvion(this);
		}
	}

	public abstract class Avioneta : Aeronave
	{
		public Avioneta() { }

		public override void Accept(IVisitor visitor)
		{
			visitor.VisitAvioneta(this);
		}
	}

	public abstract class Helicoptero : Aeronave
	{
		public Helicoptero() { }

		public override void Accept(IVisitor visitor)
		{
			visitor.VisitHelicoptero(this);
		}
	}

	public abstract class Dron : Aeronave
	{
		public Dron() { }

		public override void Accept(IVisitor visitor)
		{
			visitor.VisitDron(this);
		}
	}
}
