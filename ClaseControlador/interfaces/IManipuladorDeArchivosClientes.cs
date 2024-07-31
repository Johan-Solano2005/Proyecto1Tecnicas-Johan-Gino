using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.interfaces
{
    /// <summary>
    /// interfaz de manipulador de archivos para clientes
    /// </summary>
    public interface IManipuladorDeArchivosClientes
    {
        /// <summary>
        /// cargar los archivos de clientes
        /// </summary>
        /// <param name="rutaDeArchivo"></param>
        /// <returns></returns>
        string CargarArchivoDeClientes(string rutaDeArchivo);

        /// <summary>
        /// carga los clientes al archivo
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>

        List<IClientes> CargarClientes(string ruta);

        /// <summary>
        /// guarda el archivo de clientes
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>


        bool GuardarArchivoDeClientes(string ruta);


    }
}
