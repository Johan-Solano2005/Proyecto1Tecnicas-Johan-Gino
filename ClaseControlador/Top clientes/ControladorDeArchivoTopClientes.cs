using ModeloClase.Interfaces;
using ModeloClase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClaseControlador.interfaces;

namespace ClaseControlador.Top_clientes
{
    public class ControladorDeArchivoTopClientes : IManipuladorDeArchivoDeTopClientes
    {
        /// <summary>
        /// cargar el archivo
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        /// <returns>The content of a file</returns>
        public string CargarArchivoDeTopClientes(string filePath)
        {
            var contenido = File.ReadAllText(filePath);
            return contenido;
        }

        /// <summary>
        /// cargar productos
        /// </summary>
        /// <param name="path">The filePath.</param>
        /// <returns>A list of People from the file.</returns>
        public List<ITopCliente> CargarTopClientes(string path)
        {
            var resultado = new List<ITopCliente>();
            var contenido = CargarArchivoDeTopClientes(path);
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

                var topClientes = new TopClientes
                {
                    Nombre = parts[0],
                    Cedula = int.TryParse(parts[1], out var cedula) ? cedula : throw new FormatException($"la cedula '{parts[1]}' no tiene el formato correcto."),
                    CantidadDeCompras = int.TryParse(parts[2], out var cantidadDeCompras) ? cantidadDeCompras : throw new FormatException($"La cantidad de compras '{parts[2]}' no tiene el formato correcto.")
                };

                resultado.Add(topClientes);
            }

            return resultado;
        }

        /// <summary>
        /// Se guarda el archivo
        /// </summary>
        /// <param name="path">The filePath.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool GuardarArchivoDeTopClientes(string path)
        {
            throw new NotImplementedException();
        }
    }
}
