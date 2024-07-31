namespace Proyecto1Tecnicas_Johan_Gino
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AjustarTextoEnPanel();
        }
        /// <summary>
        /// este metodo configura el label del incia para el mensaje de bienvenida
        /// </summary>
        private void AjustarTextoEnPanel()
        {
            
            panel1.BorderStyle = BorderStyle.FixedSingle; 

           
            label1.Text = "Este es el progrma de la ferreteria los 3 tornillos, este programa permite gestionar el inventario, realizar una venta, tener un registro de clientes y un indice de mejor vendedores y clientes junto con el registro de ventas diarias, anuales y mensuales";
            label1.TextAlign = ContentAlignment.TopLeft;

            
            panel1.SizeChanged += (sender, e) =>
            {
                label1.MaximumSize = new Size(panel1.Width - 10, 0); 
            };
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FormsDeProductos mostrar = new FormsDeProductos();
            mostrar.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            FormDeVentas mostrar = new FormDeVentas();
            mostrar.Show();
            this.Hide();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormsDeGestiónDeClientes mostrarClientes = new FormsDeGestiónDeClientes();
            mostrarClientes.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormDeReportesDeAnalisis mostrar = new FormDeReportesDeAnalisis();
            mostrar.Show();
            this.Hide();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
