using ClaseControlador.clientes;
using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.Reporte
{
    public class ControladorDeDatosDeReporte
    {
        private static ControladorDeDatosDeReporte instancia; 
        private static readonly object lockObject = new object(); 

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ControladorDeDatosDeReporte"/>.
        /// </summary>
        private ControladorDeDatosDeReporte()
        {
            Reporte = new List<IReporte>();
        }

        /// <summary>
        /// Obtiene la instancia única de la clase <see cref="ControladorDeDatosDeReporte"/>.
        /// </summary>
        public static ControladorDeDatosDeReporte Instancia
        {
            get
            {
                lock (lockObject)
                {
                    if (instancia == null)
                    {
                        instancia = new ControladorDeDatosDeReporte();
                    }
                    return instancia;
                }
            }
        }

        /// <summary>
        /// Obtiene o establece los reportes.
        /// </summary>
        public List<IReporte> Reporte { get; set; }
    }
}
