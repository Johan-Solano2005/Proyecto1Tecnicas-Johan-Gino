using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloClase
{


    /// <summary>
    /// inicia un nuevo cliente
    /// </summary>
    public class historial : IHistorial
    {
        /// <summary>
        /// inicia un nuevo cliente
        /// </summary>
        public historial() { }

        /// <summary>
        /// atributos del cliente
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="cedula"></param>
        public historial(string nombre, DateTime fecha, int cantidad)
        {
            this.Nombre = nombre;
            this.Fecha = fecha;
            this.Cantidad = cantidad;



        }
        /// <summary>
        /// get y set para nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// get y set para fecha
        /// </summary>
        public DateTime Fecha { get; set; }
        /// <summary>
        /// get y set para cantidad
        /// </summary>
        public int Cantidad { get; set; }



    }
}

