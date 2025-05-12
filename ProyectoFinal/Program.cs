using ProyectoFinal.PatProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("Intentando acceder al sistema...");

            ISubject proxy = new Proxy();
            Console.Write("Ingrese usuario: ");
            string usuario = Console.ReadLine();

            Console.Write("Ingrese contraseña: ");
            string password = Console.ReadLine();

            proxy.Validacion(usuario, password); 
            
        }
    }
}
