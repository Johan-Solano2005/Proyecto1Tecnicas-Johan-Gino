using ClaseControlador.interfaces;
using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.Reporte
{
    internal class ControladorDeArchivoDeReportes : IManipuladorDeArchivosDeReportes
{
    public string CargarArchivoDeReporte(string rutaDeArchivo)
    {
        return File.ReadAllText(rutaDeArchivo);
    }

    public List<IReporte> CargarReporte(string ruta, Type tipoReporte)
    {
        var resultado = new List<IReporte>();
        var contenido = CargarArchivoDeReporte(ruta);
        var lineas = contenido.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        if (lineas.Length < 2)
        {
            throw new InvalidOperationException("El archivo no contiene ningún reporte.");
        }

        var header = lineas[0].Split(',');

        for (int i = 1; i < lineas.Length; i++)
        {
            var parts = lineas[i].Split(',');
            if (parts.Length < 3)
            {
                throw new InvalidOperationException($"La línea {i + 1} no tiene suficientes columnas.");
            }

            IReporte reporte = (IReporte)Activator.CreateInstance(tipoReporte);
            reporte.Nombre = parts[0];
            reporte.Fecha = DateTime.TryParse(parts[1], out var fecha) ? fecha : throw new FormatException($"La fecha '{parts[1]}' no tiene el formato correcto.");
            reporte.Monto = float.TryParse(parts[2], out var monto) ? monto : throw new FormatException($"El monto '{parts[2]}' no tiene el formato correcto.");

            resultado.Add(reporte);
        }

        return resultado;
    }

    public bool GuardarArchivoDeReporte(string ruta)
    {
       
        throw new NotImplementedException();
    }
}
}
