using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Composite
{
    public class TramoSimple : Itramo
    {
        private string _destino;
        private double _precio;

        public TramoSimple(string destino, double precio)
        {
            _destino = destino;
            _precio = precio;
        }

        public double CalcularPrecio()
        {
            return _precio;
        }

        public string ObtenerDescripcion()
        {
            return $"Destino: {_destino}, Precio: {_precio}$";
        }


    }
}

