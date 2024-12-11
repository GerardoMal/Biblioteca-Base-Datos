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
    public partial class EliminarAdmin : Form
    {
        public EliminarAdmin()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=ROGSTRIXG15\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtén el ID del TextBox
                int adminId = int.Parse(txtAdminID.Text);

                // Confirmar eliminación
                DialogResult result = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar este administrador?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    // Establecer conexión y eliminar el registro
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Usuarios WHERE ID_Usuario = @ID_Usuario";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ID_Usuario", adminId);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Administrador eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           
                            }
                            else
                            {
                                MessageBox.Show("No se encontró un administrador con el ID especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un ID válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
