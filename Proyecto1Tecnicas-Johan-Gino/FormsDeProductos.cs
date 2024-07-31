using ClaseControlador.producto;
using ModeloClase;
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
    public partial class FormsDeProductos : Form
    {
        private ControladorDeProductos controladorDeProductos;
        private Producto productoSeleccionado;
        public FormsDeProductos()
        {
            InitializeComponent();
            controladorDeProductos = new ControladorDeProductos(); 


            // Configurar eventos
            TablaProductos.SelectionChanged += TablaProductos_SelectionChanged;

            TablaProductos.CellFormatting += TablaProductos_CellFormatting;

            // Configurar ComboBox
            comboBox1.Items.AddRange(new string[] { "Nombre", "Precio", "Cantidad" });
            comboBox1.SelectedIndex = 0; 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 volver = new Form1();
            volver.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            try
            {
              
                var nombre = textBox1.Text;
                var precio = float.Parse(textBox2.Text);
                var cantidad = int.Parse(textBox3.Text);

      
                var productosExistentes = controladorDeProductos.ObtenerProductos();
                if (productosExistentes.Any(p => p.NombreDeProducto.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ya existe un producto con este nombre.");
                    return;
                }

                
                var producto = new Producto
                {
                    NombreDeProducto = nombre,
                    Precio = precio,
                    Cantidad = cantidad
                };

              
                controladorDeProductos.AgregarProducto(producto);
                CargarProductosEnDataGridView();

                
                MessageBox.Show("Producto agregado exitosamente.");

                
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            catch (FormatException ex)
            {
               
                MessageBox.Show($"Error en el formato de entrada: {ex.Message}");
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void CargarProductosEnDataGridView()
        {
            try
            {
                var productos = controladorDeProductos.ObtenerProductos();
                TablaProductos.DataSource = null;
                TablaProductos.DataSource = productos;

                TablaProductos.Columns["NombreDeProducto"].HeaderText = "Nombre";
                TablaProductos.Columns["Precio"].HeaderText = "Precio";
                TablaProductos.Columns["Cantidad"].HeaderText = "Cantidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos en DataGridView: {ex.Message}");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
               
                var productos = controladorDeProductos.ObtenerProductos();

               
                TablaProductos.DataSource = null;
                TablaProductos.DataSource = productos;


                TablaProductos.Columns["NombreDeProducto"].HeaderText = "Nombre";
                TablaProductos.Columns["Precio"].HeaderText = "Precio";
                TablaProductos.Columns["Cantidad"].HeaderText = "Cantidad";
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Error al cargar productos: {ex.Message}");
            }

        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoSeleccionado != null)
                {
                    var campoSeleccionado = comboBox1.SelectedItem?.ToString();
                    var nuevoValor = textBoxEditar.Text;

                    if (!string.IsNullOrEmpty(campoSeleccionado) && !string.IsNullOrEmpty(nuevoValor))
                    {
                        // Crear un nuevo producto 
                        var productoActualizado = new Producto
                        {
                            NombreDeProducto = productoSeleccionado.NombreDeProducto, 
                            Precio = productoSeleccionado.Precio,
                            Cantidad = productoSeleccionado.Cantidad
                        };

                        // Actualizar el producto en el archivo
                        controladorDeProductos.ActualizarProducto(productoActualizado, campoSeleccionado, nuevoValor);

                       
                        CargarProductosEnDataGridView();

                       
                        textBoxEditar.Clear();

                        MessageBox.Show("Producto actualizado exitosamente.");
                    }

                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un producto para actualizar.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Error en el formato de entrada: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }



        private void TablaProductos_SelectionChanged(object sender, EventArgs e)
        {

            if (TablaProductos.SelectedRows.Count > 0)
            {
               
                var row = TablaProductos.SelectedRows[0];
                productoSeleccionado = (Producto)row.DataBoundItem;

                
                var campoSeleccionado = comboBox1.SelectedItem?.ToString();
                if (campoSeleccionado != null)
                {
                    switch (campoSeleccionado)
                    {
                        case "Nombre":
                            textBoxEditar.Text = productoSeleccionado.NombreDeProducto;
                            break;
                        case "Precio":
                            textBoxEditar.Text = productoSeleccionado.Precio.ToString();
                            break;
                        case "Cantidad":
                            textBoxEditar.Text = productoSeleccionado.Cantidad.ToString();
                            break;
                    }
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TablaProductos.SelectedRows.Count > 0)
            {
                // Obtener el producto seleccionado
                var row = TablaProductos.SelectedRows[0];
                var productoSeleccionado = (Producto)row.DataBoundItem;

                
                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Eliminar el producto usando ControladorDeProductos
                        controladorDeProductos.EliminarProducto(productoSeleccionado.NombreDeProducto);

                        // Recargar los productos en la pantall
                        CargarProductosEnDataGridView();

                        MessageBox.Show("Producto eliminado exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }


        }
        /// <summary>
        /// Este metodo cambia el color de la cantidad de productos dependiendo de si su cantantidad es baja
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="color"></param>
        private void TablaProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs color)
        {
            if (TablaProductos.Columns[color.ColumnIndex].Name == "Cantidad")
            {
                if (color.Value != null && int.TryParse(color.Value.ToString(), out int cantidad))
                {
                    if (cantidad < 10)
                    {
                        color.CellStyle.BackColor = Color.White;
                        color.CellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        color.CellStyle.BackColor = Color.White;
                        color.CellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void FormsDeProductos_Load(object sender, EventArgs e)
        {

        }
    }
}






