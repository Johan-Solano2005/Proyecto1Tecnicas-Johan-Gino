using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.producto
{
    public class ControladorDeDatosProducto
    {
        private ControladorDeDatosProducto instancia { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControladorDeDatosProducto"/> class.
        /// </summary>
        private ControladorDeDatosProducto()
        {
            Productos = new List<IProducto>();
        }

        /// <summary>
        /// Gets or sets the personas.
        /// </summary>
        /// <value>
        /// The personas.
        /// </value>
        public List<IProducto> Productos { get; set; }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public ControladorDeDatosProducto Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladorDeDatosProducto();
                }

                return instancia;
            }
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static ControladorDeDatosProducto GetInstance()
        {
            return new ControladorDeDatosProducto();
        }
    }
}
