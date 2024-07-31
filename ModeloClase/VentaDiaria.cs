using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloClase
{
    
        public class VentaDiaria : IReporte
        {
            /// <summary>
            /// inicia un nuevo reportes
            /// </summary>
            public VentaDiaria() { }

            /// <summary>
            /// atributos del reporte
            /// </summary>
            /// <param name="nombre"></param>
            /// <param name="cedula"></param>
            public VentaDiaria(string nombre, DateTime fecha, float monto)
            {
                this.Nombre = nombre;
                this.Fecha = fecha;
                this.Monto = monto;



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
            public float Monto { get; set; }



        }
    }

