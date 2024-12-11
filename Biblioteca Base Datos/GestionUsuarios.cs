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
using static System.Collections.Specialized.BitVector32;

namespace Biblioteca_Base_Datos
{
    public partial class GestionUsuarios : Form
    {
        public GestionUsuarios()
        {
            InitializeComponent();
        }
 


        private void button4_Click(object sender, EventArgs e)
        {
            Gestion_de_Libros Gestion_de_Libros = new Gestion_de_Libros();

            Gestion_de_Libros.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarAdmin AgregarAdmin = new AgregarAdmin();

            AgregarAdmin.Show();
        }

        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                MostrarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MostrarUsuarios()
        {
            // Cadena de conexión a la base de datos
            string connectionString = "Data Source=ROGSTRIXG15\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True";

            // Consulta SQL para obtener los usuarios
            string query = "SELECT ID_Usuario, NombreUsuario, Contraseña FROM Usuarios";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Crear el adaptador de datos con la consulta
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Llenar el DataTable con los datos
                    dataAdapter.Fill(dataTable);

                    // Ocultar contraseñas con "****"
                    foreach (DataRow row in dataTable.Rows)
                    {
                        row["Contraseña"] = new string('*', row["Contraseña"].ToString().Length);
                    }

                    // Asignar el DataTable al DataGridView
                    dataGridViewUsuarios.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los usuarios: {ex.Message}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditarAdmin EditarAdmin = new EditarAdmin();

            EditarAdmin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EliminarAdmin EliminarAdmin = new EliminarAdmin();

            EliminarAdmin.Show();
        }
    }
}


