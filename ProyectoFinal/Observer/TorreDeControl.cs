// Namespace: ProyectoFinal.Observer
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal.Observer
{
    public class TorreDeControl
    {
        private List<ISuscriptorTorre> _suscriptores = new List<ISuscriptorTorre>();
        private Dictionary<string, string> _definicionesAlertas = new Dictionary<string, string>
        {
            {"A1", "Emergencia médica a bordo."},
            {"B3", "Cierre temporal de pista."},
            {"M5", "Condiciones meteorológicas adversas aproximándose."},
            {"X7", "Cruce no autorizado de espacio aéreo detectado."}
        };

        public void Suscribir(ISuscriptorTorre suscriptor)
        {
            if (!_suscriptores.Contains(suscriptor))
            {
                _suscriptores.Add(suscriptor);
                Console.WriteLine($"Torre de Control: Aeronave '{suscriptor.GetPlaca()}' se ha suscrito a las alertas.");
            }
        }

        public void Desuscribir(ISuscriptorTorre suscriptor)
        {
            if (_suscriptores.Remove(suscriptor))
            {
                Console.WriteLine($"Torre de Control: Aeronave '{suscriptor.GetPlaca()}' se ha desuscrito de las alertas.");
            }
        }

        public void EmitirAlerta(string codigoAlerta)
        {
            if (_definicionesAlertas.TryGetValue(codigoAlerta, out string detalles))
            {
                Console.WriteLine($"\nTorre de Control emitiendo ALERTA: {codigoAlerta} - {detalles}");
                NotificarSuscriptores(codigoAlerta, detalles);
            }
            else
            {
                Console.WriteLine($"\nTorre de Control: Código de alerta '{codigoAlerta}' desconocido.");
                NotificarSuscriptores(codigoAlerta, "Alerta desconocida, proceda con cautela.");
            }
        }

        private void NotificarSuscriptores(string codigoAlerta, string detallesAlerta)
        {
            // Creamos una copia de la lista para evitar problemas si un suscriptor
            // intenta desuscribirse dentro del método RecibirNotificacionAlerta.
            foreach (var suscriptor in _suscriptores.ToList())
            {
                suscriptor.RecibirNotificacionAlerta(codigoAlerta, detallesAlerta);
            }
        }
    }
}