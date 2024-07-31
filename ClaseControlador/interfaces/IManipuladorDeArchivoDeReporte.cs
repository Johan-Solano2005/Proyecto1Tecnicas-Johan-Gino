using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.interfaces
{
    public interface IManipuladorDeArchivosDeReportes
    {
        /// <summary>
        /// cargar los archivos de reportes
        /// </summary>
        /// <param name="rutaDeArchivo"></param>
        /// <returns></returns>
        string CargarArchivoDeReporte(string rutaDeArchivo);

        /// <summary>
        /// carga los clientes al reportes
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>

        List<IReporte> CargarReporte(string ruta, Type reporte);

        /// <summary>
        /// guarda el archivo de reportes
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>


        bool GuardarArchivoDeReporte(string ruta);

    }
}
