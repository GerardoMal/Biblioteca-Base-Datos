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
    public partial class BusquedaLibros : Form
    {
        public BusquedaLibros()
        {
            InitializeComponent();
            CargarLibros();
            ConfigurarFiltros();
        }



        private string connectionString = "Data Source=ROGSTRIXG15\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True";
        private DataTable librosTable;
        private void BusquedaLibros_Load(object sender, EventArgs e)
        {

        }

        private void CargarLibros()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Libros";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                librosTable = new DataTable();
                adapter.Fill(librosTable);
                dgvLibros.DataSource = librosTable;
            }
        }

        private void ConfigurarFiltros()
        {
            // Llenar el ComboBox con géneros únicos
            var generos = librosTable.AsEnumerable()
                                     .Select(row => row["Genero"].ToString())  // Usar "Genero" en lugar de "Categoria"
                                     .Distinct()
                                     .ToList();
            cbCategoria.Items.Add("Todos");
            cbCategoria.Items.AddRange(generos.ToArray());  // Aquí también se usa "generos"
            cbCategoria.SelectedIndex = 0;
        }


        private void AplicarFiltros()
        {
            string filtro = "1=1"; // Condición siempre verdadera para combinar filtros

            // Filtro por título
            if (!string.IsNullOrWhiteSpace(txtTitulo.Text))
                filtro += $" AND Titulo LIKE '%{txtTitulo.Text}%'";

            // Filtro por género
            if (cbCategoria.SelectedIndex > 0) // Ignora "Todos"
                filtro += $" AND Genero = '{cbCategoria.SelectedItem}'";

            // Filtro por año de publicación
            if (nudAno.Value > 0)
                filtro += $" AND Ano_Publicacion = {nudAno.Value}";

            // Filtro por autor
            if (!string.IsNullOrWhiteSpace(txtAutor.Text)) // Si el campo autor no está vacío
                filtro += $" AND Autor LIKE '%{txtAutor.Text}%'";  // Filtrar por autor

            // Aplicar el filtro al DataView
            DataView vistaFiltrada = new DataView(librosTable)
            {
                RowFilter = filtro
            };

            // Asignar la vista filtrada al DataGridView
            dgvLibros.DataSource = vistaFiltrada;

        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            txtTitulo.Clear();
            cbCategoria.SelectedIndex = 0;
            nudAno.Value = 0;
            dgvLibros.DataSource = librosTable;
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void btnRestablecer_Click_1(object sender, EventArgs e)
        {
            txtTitulo.Clear();
            cbCategoria.SelectedIndex = 0;
            nudAno.Value = 0;
            dgvLibros.DataSource = librosTable;
        }
    }
}

