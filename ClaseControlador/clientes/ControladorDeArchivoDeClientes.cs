using ClaseControlador.interfaces;
using ModeloClase;
using ModeloClase.Interfaces;
using System;
using System.IO;

namespace ClaseControlador.clientes
{

    public class ControladorDeArchivoDeClientes : IManipuladorDeArchivosClientes
    {
        public string CargarArchivoDeClientes(string rutaDeArchivo)
        {
            var contenido = File.ReadAllText(rutaDeArchivo);
            return contenido;
        }



        public List<IClientes> CargarClientes(string ruta)
        {
            var resultado = new List<IClientes>();
            var contenido = CargarArchivoDeClientes(ruta);
            var lineas = contenido.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (lineas.Length < 2)
            {
                throw new InvalidOperationException("El archivo no contiene ningún cliente.");
            }

            var header = lineas[0].Split(',');

            for (int i = 1; i < lineas.Length; i++)
            {
                var parts = lineas[i].Split(',');
                if (parts.Length < 2)
                {
                    throw new InvalidOperationException($"La línea {i + 1} no tiene suficientes columnas.");
                }

                var cliente = new Clientes
                {
                    Nombre = parts[0],
                    Cedula = int.TryParse(parts[1], out var cedula) ? cedula : throw new FormatException($"La cédula '{parts[1]}' no tiene el formato correcto."),
                };

                resultado.Add(cliente);
            }

            return resultado;
        }

        /// <summary>
        /// cargar productos
        /// </summary>
        /// <param name="path">The filePath.</param>
        /// <returns>A list of People from the file.</returns>


        public bool GuardarArchivoDeClientes(string ruta)
        {
            throw new NotImplementedException();
        }

        

    }


}

