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
    public class Clientes : IClientes
    {
        /// <summary>
        /// inicia un nuevo cliente
        /// </summary>
        public Clientes() { }

        /// <summary>
        /// atributos del cliente
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="cedula"></param>
        public Clientes(string nombre, int cedula)
        {
            this.Nombre = nombre;
            this.Cedula = cedula;



        }
        /// <summary>
        /// get y set para nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// get y set para cedula
        /// </summary>
        public int Cedula { get; set; }
    }
}
