using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloClase
{
    public class TopClientes : ITopCliente
    {
        /// <summary>
        /// inicia un nuevo cliente
        /// </summary>
        public TopClientes() { }

        /// <summary>
        /// atributos del cliente
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="cedula"></param>
        public TopClientes(string nombre,  int cantidadDeCompras)
        {
            this.Nombre = nombre;

            this.CantidadDeCompras = cantidadDeCompras;



        }
        /// <summary>
        /// get y set para nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// get y set para cedula
        /// </summary>
        public int Cedula { get; set; }


        /// <summary>
        /// get y set para la cantidad de compras
        /// </summary>

        public int CantidadDeCompras { get; set; }
    }
}
