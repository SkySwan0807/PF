using ProyectoFinal.AbstractFactory;
using ProyectoFinal.Composite;
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
		void AsignarRuta(Itramo ruta);
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

		public void AsignarRuta(Itramo ruta)
		{
			foreach (var dron in drones)
			{
				dron.AsignarRuta(ruta);
			}
		}
	}
}