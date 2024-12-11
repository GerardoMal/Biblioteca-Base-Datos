using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca_Base_Datos
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        // Cadena de conexión a la base de datos (ajusta los valores según tu configuración)
        string connectionString = "Data Source=ROGSTRIXG15\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True";

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            if (ValidarUsuario(usuario, contraseña))
            {
                // Si el usuario y la contraseña son correctos, abre otro formulario
                Form GestionUsuarios = new GestionUsuarios();  // Aquí puedes poner el formulario que quieras abrir
                GestionUsuarios.Show();
                this.Hide(); // Opcional: oculta el formulario de login
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private bool ValidarUsuario(string usuario, string contraseña)
        {
            bool esValido = false;

            // Consulta SQL para verificar si existe el usuario y la contraseña
            string query = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @usuario AND Contraseña = @contraseña";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@contraseña", contraseña);

                try
                {
                    connection.Open();
                    int resultado = (int)command.ExecuteScalar();  // Devuelve el número de coincidencias encontradas

                    if (resultado > 0)
                    {
                        esValido = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                }
            }

            return esValido;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

