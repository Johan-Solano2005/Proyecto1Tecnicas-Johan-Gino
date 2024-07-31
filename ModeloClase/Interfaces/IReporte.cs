using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloClase.Interfaces
{
    /// <summary>
    /// interfaz de Reportes
    /// </summary>
    public interface IReporte
    {
        /// <summary>
        /// get y set de nombre
        /// </summary>
        string Nombre { get; set; }

        /// <summary>
        /// get y set de fecha
        /// </summary>

        DateTime Fecha { get; set; }

        /// <summary>
        /// get y set de Monto
        /// </summary>

        float Monto { get; set; }

    }
}
