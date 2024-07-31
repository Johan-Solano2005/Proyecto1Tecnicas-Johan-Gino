using ClaseControlador.interfaces;
using ModeloClase.Interfaces;
using ModeloClase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.Top_vendedores
{
    public class ControladorDeArchivoDeTopVendedores : IManipuladorDeArchivoDeTopVendedores
    {
        /// <summary>
        /// cargar el archivo
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        /// <returns>The content of a file</returns>
        public string CargarArchivoDeTopVendedores(string filePath)
        {
            var contenido = File.ReadAllText(filePath);
            return contenido;
        }

        /// <summary>
        /// cargar productos
        /// </summary>
        /// <param name="path">The filePath.</param>
        /// <returns>A list of People from the file.</returns>
        public List<ITopVendedores> CargarTopVendedores(string path)
        {
            var resultado = new List<ITopVendedores>();
            var contenido = CargarArchivoDeTopVendedores(path);
            var lineas = contenido.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);


            if (lineas.Length < 2)
            {
                throw new InvalidOperationException("El archivo  no contiene ningun vendedor.");
            }


            var header = lineas[0].Split(',');

            for (int i = 1; i < lineas.Length; i++)
            {
                var parts = lineas[i].Split(',');
                if (parts.Length < 3)
                {
                    throw new InvalidOperationException($"La línea {i + 1} no tiene suficientes columnas.");
                }

                var topVendedores = new TopVendedores
                {
                    Nombre = parts[0],
                    Cedula = int.TryParse(parts[1], out var cedula) ? cedula : throw new FormatException($"la cedula '{parts[1]}' no tiene el formato correcto."),
                    CantidadDeVentas = int.TryParse(parts[2], out var cantidadDeventas) ? cantidadDeventas : throw new FormatException($"La cantidad de ventas '{parts[2]}' no tiene el formato correcto.")
                };

                resultado.Add(topVendedores);
            }

            return resultado;
        }

        /// <summary>
        /// Se guarda el archivo
        /// </summary>
        /// <param name="path">The filePath.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool GuardarArchivoDeTopVendedores(string path)
        {
            throw new NotImplementedException();
        }
    }
}
