using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca_Base_Datos
{
    public partial class Prestamos : Form
    {
        public Prestamos()
        {
            InitializeComponent();
            LoadPrestamos();
            LoadDevoluciones();
        }
        public SqlConnection connection = new SqlConnection("Data Source=ROGSTRIXG15\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True");

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        private void LoadPrestamos()
        {
            OpenConnection();
            string query = "SELECT * FROM Prestamos";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridViewPrestamos.DataSource = dataTable;
            CloseConnection();
        }

        private void LoadDevoluciones()
        {
            OpenConnection();
            string query = "SELECT * FROM Devoluciones";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridViewDevoluciones.DataSource = dataTable;
            CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idLibro = Convert.ToInt32(txtIdLibro.Text); // ID del libro
            DateTime fechaSalida = dateTimePickerSalida.Value; // Fecha de salida
            DateTime fechaEntrega = dateTimePickerEntrega.Value; // Fecha de entrega
            string estatus = "Pendiente de entrega"; // Estatus por defecto

            try
            {
                OpenConnection();

                // Verificar el número de copias disponibles
                string checkQuery = "SELECT Numero_Copias_Disponibles FROM Libros WHERE ID_Libro = @ID_Libro";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@ID_Libro", idLibro);

                int copiasDisponibles = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (copiasDisponibles > 0)
                {
                    // Insertar el préstamo
                    string insertQuery = "INSERT INTO Prestamos (ID_Libro, Fecha_de_Salida, Fecha_de_Entrega, Estatus) " +
                                         "VALUES (@ID_Libro, @Fecha_Salida, @Fecha_Entrega, @Estatus)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@ID_Libro", idLibro);
                    insertCommand.Parameters.AddWithValue("@Fecha_Salida", fechaSalida);
                    insertCommand.Parameters.AddWithValue("@Fecha_Entrega", fechaEntrega);
                    insertCommand.Parameters.AddWithValue("@Estatus", estatus);

                    insertCommand.ExecuteNonQuery();

                    // Reducir el número de copias disponibles en 1
                    string updateQuery = "UPDATE Libros SET Numero_Copias_Disponibles = Numero_Copias_Disponibles - 1 WHERE ID_Libro = @ID_Libro";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@ID_Libro", idLibro);

                    updateCommand.ExecuteNonQuery();

                    MessageBox.Show("Préstamo registrado con éxito.");
                }
                else
                {
                    MessageBox.Show("No hay copias disponibles para este libro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }

            // Actualizar la vista de préstamos
            LoadPrestamos();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idPrestado = Convert.ToInt32(txtIdPrestado.Text); // ID del préstamo
            DateTime fechaDevolucion = dateTimePickerDevolucion.Value;

            try
            {
                OpenConnection();

                // Insertar registro de devolución
                string insertQuery = "INSERT INTO Devoluciones (ID_Prestado, Fecha_Devolucion) VALUES (@ID_Prestado, @Fecha_Devolucion)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@ID_Prestado", idPrestado);
                insertCommand.Parameters.AddWithValue("@Fecha_Devolucion", fechaDevolucion);

                insertCommand.ExecuteNonQuery();

                // Actualizar el estatus del préstamo a 'Entregado'
                string updatePrestamoQuery = "UPDATE Prestamos SET Estatus = 'Entregado' WHERE ID_Prestado = @ID_Prestado AND Estatus = 'Pendiente de entrega'";
                SqlCommand updatePrestamoCommand = new SqlCommand(updatePrestamoQuery, connection);
                updatePrestamoCommand.Parameters.AddWithValue("@ID_Prestado", idPrestado);

                updatePrestamoCommand.ExecuteNonQuery();

                // Incrementar el número de copias disponibles del libro asociado al préstamo
                string getLibroQuery = "SELECT ID_Libro FROM Prestamos WHERE ID_Prestado = @ID_Prestado";
                SqlCommand getLibroCommand = new SqlCommand(getLibroQuery, connection);
                getLibroCommand.Parameters.AddWithValue("@ID_Prestado", idPrestado);

                int idLibro = Convert.ToInt32(getLibroCommand.ExecuteScalar());

                string updateCopiasQuery = "UPDATE Libros SET Numero_Copias_Disponibles = Numero_Copias_Disponibles + 1 WHERE ID_Libro = @ID_Libro";
                SqlCommand updateCopiasCommand = new SqlCommand(updateCopiasQuery, connection);
                updateCopiasCommand.Parameters.AddWithValue("@ID_Libro", idLibro);

                updateCopiasCommand.ExecuteNonQuery();

                MessageBox.Show("Devolución registrada con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }

            // Actualizar la vista de devoluciones
            LoadDevoluciones();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
