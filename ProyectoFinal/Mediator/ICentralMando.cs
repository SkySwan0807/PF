using ProyectoFinal.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Mediator
{
	public interface ICentralMando
	{
    	void RegistrarDron(Dron dron);
   		void EnviarMensaje(Dron origen, string mensaje);
	}

	public class CentralMando : ICentralMando
	{
		private List<Dron> drones = new List<Dron>();

		public void RegistrarDron(Dron dron)
		{
			if (!drones.Contains(dron))
			{
				drones.Add(dron);
			}
		}

		public void EnviarMensaje(Dron origen, string mensaje)
		{
			foreach (var dron in drones)
			{
				if (dron != origen)
				{
					dron.RecibirMensaje(mensaje);
				}
			}
		}
	}
}