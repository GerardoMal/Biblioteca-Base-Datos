using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca_Base_Datos
{
    public partial class Gestion_de_Libros : Form
    {
        public Gestion_de_Libros()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarEditarLibros AgregarEditarLibros = new AgregarEditarLibros();

            AgregarEditarLibros.Show();
        }

        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewBooks.DataSource == null)
            {
                CargarDatos();
            }
        }

        private void Gestion_de_Libros_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            // Cadena de conexión
            string connectionString = "Data Source=ROGSTRIXG15\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True";

            // Consulta SQL
            string query = "SELECT * FROM Libros";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    // Llenar el DataTable
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Asignar al DataGridView
                    dataGridViewBooks.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EliminarLibro EliminarLibro = new EliminarLibro();

            EliminarLibro.Show();
        }
    }
}
