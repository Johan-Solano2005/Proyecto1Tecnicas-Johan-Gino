using ClaseControlador.producto;
using ClaseControlador.Reporte;
using ClaseControlador.Top_clientes;
using ClaseControlador.Top_vendedores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1Tecnicas_Johan_Gino
{
    public partial class FormDeReportesDeAnalisis : Form
    {
        private ControladorDeReportes controladorDeReportes;
        private ControladorDeProductos controladorDeProductos;
        private ControladorDeTopClientes controladorDeTopClientes;
        private ControladorDeTopVendedores controladorDeTopVendedores;



        public FormDeReportesDeAnalisis()
        {

            InitializeComponent();

            // Inicializar el controlador de reportes
            controladorDeReportes = new ControladorDeReportes();
            controladorDeProductos = new ControladorDeProductos();
            controladorDeTopClientes = new ControladorDeTopClientes();
            controladorDeTopVendedores = new ControladorDeTopVendedores();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy";
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;


            // Cargar los reportes automáticamente al inicializar el formulario
            CargarVentasDiarias();
            CargarReporteMensual();
            CargarReportAnual();
            CargarProductosEnDataGridView();
            CargarTopClientesEnDataGridView();
            CargarTopVendedoresEnDataGridView();




        }

        private void dateTimePicker1_ValueChanged(object? sender, EventArgs e)
        {
            CargarReporteMensual();
        }

        private void dateTimePicker2_ValueChanged(object? sender, EventArgs e)
        {
            CargarReportAnual();
        }

        
        private void CargarVentasDiarias()
        {
            try
            {
                
                var reportesDiarios = controladorDeReportes.ObtenerReportes("Diario");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = reportesDiarios;

                
                dataGridView1.Columns["Nombre"].HeaderText = "Nombre";
                dataGridView1.Columns["Fecha"].HeaderText = "Fecha";
                dataGridView1.Columns["Monto"].HeaderText = "Monto";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ventas diarias: {ex.Message}");
            }
        }
        private void CargarReporteMensual()
        {
            DateTime fechaSeleccionada = dateTimePicker1.Value;
            int mesSeleccionado = fechaSeleccionada.Month;
            int añoSeleccionado = fechaSeleccionada.Year;

            // Obtiene todas las ventas diarias
            var ventasDiarias = controladorDeReportes.ObtenerReportes("Diario");

            // Filtrar las ventas para el mes y año seleccionados
            var ventasDelMes = ventasDiarias
                .Where(v => v.Fecha.Month == mesSeleccionado && v.Fecha.Year == añoSeleccionado)
                .ToList();

            // Cargar los datos mensuales en el la pantalla
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = ventasDelMes;
            dataGridView2.Columns["Nombre"].HeaderText = "Nombre";
            dataGridView2.Columns["Fecha"].HeaderText = "Fecha";
            dataGridView2.Columns["Monto"].HeaderText = "Monto";

            // Calcular el total del mes
            float totalVentasDelMes = ventasDelMes.Sum(v => v.Monto);
            label6.Text = $"Total del mes {fechaSeleccionada.ToString("MMMM yyyy")}: {totalVentasDelMes.ToString("C2", new CultureInfo("es-CR"))}";
        }

        private void CargarReportAnual()
        {
            DateTime fechaSeleccionada = dateTimePicker2.Value;
            int añoSeleccionado = fechaSeleccionada.Year;

            // obtiene todas las ventas diarias, para luego poder seguir con el año
            var ventasDiarias = controladorDeReportes.ObtenerReportes("Diario");

            
            var ventasAnuales = ventasDiarias
                .Where(v => v.Fecha.Year == añoSeleccionado)
                .ToList();

            // Cargar los datos anuales en la pantalla
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = ventasAnuales;
            dataGridView3.Columns["Nombre"].HeaderText = "Nombre";
            dataGridView3.Columns["Fecha"].HeaderText = "Fecha";
            dataGridView3.Columns["Monto"].HeaderText = "Monto";
            
          

            // Calcular el total del mes
            float totalVentasAnuales = ventasAnuales.Sum(v => v.Monto);
            label7.Text = $"Total del año {fechaSeleccionada.ToString("yyyy")}: {totalVentasAnuales.ToString("C2", new CultureInfo("es-CR"))}";
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
                dataGridView4.DataSource = null;
                dataGridView4.DataSource = productos;

                
                dataGridView4.Columns["NombreDeProducto"].HeaderText = "Nombre";
                dataGridView4.Columns["Precio"].HeaderText = "Precio";
                dataGridView4.Columns["Cantidad"].HeaderText = "Cantidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos en DataGridView: {ex.Message}");
            }
        }
        private void CargarTopClientesEnDataGridView()
        {
            try
            {
                var topClientes = controladorDeTopClientes.ObtenerTopClientes();
                dataGridView6.DataSource = null;
                dataGridView6.DataSource = topClientes;

                dataGridView6.Columns["Nombre"].HeaderText = "Nombre del Cliente";
                dataGridView6.Columns["Cedula"].HeaderText = "Cédula";
                dataGridView6.Columns["CantidadDeCompras"].HeaderText = "Cantidad de Compras";

               
                dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes más frecuentes: {ex.Message}");
            }
        }
        private void CargarTopVendedoresEnDataGridView()
        {
            try
            {
                var topClientes = controladorDeTopVendedores.ObtenerTopVendedores();
                dataGridView5.DataSource = null;
                dataGridView5.DataSource = topClientes;

            
                dataGridView5.Columns["Nombre"].HeaderText = "Nombre del vendedor";
                dataGridView5.Columns["Cedula"].HeaderText = "Cédula";
                dataGridView5.Columns["CantidadDeVentas"].HeaderText = "Cantidad de ventas";

               
                dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes más frecuentes: {ex.Message}");
            }
        }
        private void FormDeReportesDeAnalisis_Load_1(object sender, EventArgs e)
        {

        }
    }
}
