using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.interfaces
{
    public interface IManipuladorDeArchivosDeHistorial
    {
        /// <summary>
        /// cargar los archivos de historial
        /// </summary>
        /// <param name="rutaDeArchivo"></param>
        /// <returns></returns>
        string CargarArchivoDeHistorial(string rutaDeArchivo);

        /// <summary>
        /// carga los clientes al archivo
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>

        List<IHistorial> CargarHistorial(string ruta);

        /// <summary>
        /// guarda el archivo de clientes
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>


        bool GuardarArchivoDeHistorial(string ruta);

    }
}
