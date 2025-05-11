// Namespace: ProyectoFinal.Observer
using System;

namespace ProyectoFinal.Observer
{
    public interface ISuscriptorTorre
    {
        /// Identificador único de la aeronave para logs y referencias.
        string GetIdentificadorAeronave();

        /// Método llamado por la Torre de Control cuando se emite una alerta.
        /// "codigoAlerta">El código breve de la alerta.
        /// "detallesAlerta">La descripción completa de la alerta.
        void RecibirNotificacionAlerta(string codigoAlerta, string detallesAlerta);
    }
}