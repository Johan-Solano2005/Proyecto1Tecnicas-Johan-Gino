namespace Proyecto1Tecnicas_Johan_Gino
{
    partial class FormsDeProductos
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button5 = new Button();
            TablaProductos = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxEditar = new TextBox();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)TablaProductos).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(115, 123);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(326, 186);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "Editar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(326, 123);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 2;
            button3.Text = "Eliminar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(26, 441);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 3;
            button4.Text = "Volver";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(115, 185);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(115, 243);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(115, 320);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 6;
            // 
            // button5
            // 
            button5.Location = new Point(547, 123);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 7;
            button5.Text = "mostrar";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // TablaProductos
            // 
            TablaProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TablaProductos.Location = new Point(547, 166);
            TablaProductos.Name = "TablaProductos";
            TablaProductos.RowHeadersWidth = 51;
            TablaProductos.Size = new Size(425, 304);
            TablaProductos.TabIndex = 8;
            TablaProductos.CellFormatting += TablaProductos_CellFormatting;
            TablaProductos.SelectionChanged += TablaProductos_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 185);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 9;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 246);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 10;
            label2.Text = "Precio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 320);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 11;
            label3.Text = "Cantidad";
            // 
            // textBoxEditar
            // 
            textBoxEditar.Location = new Point(326, 299);
            textBoxEditar.Name = "textBoxEditar";
            textBoxEditar.Size = new Size(125, 27);
            textBoxEditar.TabIndex = 12;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(326, 242);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 13;
            // 
            // FormsDeProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1128, 513);
            Controls.Add(comboBox1);
            Controls.Add(textBoxEditar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TablaProductos);
            Controls.Add(button5);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "FormsDeProductos";
            Text = "FormsDeProductos";
            Load += FormsDeProductos_Load;
            ((System.ComponentModel.ISupportInitialize)TablaProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button5;
        private DataGridView TablaProductos;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxEditar;
        private ComboBox comboBox1;
    }
}