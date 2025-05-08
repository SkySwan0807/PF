using ProyectoFinal.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Visitor
{
	public interface IVisitor
	{
		void VisitAvion(Avion avion);
		void VisitAvioneta(Avioneta avioneta);
		void VisitHelicoptero(Helicoptero helicoptero);
		void VisitDron(Dron dron);
	}

	public class DataVisitor : IVisitor
	{
		public void VisitAvion(Avion avion)
		{
			
		}

		public void VisitAvioneta(Avioneta avioneta)
		{
			
		}

		public void VisitDron(Dron dron)
		{
			
		}

		public void VisitHelicoptero(Helicoptero helicoptero)
		{
			
		}
	}

}
