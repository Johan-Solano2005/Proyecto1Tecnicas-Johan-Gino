using ModeloClase;
using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.producto
{
    public class ControladorDeProductos
    {
        private List<Producto> productos;
        private string NombreDeArchivo { get; set; } = "Producto.csv";
        private ControladorDeArchivoProducto ControladorDeArchivoProducto { get; set; } = new ControladorDeArchivoProducto();

       
        public ControladorDeProductos()

        {
            productos = new List<Producto>();
            VerificarYCrearArchivo();
            CargarProductos();
        }

        /// <summary>
        ///   este metodo Verifica si el archivo CSV existe, si no lo crea
        /// </summary>
        private void VerificarYCrearArchivo()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);

            if (!File.Exists(filePath))
            {
                using (var sw = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    sw.WriteLine("Nombre,Precio,Cantidad");
                }
            }
        }

        /// <summary>
        /// Agrega un producto al archivo CSV.
        /// </summary>
        /// <param name="producto">El producto a agregar.</param>
        public void AgregarProducto(Producto producto)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);

            using (var sw = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                sw.WriteLine($"{producto.NombreDeProducto},{producto.Precio},{producto.Cantidad}");
            }
        }

        public List<IProducto> ObtenerProductos()
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            var resultado = ControladorDeArchivoProducto.CargarProductos(rutaDeArchivo);
            return resultado;
        }

        public void ActualizarProducto(Producto productoActualizado, string campo, string nuevoValor)
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            var productos = ObtenerProductos();

            // Buscar el producto a actualizar
            var productoExistente = productos.FirstOrDefault(p => p.NombreDeProducto == productoActualizado.NombreDeProducto);

            if (productoExistente != null)
            {
                // Actualizar solo el campo especificado
                switch (campo)
                {
                    case "Nombre":
                        productoExistente.NombreDeProducto = nuevoValor;
                        break;
                    case "Precio":
                        if (float.TryParse(nuevoValor, out var nuevoPrecio))
                        {
                            productoExistente.Precio = nuevoPrecio;
                        }
                        else
                        {
                            throw new FormatException("El formato del precio no es válido.");
                        }
                        break;
                    case "Cantidad":
                        if (int.TryParse(nuevoValor, out var nuevaCantidad))
                        {
                            productoExistente.Cantidad = nuevaCantidad;
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
                    foreach (var producto in productos)
                    {
                        sw.WriteLine($"{producto.NombreDeProducto},{producto.Precio},{producto.Cantidad}");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("El producto a actualizar no se encuentra en la lista.");
            }
        }
        public void EliminarProducto(string nombreProducto)
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            var productos = ObtenerProductos();

           
            var productoExistente = productos.FirstOrDefault(p => p.NombreDeProducto == nombreProducto);

            if (productoExistente != null)
            {
                
                productos.Remove(productoExistente);

                
                using (var sw = new StreamWriter(rutaDeArchivo, false, Encoding.UTF8))
                {
                    sw.WriteLine("Nombre,Precio,Cantidad"); 
                    foreach (var producto in productos)
                    {
                        sw.WriteLine($"{producto.NombreDeProducto},{producto.Precio},{producto.Cantidad}");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("El producto a eliminar no se encuentra en la lista.");
            }
        }
        public void DescontarProducto(string nombre, int cantidad)
        {
            var producto = productos.FirstOrDefault(p => p.NombreDeProducto == nombre);
            if (producto != null)
            {
                producto.Cantidad -= cantidad;
                if (producto.Cantidad < 0)
                {
                    producto.Cantidad = 0;
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
                foreach (var producto in productos)
                {
                    sw.WriteLine($"{producto.NombreDeProducto},{producto.Precio},{producto.Cantidad}");
                }
            }
        }
        private void CargarProductos()
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            if (File.Exists(rutaDeArchivo))
            {
                var lineas = File.ReadAllLines(rutaDeArchivo);
                foreach (var linea in lineas.Skip(1)) 
                {
                    var campos = linea.Split(',');
                    var producto = new Producto
                    {
                        NombreDeProducto = campos[0],
                        Precio = float.Parse(campos[1]),
                        Cantidad = int.Parse(campos[2])
                    };
                    productos.Add(producto);
                }
            }
        }
    }

}