using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.interfaces
{
    /// <summary>
    /// interfaz de manipulador de archivos para productos
    /// </summary>
    public interface IManipuladorDeArchivosProductos
    {
        /// <summary>
        /// cargar los archivos de producto
        /// </summary>
        /// <param name="rutaDeArchivo"></param>
        /// <returns></returns>
        string CargarArchivoDeProductos(string rutaDeArchivo);

        /// <summary>
        /// carga los productos al archivo
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>

        List<IProducto> CargarProductos(string ruta);

        /// <summary>
        /// guarda el archivo de productos
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>


        bool GuardarArchivoDeProducto (string ruta); 





    }
}
