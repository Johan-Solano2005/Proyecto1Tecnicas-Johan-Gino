using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.Top_vendedores
{
    public class ControladorDeDatosTopVendedores
    {
        private ControladorDeDatosTopVendedores instancia { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControladorDeDatosProducto"/> class.
        /// </summary>
        private ControladorDeDatosTopVendedores()
        {
            TopVendedores = new List<ITopVendedores>();
        }

        /// <summary>
        /// Gets or sets the personas.
        /// </summary>
        /// <value>
        /// The personas.
        /// </value>
        public List<ITopVendedores> TopVendedores { get; set; }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public ControladorDeDatosTopVendedores Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladorDeDatosTopVendedores();
                }

                return instancia;
            }
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static ControladorDeDatosTopVendedores GetInstance()
        {
            return new ControladorDeDatosTopVendedores();
        }
    }

}
