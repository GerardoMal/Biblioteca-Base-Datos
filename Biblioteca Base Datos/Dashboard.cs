namespace Biblioteca_Base_Datos
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BusquedaLibros BusquedaLibros = new BusquedaLibros();

            BusquedaLibros.Show();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login Login = new Login();

            Login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Devoluciones Devoluciones = new Devoluciones();

            Devoluciones.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoginPrestamos LoginPrestamos = new LoginPrestamos();

            LoginPrestamos.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}