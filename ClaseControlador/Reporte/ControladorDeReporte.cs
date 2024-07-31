using ModeloClase.Interfaces;
using ModeloClase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.Reporte
{
    public class ControladorDeReportes
    {
        private List<IReporte> ventasDiarias;


        private string NombreArchivoDiario = "VentasDiarias.csv";


        private ControladorDeArchivoDeReportes controladorDeArchivo = new ControladorDeArchivoDeReportes();

        public ControladorDeReportes()
        {
            ventasDiarias = new List<IReporte>();


            VerificarYCrearArchivos();
            CargarReportes();
        }

        private void VerificarYCrearArchivos()
        {
            CrearArchivoSiNoExiste(NombreArchivoDiario);

        }

        private void CrearArchivoSiNoExiste(string nombreArchivo)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), nombreArchivo);
            if (!File.Exists(filePath))
            {
                using (var sw = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    sw.WriteLine("Nombre,Fecha,Monto");
                }
            }
        }

        public void AgregarReporte(IReporte reporte, string tipoReporte)
        {
            var filePath = ObtenerRutaArchivo(tipoReporte);
            using (var sw = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                sw.WriteLine($"{reporte.Nombre},{reporte.Fecha},{reporte.Monto}");
            }
        }

        public List<IReporte> ObtenerReportes(string tipoReporte)
        {
            var rutaDeArchivo = ObtenerRutaArchivo(tipoReporte);
            Type tipo = tipoReporte switch
            {
                "Diario" => typeof(VentaDiaria),
                _ => throw new ArgumentException("Tipo de reporte desconocido.")
            };

            return controladorDeArchivo.CargarReporte(rutaDeArchivo, tipo);
        }

        public void ActualizarReporte(IReporte reporteActualizado, string tipoReporte)
        {
            var rutaDeArchivo = ObtenerRutaArchivo(tipoReporte);
            var reportes = ObtenerReportes(tipoReporte);

            var reporteExistente = reportes.FirstOrDefault(p => p.Nombre == reporteActualizado.Nombre);
            if (reporteExistente != null)
            {
                reporteExistente.Fecha = reporteActualizado.Fecha;
                reporteExistente.Monto = reporteActualizado.Monto;

                using (var sw = new StreamWriter(rutaDeArchivo, false, Encoding.UTF8))
                {
                    sw.WriteLine("Nombre,Fecha,Monto"); 
                    foreach (var item in reportes)
                    {
                        sw.WriteLine($"{item.Nombre},{item.Fecha},{item.Monto}");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("El reporte a actualizar no se encuentra en la lista.");
            }
        }

        public void EliminarReporte(string nombreReporte, string tipoReporte)
        {
            var rutaDeArchivo = ObtenerRutaArchivo(tipoReporte);
            var reportes = ObtenerReportes(tipoReporte);

            var reporteExistente = reportes.FirstOrDefault(p => p.Nombre == nombreReporte);
            if (reporteExistente != null)
            {
                reportes.Remove(reporteExistente);

                using (var sw = new StreamWriter(rutaDeArchivo, false, Encoding.UTF8))
                {
                    sw.WriteLine("Nombre,Fecha,Monto"); 
                    foreach (var item in reportes)
                    {
                        sw.WriteLine($"{item.Nombre},{item.Fecha},{item.Monto}");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("El reporte a eliminar no se encuentra en la lista.");
            }
        }

        private string ObtenerRutaArchivo(string tipoReporte)
        {
            return tipoReporte switch
            {
                "Diario" => Path.Combine(Directory.GetCurrentDirectory(), NombreArchivoDiario),

                _ => throw new ArgumentException("Tipo de reporte desconocido.")
            };
        }

        private void CargarReportes()
        {
            ventasDiarias = controladorDeArchivo.CargarReporte(ObtenerRutaArchivo("Diario"), typeof(VentaDiaria));

        }

        public void GuardarVentaDiaria(string nombre, DateTime fecha, float monto)
        {
            var reporte = new VentaDiaria
            {
                Nombre = nombre,
                Fecha = fecha,
                Monto = monto
            };
            AgregarReporte(reporte, "Diario");
        }



    }

}
