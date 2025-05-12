// Namespace: ProyectoFinal.Visitor
using ProyectoFinal.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace ProyectoFinal.Visitor
{
    public interface IVisitor
    {
        void VisitAvion(Avion avion);
        void VisitAvioneta(Avioneta avioneta);
        void VisitHelicoptero(Helicoptero helicoptero);
        void VisitDron(Dron dron);
    }

    public class EstadisticasVueloVisitor : IVisitor
    {
        // Totales Globales
        public int VuelosTotalesGlobales { get; private set; }
        public double CostoTotalGlobal { get; private set; }

        // Estadísticas por Tipo (usando el nombre del tipo base abstracto como clave)
        public Dictionary<string, int> VuelosPorTipo { get; private set; }
        public Dictionary<string, double> CostoPorTipo { get; private set; }

        public EstadisticasVueloVisitor()
        {
            VuelosTotalesGlobales = 0;
            CostoTotalGlobal = 0.0;
            VuelosPorTipo = new Dictionary<string, int>();
            CostoPorTipo = new Dictionary<string, double>();
        }

        private void ProcesarAeronave(Aeronave aeronave)
        {
            // 1. Actualizar totales globales
            VuelosTotalesGlobales += aeronave.Vuelos;
            double costoDeEstaAeronave = aeronave.Vuelos * aeronave.CostoVuelo;
            CostoTotalGlobal += costoDeEstaAeronave;

            // 2. Determinar el tipo para agrupación (e.g., "Avion", "Avioneta")
            string tipoBase = aeronave.GetType().BaseType.Name;

            // 3. Actualizar totales por tipo
            if (!VuelosPorTipo.ContainsKey(tipoBase))
            {
                VuelosPorTipo[tipoBase] = 0;
                CostoPorTipo[tipoBase] = 0.0;
            }
            VuelosPorTipo[tipoBase] += aeronave.Vuelos;
            CostoPorTipo[tipoBase] += costoDeEstaAeronave;

             Console.WriteLine($" -> Visitor procesó: {aeronave.Placa} ({tipoBase}), Vuelos={aeronave.Vuelos}, Costo Total={costoDeEstaAeronave:C}");
        }

        public void VisitAvion(Avion avion)
        {
            ProcesarAeronave(avion);
        }

        public void VisitAvioneta(Avioneta avioneta)
        {
            ProcesarAeronave(avioneta);
        }

        public void VisitDron(Dron dron)
        {
            ProcesarAeronave(dron);
        }

        public void VisitHelicoptero(Helicoptero helicoptero)
        {
            ProcesarAeronave(helicoptero);
        }

        public void MostrarReporteEstadisticas()
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("      REPORTE DE ESTADÍSTICAS DE VUELO (Visitor)");
            Console.WriteLine("==================================================");
            Console.WriteLine($" Vuelos Totales Globales: {VuelosTotalesGlobales}");
            Console.WriteLine($" Costo Total Global de Vuelos: {CostoTotalGlobal:C}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(" Desglose por Tipo de Aeronave:");
            Console.WriteLine("--------------------------------------------------");

            if (VuelosPorTipo.Any())
            {
                foreach (string tipo in VuelosPorTipo.Keys.OrderBy(k => k))
                {
                    int vuelos = VuelosPorTipo[tipo];
                    double costo = CostoPorTipo[tipo];
                    Console.WriteLine($"  -> Tipo: {tipo}");
                    Console.WriteLine($"     - Vuelos Realizados: {vuelos}");
                    Console.WriteLine($"     - Costo Total Acumulado: {costo:C}");
                    Console.WriteLine(); // Línea en blanco para separar tipos
                }
            }
            else
            {
                Console.WriteLine("  No se encontraron datos de vuelos para reportar.");
            }
            Console.WriteLine("==================================================");
            Console.WriteLine("               FIN DEL REPORTE");
            Console.WriteLine("==================================================");
        }
    }
}
