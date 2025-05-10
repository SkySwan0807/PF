using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Composite
{
    public class RutaCompuesta : Itramo
    {

        private List<Itramo> _tramos = new List<Itramo>();

        public void AgregarRuta(Itramo tramo)
        {
            _tramos.Add(tramo);
        }

        public double CalcularPrecio()
        {
            double precioTotal = 0;
            foreach (var tramo in _tramos)
            {
                precioTotal += tramo.CalcularPrecio();
            }
            return precioTotal;
        }

        public string ObtenerDescripcion()
        {
            string descripcion = "Ruta compuesta con los siguientes tramos:\n";
            foreach (var ruta in _tramos)
            {
                descripcion += " - " + ruta.ObtenerDescripcion() + "\n";
            }
            descripcion += $"Precio total: {CalcularPrecio()}$";
            return descripcion;
        }


    }
}

