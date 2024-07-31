using ClaseControlador.interfaces;
using ModeloClase;
using ModeloClase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseControlador.clientes
{
    public class ControladorDeClientes
    {
        private List<Clientes> clientes;
        private string NombreDeArchivo { get; set; } = "Clientes.csv";
        private ControladorDeArchivoDeClientes ControladorDeArchivoDeClientes { get; set; } = new ControladorDeArchivoDeClientes();

        public ControladorDeClientes()
        {
            clientes = new List<Clientes>();
            VerificarYCrearArchivo();

        }

        private void VerificarYCrearArchivo()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);

            if (!File.Exists(filePath))
            {
                using (var sw = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    sw.WriteLine("Nombre,Cedula");
                }
            }
        }
        public List<IClientes> ObtenerClientes()
        {
            var rutaDeArchivo = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);
            var resultado = ControladorDeArchivoDeClientes.CargarClientes(rutaDeArchivo);
            return resultado;
        }


        public void AgregarCliente(Clientes cliente)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), NombreDeArchivo);

            using (var sw = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                sw.WriteLine($"{cliente.Nombre},{cliente.Cedula}");
            }
        }

    }
}