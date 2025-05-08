using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.AbstractFactory
{
	public interface AbstractFactory
	{
		Avion crearAvion();
		Avioneta crearAvioneta();
		Helicoptero crearHelicoptero();
		List<Dron> crearDrons();
	}

	public class SimulacionCivil : AbstractFactory
	{
		public Avion crearAvion()
		{
			
		}

		public Avioneta crearAvioneta()
		{
			
		}

		public List<Dron> crearDrons()
		{
			
		}

		public Helicoptero crearHelicoptero()
		{
			
		}
	}

	public class SimulacionMilitar : AbstractFactory
	{
		public Avion crearAvion()
		{

		}

		public Avioneta crearAvioneta()
		{

		}

		public List<Dron> crearDrons()
		{

		}

		public Helicoptero crearHelicoptero()
		{

		}
	}
}
