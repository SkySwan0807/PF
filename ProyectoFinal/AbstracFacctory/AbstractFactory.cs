using ProyectoFinal.Mediator;
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
		List<Dron> crearDrones();
		List<Aeronave> crearFamilia();
	}

	public class SimulacionCivil : AbstractFactory
	{
		public Avion crearAvion()
		{
			return new AvionCivil("ABC1616", "Boeing 737", "Boeing", 5000);
		}

		public Avioneta crearAvioneta()
		{
			return new AvionetaCivil("BCD1010", "Cessna 172 Skyhawk", "Cessna", 300);
		}

		public List<Dron> crearDrones()
		{
			CentralMando central = new CentralMando();
			List<Dron> drons = new List<Dron>()
			{
				new DronCivil("DEF1515", "DJI Mavic 3", "DJI", 50, central),
				new DronCivil("DEF1616", "DJI Mavic 3", "DJI", 50, central),
				new DronCivil("DEF1717", "DJI Mavic 3", "DJI", 50, central)
			};

			return drons;
		}

		public Helicoptero crearHelicoptero()
		{
			return new HelicopteroCivil("CDE1551", "Airbus H125", "Airbus Helicopters", 1500);
		}

		public List<Aeronave> crearFamilia()
		{
			List<Aeronave> aeronavesCiviles = new List<Aeronave>()
			{
				this.crearAvion(),
				this.crearAvioneta(),
				this.crearHelicoptero(),
			};

			aeronavesCiviles.AddRange(this.crearDrones());

			return aeronavesCiviles;

		}
	}

	public class SimulacionMilitar : AbstractFactory
	{
		public Avion crearAvion()
		{
			return new AvionMilitar("ACB1515", "F-16 Fighting Falcon", "Lockheed Martin", 25000);
		}

		public Avioneta crearAvioneta()
		{
			return new AvionetaMilitar("BDC1111", "Cessna AC-208B Combat Caravan", "Cessna", 3000);
		}

		public List<Dron> crearDrones()
		{
			CentralMando central = new CentralMando();
			List<Dron> drons = new List<Dron>()
			{
				new DronMilitar("DFE1515", "MQ-9 Reaper", "General Atomics", 5000, central),
				new DronMilitar("DFE1616", "MQ-9 Reaper", "General Atomics", 5000, central),
				new DronMilitar("DFE1717", "MQ-9 Reaper", "General Atomics", 5000, central)
			};

			return drons;
		}

		public Helicoptero crearHelicoptero()
		{
			return new HelicopteroMilitar("DEC1771", "AH-64 Apache", "Boeing", 20000);
		}

		public List<Aeronave> crearFamilia()
		{
			List<Aeronave> aeronavesMilitares = new List<Aeronave>()
			{
				this.crearAvion(),
				this.crearAvioneta(),
				this.crearHelicoptero(),
			};

			aeronavesMilitares.AddRange(this.crearDrones());

			return aeronavesMilitares;

		}
	}
}
