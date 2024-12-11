namespace Biblioteca_Base_Datos
{
    partial class Gestion_de_Libros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Titulo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Segoe UI", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Titulo.Location = new System.Drawing.Point(487, 20);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(487, 78);
            this.Titulo.TabIndex = 0;
            this.Titulo.Text = "Gestion de Libros";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(310, 56);
            this.button1.TabIndex = 1;
            this.button1.Text = "Agregar Libro";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(784, 140);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(310, 56);
            this.button3.TabIndex = 3;
            this.button3.Text = "Eliminar Libro";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Location = new System.Drawing.Point(46, 223);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.RowHeadersWidth = 51;
            this.dataGridViewBooks.RowTemplate.Height = 29;
            this.dataGridViewBooks.Size = new System.Drawing.Size(1185, 371);
            this.dataGridViewBooks.TabIndex = 4;
            this.dataGridViewBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBooks_CellContentClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1247, 255);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 324);
            this.button4.TabIndex = 5;
            this.button4.Text = "Actualizar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Gestion_de_Libros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 643);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridViewBooks);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Titulo);
            this.Name = "Gestion_de_Libros";
            this.Text = "Gestion_de_Libros";
            this.Load += new System.EventHandler(this.Gestion_de_Libros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Titulo;
        private Button button1;
        private Button button3;
        private DataGridView dataGridViewBooks;
        private Button button4;
    }
}