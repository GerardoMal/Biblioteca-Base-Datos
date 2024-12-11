using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca_Base_Datos
{
    public partial class AgregarEditarLibros : Form
    {
        public AgregarEditarLibros()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            string publisher = txtPublisher.Text;
            string isbn = txtISBN.Text;
            int year = int.Parse(txtYear.Text);
            string genre = cmbGenre.SelectedItem?.ToString(); // Obtener género seleccionado
            int availableCopies = int.Parse(txtAvailableCompies.Text);

            if (string.IsNullOrEmpty(genre))
            {
                MessageBox.Show("Por favor, selecciona un género.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = $"INSERT INTO Libros (Titulo, Autor, Editorial, Codigo_ISBN, Ano_Publicacion, Genero, Numero_Copias_Disponibles) " +
                           $"VALUES ('{title}', '{author}', '{publisher}', '{isbn}', {year}, '{genre}', {availableCopies})";

            try
            {
                new DatabaseConnection().ExecuteNonQuery(query);

                // Mostrar mensaje de éxito
                MessageBox.Show("El libro se registró con éxito.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos después del registro
                txtTitle.Clear();
                txtAuthor.Clear();
                txtPublisher.Clear();
                txtISBN.Clear();
                txtYear.Clear();
                cmbGenre.SelectedIndex = -1; // Restablecer selección
                txtAvailableCompies.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al agregar el libro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarEditarLibros_Load(object sender, EventArgs e)
        {
            // Lista de géneros literarios
            List<string> genres = new List<string>
    {
        "Novela", "Realismo mágico", "Distopía", "Romance", "Ficción",
        "Épica", "Fantasía", "Fábula", "Thriller", "Horror",
        "Ficción histórica", "Drama", "Misterio", "Tragedia", "Filosófico",
        "Psicológico", "Satírico", "Ciencia ficción", "Aventura", "Filosofía",
        "Romántico", "Memorias", "Comedia", "Indistinto", "Biografía",
        "Autobiografía", "Ensayo", "Poesía", "Teatro", "Crónica",
        "Reportaje", "Fantasía oscura", "Gótico", "Paranormal",
        "Ciencia-ficción dura", "Ciencia-ficción blanda", "Space opera",
        "Steampunk", "Cyberpunk", "Utopía", "Viajes", "Infantil",
        "Juvenil", "Épica mitológica", "Policíaco", "Noir", "New Weird",
        "Western", "Slice of life", "Erótico"
    };

            // Agregar géneros al ComboBox
            cmbGenre.Items.AddRange(genres.ToArray());
        }
    }
}
