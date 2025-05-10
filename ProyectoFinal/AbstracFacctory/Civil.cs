using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.AbstractFactory
{
	public class AvionCivil : Avion
	{
		public AvionCivil(string placa, string modelo, string fabricante, double costoVuelo)
		: base(placa, modelo, fabricante, costoVuelo) { }

	}

	public class AvionetaCivil : Avioneta
	{
		public AvionetaCivil(string placa, string modelo, string fabricante, double costoVuelo)
		: base(placa, modelo, fabricante, costoVuelo) { }

	}
 
	public class HelicopteroCivil : Helicoptero
	{
		public HelicopteroCivil(string placa, string modelo, string fabricante, double costoVuelo)
		: base(placa, modelo, fabricante, costoVuelo) { }

	}

	public class DronCivil : Dron
	{
		public DronCivil(string placa, string modelo, string fabricante, double costoVuelo)
		: base(placa, modelo, fabricante, costoVuelo) { }


	}
}
