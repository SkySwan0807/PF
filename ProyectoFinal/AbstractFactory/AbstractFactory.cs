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
			return new AvionCivil();
		}

		public Avioneta crearAvioneta()
		{
			return new AvionetaCivil();
		}

		public List<Dron> crearDrons()
		{
			List<Dron> drons = new List<Dron>()
			{
				new DronCivil(),
				new DronCivil(),
				new DronCivil()
			};

			return drons;
		}

		public Helicoptero crearHelicoptero()
		{
			return new HelicopteroCivil();
		}
	}

	public class SimulacionMilitar : AbstractFactory
	{
		public Avion crearAvion()
		{
			return new AvionMilitar();
		}

		public Avioneta crearAvioneta()
		{
			return new AvionetaMilitar();
		}

		public List<Dron> crearDrons()
		{
			List<Dron> drons = new List<Dron>()
			{
				new DronMilitar(),
				new DronMilitar(),
				new DronMilitar()
			};

			return drons;
		}

		public Helicoptero crearHelicoptero()
		{
			return new HelicopteroMilitar();
		}
	}
}
