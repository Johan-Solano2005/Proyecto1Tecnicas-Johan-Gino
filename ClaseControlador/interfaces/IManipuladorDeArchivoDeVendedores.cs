using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.interfaces
{
    public interface IManipuladorDeArchivoDeTopVendedores
    {
        /// <summary>
        /// cargar los archivos de los top vendedores
        /// </summary>
        /// <param name="rutaDeArchivo"></param>
        /// <returns></returns>
        string CargarArchivoDeTopVendedores(string rutaDeArchivo);

        /// <summary>
        /// carga los top vendedores al archivo
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>

        List<ITopVendedores> CargarTopVendedores(string ruta);

        /// <summary>
        /// guarda el archivo de top vendedores
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>


        bool GuardarArchivoDeTopVendedores(string ruta);
    }
}
