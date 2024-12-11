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
    public partial class EditarAdmin : Form
    {
        public EditarAdmin()
        {
            InitializeComponent();
        }
        // Cadena de conexión a la base de datos
            string connectionString = "Data Source=ROGSTRIXG15\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True";
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtén los valores de los TextBoxes
                int usuarioId = int.Parse(txtAdminID.Text); // ID del usuario a editar
                string nuevoNombreUsuario = txtNuevoUsuario.Text; // Nuevo nombre de usuario
                string nuevaContrasena = txtNuevaContrasena.Text; // Nueva contraseña

                // Validación básica
                if (string.IsNullOrWhiteSpace(nuevoNombreUsuario) || string.IsNullOrWhiteSpace(nuevaContrasena))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Establecer conexión y actualizar los datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Usuarios SET NombreUsuario = @NombreUsuario, Contraseña = @Contraseña WHERE ID_Usuario = @ID_Usuario";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Asignar valores a los parámetros
                        command.Parameters.AddWithValue("@ID_Usuario", usuarioId);
                        command.Parameters.AddWithValue("@NombreUsuario", nuevoNombreUsuario);
                        command.Parameters.AddWithValue("@Contraseña", nuevaContrasena);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Usuario actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el usuario con el ID especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El ID debe ser un número válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
