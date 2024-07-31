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

namespace Proyecto1Tecnicas_Johan_Gino.Form_de_factura
{
    public partial class FormDeFactura : Form
    {
        private List<Producto> carritoDeCompras;
        private float totalCarrito;
        string pagoCon;
        public FormDeFactura(string nombreCliente, List<Producto> carrito, float Total, string metodoDePago, string cajero)
        {

            InitializeComponent();
            label5.Text = nombreCliente;
            carritoDeCompras = carrito;
            CargarCarritoEnDataGridView();
            totalCarrito = Total;
            label4.Text = $"Total: ${totalCarrito}";
            pagoCon = metodoDePago;
            label7.Text = pagoCon;
            label11.Text = cajero;

        }


        private void FormDeFactura_Load(object sender, EventArgs e)
        {
            label9.Text = $"Fecha: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
        }
        private void CargarCarritoEnDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = carritoDeCompras;
            dataGridView1.Columns["NombreDeProducto"].HeaderText = "Nombre";
            dataGridView1.Columns["Precio"].HeaderText = "Precio";
            dataGridView1.Columns["Cantidad"].HeaderText = "Cantidad";
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 VolverAlInicio = new Form1();
            VolverAlInicio.Show();
            this.Hide();
        }

       
    }
}
