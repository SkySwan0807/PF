using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.AbstractFactory
{
	public class AvionMilitar : Avion
	{
		public AvionMilitar(string placa, string modelo, string fabricante, double costoVuelo)
		: base(placa, modelo, fabricante, costoVuelo) { }

	}

	public class AvionetaMilitar : Avioneta
	{
		public AvionetaMilitar(string placa, string modelo, string fabricante, double costoVuelo)
		: base(placa, modelo, fabricante, costoVuelo) { }

	}

	public class HelicopteroMilitar : Helicoptero
	{
		public HelicopteroMilitar(string placa, string modelo, string fabricante, double costoVuelo)
		: base(placa, modelo, fabricante, costoVuelo) { }

	}

	public class DronMilitar : Dron
	{
		public DronMilitar(string placa, string modelo, string fabricante, double costoVuelo)
		: base(placa, modelo, fabricante, costoVuelo) { }

	}
}
