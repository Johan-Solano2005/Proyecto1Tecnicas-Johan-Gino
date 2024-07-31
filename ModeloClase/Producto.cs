using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloClase
{
    /// <summary>
    /// se empieza el modelo de producto
    /// </summary>
    public class Producto : IProducto
    {
        /// <summary>
        /// un metodo vacio para iniciar un nuevo producto
        /// </summary>

        public Producto() { }

        /// <summary>
        /// constructor de producto
        /// </summary>
        /// <param name="nombreDeProducto"></param>
        /// <param name="precio"></param>
        /// <param name="cantidad"></param>
        public Producto(string nombreDeProducto, float precio, int cantidad)
        {
            this.NombreDeProducto = nombreDeProducto;
            this.Precio = precio;
            this.Cantidad = cantidad;

        }

        /// <summary>
        /// get y set de cada nombre del producto
        /// </summary>

        public string NombreDeProducto { get; set; }
        /// <summary>
        /// get y set de el precio del producto
        /// </summary>
        public float Precio { get; set;}
        /// <summary>
        /// get y set de la cantidad del producto
        /// </summary>

        public int Cantidad { get; set; }
    }
}
