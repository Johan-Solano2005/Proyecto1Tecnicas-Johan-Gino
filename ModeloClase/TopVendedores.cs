using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloClase
{
    public class TopVendedores : ITopVendedores
    {
        /// <summary>
        /// inicia un nuevo cliente
        /// </summary>
        public TopVendedores() { }

        /// <summary>
        /// atributos del cliente
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="cedula"></param>
        public TopVendedores(string nombre, int cedula, int cantidadDeVentas)
        {
            this.Nombre = nombre;
            this.Cedula = cedula;
            this.CantidadDeVentas = cantidadDeVentas;



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

        public int CantidadDeVentas { get; set; }
    }
}
