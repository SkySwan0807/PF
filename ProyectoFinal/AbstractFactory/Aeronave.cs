using ProyectoFinal.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.AbstractFactory
{
	public interface Aeronave
	{
		void Accept(IVisitor visitor);

	}

	public abstract class Avion : Aeronave
	{
		public Avion() { }

		public void Accept(IVisitor visitor)
		{
			visitor.VisitAvion(this);
		}
	}

	public abstract class Avioneta : Aeronave
	{
		public Avioneta() { }

		public void Accept(IVisitor visitor)
		{
			visitor.VisitAvioneta(this);
		}
	}

	public abstract class Helicoptero : Aeronave
	{
		public Helicoptero() { }

		public void Accept(IVisitor visitor)
		{
			visitor.VisitHelicoptero(this);
		}
	}

	public abstract class Dron : Aeronave
	{
		public Dron() { }

		public void Accept(IVisitor visitor)
		{
			visitor.VisitDron(this);
		}
	}
}
