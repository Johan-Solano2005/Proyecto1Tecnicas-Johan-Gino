using ModeloClase.Interfaces;
using ModeloClase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClaseControlador.interfaces;

namespace ClaseControlador.Historial
{
    internal class ControladorDeArchivoDeHistorial : IManipuladorDeArchivosDeHistorial
    {
        public string CargarArchivoDeHistorial(string rutaDeArchivo)
        {
            var contenido = File.ReadAllText(rutaDeArchivo);
            return contenido;
        }



        public List<IHistorial> CargarHistorial(string path)
        {
            var resultado = new List<IHistorial>();
            var contenido = CargarArchivoDeHistorial(path);
            var lineas = contenido.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);


            if (lineas.Length < 2)
            {
                throw new InvalidOperationException("El archivo  no contiene ningun Historial.");
            }


            var header = lineas[0].Split(',');

            for (int i = 1; i < lineas.Length; i++)
            {
                var parts = lineas[i].Split(',');
                if (parts.Length < 3)
                {
                    throw new InvalidOperationException($"La línea {i + 1} no tiene suficientes columnas.");
                }

                 var historial = new historial
                {
                     Nombre = parts[0],
                     Fecha = DateTime.TryParse(parts[1], out var fecha) ? fecha : throw new FormatException($"La fecha '{parts[1]}' no tiene el formato correcto."),
                     Cantidad = int.TryParse(parts[2], out var cantidad) ? cantidad : throw new FormatException($"La cantidad '{parts[2]}' no tiene el formato correcto.")
                 };

                resultado.Add(historial);
            }

            return resultado;
        }


        /// <summary>
        /// cargar productos
        /// </summary>
        /// <param name="path">The filePath.</param>
        /// <returns>A list of People from the file.</returns>


        public bool GuardarArchivoDeHistorial(string ruta)
        {
            throw new NotImplementedException();
        }

    }
}
