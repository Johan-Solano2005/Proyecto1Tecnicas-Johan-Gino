using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloClase.Interfaces
{
    public interface ITopVendedores
    {
        /// <summary>
        /// get y set para nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// get y set para cedula
        /// </summary>
        public int Cedula { get; set; }

        /// <summary>
        /// get y set para cantidad de ventas
        /// </summary>

        public int CantidadDeVentas { get; set; }
    }
}
