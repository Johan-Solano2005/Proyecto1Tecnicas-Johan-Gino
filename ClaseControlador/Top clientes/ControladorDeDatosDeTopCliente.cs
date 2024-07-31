using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.Top_clientes
{
    public class ControladorDeDatosTopCliente
    {
        private ControladorDeDatosTopCliente instancia { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControladorDeDatosProducto"/> class.
        /// </summary>
        private ControladorDeDatosTopCliente()
        {
            TopClientes = new List<ITopCliente>();
        }

        /// <summary>
        /// Gets or sets the personas.
        /// </summary>
        /// <value>
        /// The personas.
        /// </value>
        public List<ITopCliente> TopClientes { get; set; }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public ControladorDeDatosTopCliente Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladorDeDatosTopCliente();
                }

                return instancia;
            }
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static ControladorDeDatosTopCliente GetInstance()
        {
            return new ControladorDeDatosTopCliente();
        }
    }
}
