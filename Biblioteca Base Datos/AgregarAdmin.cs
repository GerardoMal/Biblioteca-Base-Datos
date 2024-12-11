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
    public partial class AgregarAdmin : Form
    {
        public AgregarAdmin()
        {
            InitializeComponent();
        }

        // Cadena de conexión a la base de datos (ajusta según tu configuración)
        string connectionString = "Data Source=ROGSTRIXG15\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True";

        private void AgregarAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtiene los valores de los TextBox
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor ingrese ambos campos: Usuario y Contraseña.");
                return;
            }

            // Insertar el nuevo usuario en la base de datos
            if (RegistrarUsuario(usuario, contraseña))
            {
                MessageBox.Show("Usuario registrado con éxito.");
                // Aquí puedes redirigir a otro formulario si es necesario
                this.Close();  // Cierra el formulario actual
            }
            else
            {
                MessageBox.Show("Hubo un error al registrar el usuario.");
            }
        }

        private bool RegistrarUsuario(string usuario, string contraseña)
        {
            bool exito = false;

            // Consulta SQL para insertar un nuevo usuario
            string query = "INSERT INTO Usuarios (NombreUsuario, Contraseña) VALUES (@usuario, @contraseña)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@contraseña", contraseña);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();  // Ejecuta la consulta de inserción

                    if (rowsAffected > 0)
                    {
                        exito = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                }
            }

            return exito;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
