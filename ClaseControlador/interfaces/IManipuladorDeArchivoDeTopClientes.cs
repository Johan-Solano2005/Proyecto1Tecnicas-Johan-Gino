using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.interfaces
{
    public interface IManipuladorDeArchivoDeTopClientes
    {
        /// <summary>
        /// cargar los archivos de los top clientes
        /// </summary>
        /// <param name="rutaDeArchivo"></param>
        /// <returns></returns>
        string CargarArchivoDeTopClientes(string rutaDeArchivo);

        /// <summary>
        /// carga los top clientes al archivo
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>

        List<ITopCliente> CargarTopClientes(string ruta);

        /// <summary>
        /// guarda el archivo de clientes
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>


        bool GuardarArchivoDeTopClientes(string ruta);
    }
}
