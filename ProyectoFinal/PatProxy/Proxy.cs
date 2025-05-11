using ProyectoFinal.PatProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.PatProxy
{
    public class Proxy : ISubject
    {
        private Sistema _sistema = new Sistema();
        public void Validacion(string usuario, string password)
        {
            if (usuario == "admin" && password == "1234")
            {
                Console.WriteLine("Usuario autorizado - Accediendo al sistema...");
                _sistema.Validacion(usuario, password);
            }
            else
            {
                Console.WriteLine("Usuario o contraseña incorrectos.");
            }
        }
    }
}
