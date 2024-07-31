using ClaseControlador.interfaces;
using ModeloClase;
using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.producto
{


    public class ControladorDeArchivoProducto : IManipuladorDeArchivosProductos
    {
        /// <summary>
        /// cargar el archivo
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        /// <returns>The content of a file</returns>
        public string CargarArchivoDeProductos(string filePath)
        {
            var contenido = File.ReadAllText(filePath);
            return contenido;
        }

        /// <summary>
        /// cargar productos
        /// </summary>
        /// <param name="path">The filePath.</param>
        /// <returns>A list of People from the file.</returns>
        public List<IProducto> CargarProductos(string path)
        {
            var resultado = new List<IProducto>();
            var contenido = CargarArchivoDeProductos(path);
            var lineas = contenido.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);


            if (lineas.Length < 2)
            {
                throw new InvalidOperationException("El archivo  no contiene ningun producto.");
            }


            var header = lineas[0].Split(',');

            for (int i = 1; i < lineas.Length; i++)
            {
                var parts = lineas[i].Split(',');
                if (parts.Length < 3)
                {
                    throw new InvalidOperationException($"La línea {i + 1} no tiene suficientes columnas.");
                }

                var producto = new Producto
                {
                    NombreDeProducto = parts[0],
                    Precio = float.TryParse(parts[1], out var precio) ? precio : throw new FormatException($"El precio '{parts[1]}' no tiene el formato correcto."),
                    Cantidad = int.TryParse(parts[2], out var cantidad) ? cantidad : throw new FormatException($"La cantidad '{parts[2]}' no tiene el formato correcto.")
                };

                resultado.Add(producto);
            }

            return resultado;
        }

        /// <summary>
        /// Sguarda el archivo
        /// </summary>
        /// <param name="path">The filePath.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool GuardarArchivoDeProducto(string path)
        {
            throw new NotImplementedException();
        }
    }

}
