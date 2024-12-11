using System;
using System.Data.SqlClient;
using System.Data;

public class DatabaseConnection
{
    private string connectionString = "Data Source=ROGSTRIXG15\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True";

    // Método para obtener la conexión
    public SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    // Método para ejecutar consultas SELECT (consultas que devuelven datos)
    public DataTable ExecuteQuery(string query)
    {
        using (SqlConnection conn = GetConnection())
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
            DataTable dataTable = new DataTable();
            conn.Open();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }
    }

    // Método para ejecutar comandos que no devuelven resultados (INSERT, UPDATE, DELETE)
    public void ExecuteNonQuery(string query)
    {
        using (SqlConnection conn = GetConnection())
        {
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            command.ExecuteNonQuery();
        }
    }
}
