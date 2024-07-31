using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloClase.Interfaces
{
    public interface IProducto
    {
        /// <summary>
        /// toma el nombre del producto
        /// </summary>
        public string NombreDeProducto { get; set; }

        /// <summary>
        /// toma el precio del producto
        /// </summary>
        public float Precio { get; set; }

        /// <summary>
        /// cantidad del producto
        /// </summary>

        public int Cantidad { get; set; }
    }
}