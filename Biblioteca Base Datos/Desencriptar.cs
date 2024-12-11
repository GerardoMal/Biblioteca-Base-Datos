using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Biblioteca_Base_Datos
{
    public partial class Desencriptar : Form
    {
        public Desencriptar()
        {
            InitializeComponent();
        }

        // Define la cadena de conexión a la base de datos
        private string connectionString = "Data Source=ROGSTRIXG15\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True";

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            // Buscar al usuario con ID_Usuario = 1
            string query = "SELECT ID_Usuario, NombreUsuario, Contraseña FROM Usuarios WHERE NombreUsuario = @usuario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", usuario);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int idUsuario = (int)reader["ID_Usuario"];
                    string contraseñaEncriptada = reader["Contraseña"].ToString();

                    // Verificar que solo el usuario con ID_Usuario = 1 pueda acceder
                    if (idUsuario == 1)
                    {
                        string contraseñaDesencriptada = Seguridad.Desencriptar(contraseñaEncriptada);

                        // Validar la contraseña
                        if (contraseña == contraseñaDesencriptada)
                        {
                            MessageBox.Show("Inicio de sesión exitoso.");
                            // Redirigir a otro formulario, por ejemplo:
                            GestionUsuarios GestionUsuarios = new GestionUsuarios();
                            GestionUsuarios.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Contraseña incorrecta.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Acceso denegado: Solo el usuario con ID 1 puede acceder.");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
