using ClaseControlador.producto;
using ModeloClase.Interfaces;
using ModeloClase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.Top_clientes
{
    public class ControladorDeTopClientes
    {
        private List<TopClientes> topClientes;
        private string NombreDeArchivo { get; set; } = "TopClientes.csv";
        private ControladorDeArchivoTopClientes controladorDeArchioTopClientes { get; set; } = new ControladorDeArchivoTopClientes();


        public ControladorDeTopClientes()

        {
            topClientes = new List<TopClientes>();
            VerificarYCrearArchivo();
            CargarTopCliente();
        }
        /// <summary>
        ///  este metodo Verifica si el archivo CSV existe, si no lo crea
        /// </summary>
        private void VerificarYCrearArchivo()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);

            if (!File.Exists(filePath))
            {
                using (var sw = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    sw.WriteLine("Nombre,Cedula,Cantidad de compras");
                }
            }
        }

        /// <summary>
        /// Agrega un producto al archivo CSV.
        /// </summary>
        /// <param name="producto">El producto a agregar.</param>
        public void AgregarTopCliente(TopClientes topClientes)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);

            using (var sw = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                sw.WriteLine($"{topClientes.Nombre},{topClientes.Cedula},{topClientes.CantidadDeCompras}");
            }
        }

        public List<ITopCliente> ObtenerTopClientes()
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            var resultado = controladorDeArchioTopClientes.CargarTopClientes(rutaDeArchivo);
            return resultado;
        }

        public void ActualizarTopClientes(TopClientes TopClientesActualizado, string campo, string nuevoValor)
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            var topClientes = ObtenerTopClientes();

          
            var topClienteExistente = topClientes.FirstOrDefault(p => p.Nombre == TopClientesActualizado.Nombre);

            if (topClienteExistente != null)
            {
             
                switch (campo)
                {
                    case "Nombre":
                        topClienteExistente.Nombre = nuevoValor;
                        break;
                    case "Cedula":
                        if (int.TryParse(nuevoValor, out var nuevaCedula))
                        {
                            topClienteExistente.Cedula = nuevaCedula;
                        }
                        else
                        {
                            throw new FormatException("El formato de la cedula no es válido.");
                        }
                        break;
                    case "Cantidad":
                        if (int.TryParse(nuevoValor, out var nuevaCantidad))
                        {
                            topClienteExistente.CantidadDeCompras = nuevaCantidad;
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
                    sw.WriteLine("Nombre,Precio,Cantidad");
                    foreach (var topCliente in topClientes)
                    {
                        sw.WriteLine($"{topCliente.Nombre},{topCliente.Cedula},{topCliente.CantidadDeCompras}");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("El producto a actualizar no se encuentra en la lista.");
            }
        }
        public void EliminarTopCliente(string nombreTopCliente)
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            var productos = ObtenerTopClientes();

            
            var topClienteExistente = topClientes.FirstOrDefault(p => p.Nombre == nombreTopCliente);

            if (topClienteExistente != null)
            {
               
                topClientes.Remove(topClienteExistente);

                using (var sw = new StreamWriter(rutaDeArchivo, false, Encoding.UTF8))
                {
                    sw.WriteLine("Nombre,Cedula,Cantidad"); 
                    foreach (var topCliente in topClientes)
                    {
                        sw.WriteLine($"{topCliente.Nombre},{topCliente.Cedula},{topCliente.CantidadDeCompras}");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("El top cliente a eliminar no se encuentra en la lista.");
            }
        }
        public void DescontarTopClientes(string nombre, int cantidad)
        { 
            var topCliente = topClientes.FirstOrDefault(p => p.Nombre == nombre);
            if (topCliente != null)
            {
                topCliente.CantidadDeCompras -= cantidad;
                if (topCliente.CantidadDeCompras < 0)
                {
                    topCliente.CantidadDeCompras = 0;
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
                sw.WriteLine("Nombre,Precio,Cantidad");
                foreach (var topCliente in topClientes)
                {
                    sw.WriteLine($"{topCliente.Nombre},{topCliente.Cedula} , {topCliente.CantidadDeCompras}");
                }
            }
        }
        private void CargarTopCliente()
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            if (File.Exists(rutaDeArchivo))
            {
                var lineas = File.ReadAllLines(rutaDeArchivo);
                foreach (var linea in lineas.Skip(1)) 
                {
                    var campos = linea.Split(',');
                    var topCliente = new TopClientes
                    {
                        Nombre = campos[0],
                        Cedula = int.Parse(campos[1]),
                        CantidadDeCompras = int.Parse(campos[2])
                    };
                    topClientes.Add(topCliente);
                }
            }
        }
        public void ActualizarContadorDeCompras(string nombre, int cedula)
        {
            var clienteExistente = topClientes.FirstOrDefault(c => c.Nombre == nombre && c.Cedula == cedula);
            if (clienteExistente != null)
            {
                clienteExistente.CantidadDeCompras++;
            }
            else
            {
                var nuevoCliente = new TopClientes
                {
                    Nombre = nombre,
                    Cedula = cedula,
                    CantidadDeCompras = 1
                };
                topClientes.Add(nuevoCliente);
            }
            ActualizarArchivoCSV();
        }
    }
}
