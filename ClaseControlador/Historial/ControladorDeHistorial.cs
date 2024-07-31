using ClaseControlador.producto;
using ModeloClase;
using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.Historial
{
    public class ControladorDeHistorial
    {
        private List<historial> historial;
        private string NombreDeArchivo { get; set; } = "Historial.csv";
        private ControladorDeArchivoDeHistorial controladorDeArchivoHistorial { get; set; } = new ControladorDeArchivoDeHistorial();

        /// <summary>
        /// // este metodo verifica si el archivo CSV existe,  si no lo crea
        /// </summary>
        public ControladorDeHistorial()
        {
            historial = new List<historial>();
            VerificarYCrearArchivo();
            CargarHistorial();
        }

        private void VerificarYCrearArchivo()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);

            if (!File.Exists(filePath))
            {
                using (var sw = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    sw.WriteLine("Nombre,Fecha,Cantidad");
                }
            }
        }

        public void AgregarHistorial(historial nuevoHistorial)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);

            using (var sw = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                sw.WriteLine($"{nuevoHistorial.Nombre},{nuevoHistorial.Fecha},{nuevoHistorial.Cantidad}");
            }
        }

        public List<IHistorial> ObtenerHistorial()
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            var resultado = controladorDeArchivoHistorial.CargarHistorial(rutaDeArchivo); 
            return resultado;
        }

        public void ActualizarHistorial(historial historialActualizado, string campo, string nuevoValor)
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            var historialList = ObtenerHistorial();

            var historialExistente = historial.FirstOrDefault(p => p.Nombre == historialActualizado.Nombre);

            if (historialExistente != null)
            {
                switch (campo)
                {
                    case "Nombre":
                        historialExistente.Nombre = nuevoValor;
                        break;
                    case "Fecha":
                        if (DateTime.TryParse(nuevoValor, out var nuevaFecha))
                        {
                            historialExistente.Fecha = nuevaFecha;
                        }
                        else
                        {
                            throw new FormatException("El formato de la fecha no es válido.");
                        }
                        break;
                    case "Cantidad":
                        if (int.TryParse(nuevoValor, out var nuevaCantidad))
                        {
                            historialExistente.Cantidad = nuevaCantidad;
                        }
                        else
                        {
                            throw new FormatException("El formato de la cantidad no es válido.");
                        }
                        break;
                    default:
                        throw new ArgumentException("Campo desconocido.");
                }

                using (var sw = new StreamWriter(rutaDeArchivo, false, Encoding.UTF8))
                {
                    sw.WriteLine("Nombre,Fecha,Cantidad"); 
                    foreach (var item in historial)
                    {
                        sw.WriteLine($"{item.Nombre},{item.Fecha},{item.Cantidad}");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("El historial a actualizar no se encuentra en la lista.");
            }
        }

        public void EliminarHistorial(string nombreHistorial)
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            var historialList = ObtenerHistorial();

            var historialExistente = historial.FirstOrDefault(p => p.Nombre == nombreHistorial);

            if (historialExistente != null)
            {
                historial.Remove(historialExistente);

                using (var sw = new StreamWriter(rutaDeArchivo, false, Encoding.UTF8))
                {
                    sw.WriteLine("Nombre,Fecha,Cantidad"); 
                    foreach (var item in historial)
                    {
                        sw.WriteLine($"{item.Nombre},{item.Fecha},{item.Cantidad}");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("El historial a eliminar no se encuentra en la lista.");
            }
        }

        public void DescontarHistorial(string nombre, int cantidad)
        {
            var historialExistente = historial.FirstOrDefault(p => p.Nombre == nombre);
            if (historialExistente != null)
            {
                historialExistente.Cantidad -= cantidad;
                if (historialExistente.Cantidad < 0)
                {
                    historialExistente.Cantidad = 0;
                }
                ActualizarArchivoCSV();
            }
            else
            {
                throw new InvalidOperationException("Historial no encontrado.");
            }
        }

        public void ActualizarArchivoCSV()
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            using (var sw = new StreamWriter(rutaDeArchivo, false, Encoding.UTF8))
            {
                sw.WriteLine("Nombre,Fecha,Cantidad");
                foreach (var item in historial)
                {
                    sw.WriteLine($"{item.Nombre},{item.Fecha},{item.Cantidad}");
                }
            }
        }

        private void CargarHistorial()
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            if (File.Exists(rutaDeArchivo))
            {
                var lineas = File.ReadAllLines(rutaDeArchivo);
                foreach (var linea in lineas.Skip(1)) 
                {
                    var campos = linea.Split(',');
                    var historialItem = new historial
                    {
                        Nombre = campos[0],
                        Fecha = DateTime.Parse(campos[1]),
                        Cantidad = int.Parse(campos[2])
                    };
                    historial.Add(historialItem);
                }
            }
        }
        public void GuardarHistorialDeCompra(string nombreProducto, DateTime fechaCompra, int cantidad)
        {
            var nuevoHistorial = new historial
            {
                Nombre = nombreProducto,
                Fecha = fechaCompra,
                Cantidad = cantidad
            };
            AgregarHistorial(nuevoHistorial);
        }
    }

}
