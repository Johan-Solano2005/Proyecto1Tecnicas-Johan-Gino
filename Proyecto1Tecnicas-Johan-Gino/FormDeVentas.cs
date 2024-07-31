using ClaseControlador.clientes;
using ClaseControlador.Historial;
using ClaseControlador.producto;
using ClaseControlador.Reporte;
using ClaseControlador.Top_clientes;
using ClaseControlador.Top_vendedores;
using ModeloClase;
using Proyecto1Tecnicas_Johan_Gino.Form_de_factura;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1Tecnicas_Johan_Gino
{
    public partial class FormDeVentas : Form
    {
        private ControladorDeClientes controladorDeClientes;
        private ControladorDeProductos controladorDeProductos;
        private List<Producto> carritoDeCompras;
        private ControladorDeHistorial controladorDeHistorial;
        private ControladorDeReportes controladorDeReportes;
        private ControladorDeTopClientes controladorDeTopClientes;
        private ControladorDeTopVendedores controladorDeTopVendedores;
        public FormDeVentas()
        {
            InitializeComponent();
            controladorDeProductos = new ControladorDeProductos();
            carritoDeCompras = new List<Producto>();
            CargarProductosEnDataGridView();
            controladorDeClientes = new ControladorDeClientes();
            controladorDeHistorial = new ControladorDeHistorial();
            controladorDeReportes = new ControladorDeReportes();
            controladorDeTopClientes = new ControladorDeTopClientes();
            controladorDeTopVendedores = new ControladorDeTopVendedores();

            


            comboBox1.Items.AddRange(new string[] { "Efectivo", "Tarjeta", "Transferencia bancaria" });
            comboBox1.SelectedIndex = 0; 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 volver = new Form1();
            volver.Show();
            this.Hide();
        }
        private void CargarProductosEnDataGridView()
        {
            try
            {
                var productos = controladorDeProductos.ObtenerProductos();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = productos;

               
                dataGridView1.Columns["NombreDeProducto"].HeaderText = "Nombre";
                dataGridView1.Columns["Precio"].HeaderText = "Precio";
                dataGridView1.Columns["Cantidad"].HeaderText = "Cantidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos en DataGridView: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cajero = textBox4.Text;
            if (string.IsNullOrEmpty(cajero))
            {
                MessageBox.Show("El espacio de cajero está vacío.");
                return;
            }
            if (!int.TryParse(textBox5.Text, out int cedulaDeCajero))
            {
                MessageBox.Show("Por favor, ingrese una cédula válida.");
                return;
            }

            if (carritoDeCompras.Count == 0)
            {
                MessageBox.Show("El carrito de compras está vacío.");
                return;
            }

            string metodoPago = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(metodoPago))
            {
                MessageBox.Show("Por favor, selecciona un método de pago.");
                return;
            }

            string nombreCliente = textBox1.Text;
            if (string.IsNullOrEmpty(nombreCliente))
            {
                MessageBox.Show("Por favor, ingrese el nombre del cliente.");
                return;
            }

            if (!int.TryParse(textBox2.Text, out int cedulaDeCliente))
            {
                MessageBox.Show("Por favor, ingrese una cédula válida.");
                return;
            }

            float totalCarrito = carritoDeCompras.Sum(p => p.Precio * p.Cantidad);

            try
            {
               
                foreach (var productoCarrito in carritoDeCompras)
                {
                    controladorDeProductos.DescontarProducto(productoCarrito.NombreDeProducto, productoCarrito.Cantidad);
                    // Guardar en el historial de compra
                    controladorDeHistorial.GuardarHistorialDeCompra(productoCarrito.NombreDeProducto, DateTime.Now, productoCarrito.Cantidad);
                }

                // Descuenta productos del inventario
                foreach (var productoCarrito in carritoDeCompras)
                {
                    controladorDeProductos.DescontarProducto(productoCarrito.NombreDeProducto, productoCarrito.Cantidad);
                }
                var cliente = new Clientes
                {
                    Nombre = nombreCliente,
                    Cedula = cedulaDeCliente
                };
                controladorDeClientes.AgregarCliente(cliente);

                controladorDeReportes.GuardarVentaDiaria(nombreCliente, DateTime.Now, totalCarrito);
                controladorDeTopClientes.ActualizarContadorDeCompras(nombreCliente, cedulaDeCliente);
                controladorDeTopVendedores.ActualizarContadorDeVentas(cajero, cedulaDeCajero);

                // Actualiza  el archivo CSV de productos
                controladorDeProductos.ActualizarArchivoCSV();

                MessageBox.Show("Pago realizado exitosamente.");

                // Limpiar el carrito y recargar los productos en el DataGridView
                FormDeFactura factura = new FormDeFactura(nombreCliente, carritoDeCompras, totalCarrito, metodoPago, cajero);
                CargarCarritoEnDataGridView();
                CargarProductosEnDataGridView();
                factura.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el pago: {ex.Message}");
            }
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                var productoSeleccionado = (Producto)row.DataBoundItem;

                int cantidad;
                if (int.TryParse(textBox3.Text, out cantidad) && cantidad > 0)
                {
                    var productoCarrito = carritoDeCompras.FirstOrDefault(p => p.NombreDeProducto == productoSeleccionado.NombreDeProducto);
                    int cantidadEnCarrito = productoCarrito != null ? productoCarrito.Cantidad : 0;

                    if (cantidad <= (productoSeleccionado.Cantidad - cantidadEnCarrito))
                    {
                        if (productoCarrito != null)
                        {
                            productoCarrito.Cantidad += cantidad;
                        }
                        else
                        {
                            productoCarrito = new Producto
                            {
                                NombreDeProducto = productoSeleccionado.NombreDeProducto,
                                Precio = productoSeleccionado.Precio,
                                Cantidad = cantidad
                            };
                            carritoDeCompras.Add(productoCarrito);
                        }
                        CargarCarritoEnDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Cantidad insuficiente en el inventario.");
                    }
                }
                else
                {
                    MessageBox.Show("Cantidad inválida.");
                }
            }
        }




        private void CargarCarritoEnDataGridView()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = carritoDeCompras;
            dataGridView2.Columns["NombreDeProducto"].HeaderText = "Nombre";
            dataGridView2.Columns["Precio"].HeaderText = "Precio";
            dataGridView2.Columns["Cantidad"].HeaderText = "Cantidad";
        }

        private void FormDeVentas_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count > 0)
            {
                var row = dataGridView2.SelectedRows[0];
                var productoSeleccionado = (Producto)row.DataBoundItem;

                
                carritoDeCompras.Remove(productoSeleccionado);

               
                CargarCarritoEnDataGridView();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar.");
            }
        }
      
    }
}


