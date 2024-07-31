using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloClase.Interfaces
{
    /// <summary>
    /// interfaz de historial
    /// </summary>
    public interface IHistorial
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
        /// get y set de cantidad
        /// </summary>

        int Cantidad { get; set; }  

    }
}
