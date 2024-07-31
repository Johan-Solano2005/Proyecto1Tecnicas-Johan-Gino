using ClaseControlador.clientes;
using ClaseControlador.Historial;
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
    public partial class FormsDeGestiónDeClientes : Form
    {
        private ControladorDeClientes controladorDeClientes;
        private ControladorDeHistorial controladorDeHistorial;

        public FormsDeGestiónDeClientes()
        {
            InitializeComponent();
            controladorDeClientes = new ControladorDeClientes();
            controladorDeHistorial = new ControladorDeHistorial();
            CargarClientesEnDataGridView();
            CargarHistorialEnDataGridView();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 volver = new Form1();
            volver.Show();
            this.Hide();
        }

        private void CargarClientesEnDataGridView()
        {
            try
            {
                var clientes = controladorDeClientes.ObtenerClientes();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = clientes;

                if (dataGridView1.Columns["Nombre"] == null)
                {
                    dataGridView1.Columns.Add("Nombre", "Nombre");
                }
                if (dataGridView1.Columns["Cedula"] == null)
                {
                    dataGridView1.Columns.Add("Cedula", "Cédula");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes en DataGridView: {ex.Message}");
            }
        }
        private void CargarHistorialEnDataGridView()
        {
            try
            {
                var historial = controladorDeHistorial.ObtenerHistorial();
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = historial;

              
                dataGridView2.Columns["Nombre"].HeaderText = "Nombre de Producto";
                dataGridView2.Columns["Fecha"].HeaderText = "Fecha de Compra";
                dataGridView2.Columns["Cantidad"].HeaderText = "Cantidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar historial en DataGridView: {ex.Message}");
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void FormsDeGestiónDeClientes_Load(object sender, EventArgs e)
        {

        }
    }
}
