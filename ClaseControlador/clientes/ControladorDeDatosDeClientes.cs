using ClaseControlador.producto;
using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.clientes
{
    public class ControladorDeDatosDeClientes
    {
        private ControladorDeDatosDeClientes instancia { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControladorDeDatosProducto"/> class.
        /// </summary>



        private ControladorDeDatosDeClientes()
        {
            Clientes = new List<IClientes>();
        }

        /// <summary>
        /// Gets or sets the personas.
        /// </summary>
        /// <value>
        /// The personas.
        /// </value>
        public List<IClientes> Clientes { get; set; }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public ControladorDeDatosDeClientes Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladorDeDatosDeClientes();
                }

                return instancia;
            }
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static ControladorDeDatosDeClientes GetInstance()
        {
            return new ControladorDeDatosDeClientes();
        }

    }
}
