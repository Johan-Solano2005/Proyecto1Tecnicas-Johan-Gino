using ClaseControlador.Top_clientes;
using ModeloClase.Interfaces;
using ModeloClase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.Top_vendedores
{
    public class ControladorDeTopVendedores
    {
        private List<TopVendedores> topVendedores;
        private string NombreDeArchivo { get; set; } = "TopVendedores.csv";
        private ControladorDeArchivoDeTopVendedores controladorDeArchivoDeTopVendedores { get; set; } = new ControladorDeArchivoDeTopVendedores();


        public ControladorDeTopVendedores()

        {
            topVendedores = new List<TopVendedores>();
            VerificarYCrearArchivo();
            CargarTopVendedores();
        }

        /// <summary>
        /// Verifica si el archivo CSV existe. Si no existe, lo crea con una línea de encabezado.
        /// </summary>
        private void VerificarYCrearArchivo()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);

            if (!File.Exists(filePath))
            {
                using (var sw = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    sw.WriteLine("Nombre,Cedula,Cantidad de Ventas");
                }
            }
        }

        /// <summary>
        /// Agrega un producto al archivo CSV.
        /// </summary>
        /// <param name="producto">El producto a agregar.</param>
        public void AgregarTopVendedores(TopVendedores topVendedores)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);

            using (var sw = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                sw.WriteLine($"{topVendedores.Nombre},{topVendedores.Cedula},{topVendedores.CantidadDeVentas}");
            }
        }

        public List<ITopVendedores> ObtenerTopVendedores()
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            var resultado = controladorDeArchivoDeTopVendedores.CargarTopVendedores(rutaDeArchivo);
            return resultado;
        }

        public void ActualizarTopVendedores(TopVendedores TopVendedoresActualizado, string campo, string nuevoValor)
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            var topClientes = ObtenerTopVendedores();


            var topVendedoresExistente = topClientes.FirstOrDefault(p => p.Nombre == TopVendedoresActualizado.Nombre);

            if (topVendedoresExistente != null)
            {

                switch (campo)
                {
                    case "Nombre":
                        topVendedoresExistente.Nombre = nuevoValor;
                        break;
                    case "Cedula":
                        if (int.TryParse(nuevoValor, out var nuevaCedula))
                        {
                            topVendedoresExistente.Cedula = nuevaCedula;
                        }
                        else
                        {
                            throw new FormatException("El formato de la cedula no es válido.");
                        }
                        break;
                    case "Cantidad de ventas":
                        if (int.TryParse(nuevoValor, out var nuevaCantidad))
                        {
                            topVendedoresExistente.CantidadDeVentas = nuevaCantidad;
                        }
                        else
                        {
                            throw new FormatException("El formato de la cantidad de ventas no es válido.");
                        }
                        break;
                    default:
                        throw new ArgumentException("Campo desconocido.");
                }


                using (var sw = new StreamWriter(rutaDeArchivo, false, Encoding.UTF8))
                {
                    sw.WriteLine("Nombre,Precio,Cantidad de ventas");
                    foreach (var topVendedores in topVendedores)
                    {
                        sw.WriteLine($"{topVendedores.Nombre},{topVendedores.Cedula},{topVendedores.CantidadDeVentas}");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("El cajero a actualizar no se encuentra en la lista.");
            }
        }
       
        public void DescontarTopVendedores(string nombre, int cantidad)
        {
            var TopVendedores = topVendedores.FirstOrDefault(p => p.Nombre == nombre);
            if (TopVendedores != null)
            {
                TopVendedores.CantidadDeVentas -= cantidad;
                if (TopVendedores.CantidadDeVentas < 0)
                {
                    TopVendedores.CantidadDeVentas = 0;
                }
            }
            else
            {
                throw new InvalidOperationException("Producto no encontrado.");
            }
        }

        public void ActualizarArchivoCSV()
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            using (var sw = new StreamWriter(rutaDeArchivo, false, Encoding.UTF8))
            {
                sw.WriteLine("Nombre,Precio,Cantidad de ventas");
                foreach (var topVendedores in topVendedores)
                {
                    sw.WriteLine($"{topVendedores.Nombre},{topVendedores.Cedula} , {topVendedores.CantidadDeVentas}");
                }
            }
        }
        private void CargarTopVendedores()
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            if (File.Exists(rutaDeArchivo))
            {
                var lineas = File.ReadAllLines(rutaDeArchivo);
                foreach (var linea in lineas.Skip(1))
                {
                    var campos = linea.Split(',');
                    var TopVendedores = new TopVendedores
                    {
                        Nombre = campos[0],
                        Cedula = int.Parse(campos[1]),
                        CantidadDeVentas = int.Parse(campos[2])
                    };
                    topVendedores.Add(TopVendedores);
                }
            }
        }
        public void ActualizarContadorDeVentas(string nombre, int cedula)
        {
            var  vendedorExistente = topVendedores.FirstOrDefault(c => c.Nombre == nombre && c.Cedula == cedula);
            if (vendedorExistente != null)
            {
                vendedorExistente.CantidadDeVentas++;
            }
            else
            {
                var nuevoCliente = new TopVendedores
                {
                    Nombre = nombre,
                    Cedula = cedula,
                    CantidadDeVentas = 1
                };
                topVendedores.Add(nuevoCliente);
            }
            ActualizarArchivoCSV();
        }
    }
}
