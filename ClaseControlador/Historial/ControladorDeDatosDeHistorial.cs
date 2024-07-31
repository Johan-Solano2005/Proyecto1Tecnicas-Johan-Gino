using ClaseControlador.clientes;
using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.Historial
{
    internal class ControladorDeDatosDeHistorial
    {
        private ControladorDeDatosDeHistorial instancia { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControladorDeDatosProducto"/> class.
        /// </summary>



        private ControladorDeDatosDeHistorial()
        {
            Historial = new List<IHistorial>();
        }

        /// <summary>
        /// Gets or sets the personas.
        /// </summary>
        /// <value>
        /// The personas.
        /// </value>
        public List<IHistorial> Historial { get; set; }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public ControladorDeDatosDeHistorial Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladorDeDatosDeHistorial();
                }

                return instancia;
            }
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static ControladorDeDatosDeHistorial GetInstance()
        {
            return new ControladorDeDatosDeHistorial();
        }
    }
}
