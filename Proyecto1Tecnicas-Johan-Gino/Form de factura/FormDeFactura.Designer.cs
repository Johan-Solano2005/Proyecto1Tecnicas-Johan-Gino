namespace Proyecto1Tecnicas_Johan_Gino.Form_de_factura
{
    partial class FormDeFactura
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(314, 9);
            label1.Name = "label1";
            label1.Size = new Size(75, 23);
            label1.TabIndex = 0;
            label1.Text = "Factura";
           
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 68);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(537, 511);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 2;
            label3.Text = "Total";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(33, 153);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(652, 323);
            dataGridView1.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(631, 511);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 4;
            label4.Text = "label4";
    
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(116, 68);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 5;
            label5.Text = "label5";
         
            // 
            // button1
            // 
            button1.Location = new Point(33, 511);
            button1.Name = "button1";
            button1.Size = new Size(131, 29);
            button1.TabIndex = 6;
            button1.Text = "Volver al inicio";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(537, 544);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 7;
            label6.Text = "Pago con:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(631, 544);
            label7.Name = "label7";
            label7.Size = new Size(50, 20);
            label7.TabIndex = 8;
            label7.Text = "label7";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(33, 110);
            label8.Name = "label8";
            label8.Size = new Size(50, 20);
            label8.TabIndex = 9;
            label8.Text = "Fecha:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(116, 110);
            label9.Name = "label9";
            label9.Size = new Size(50, 20);
            label9.TabIndex = 10;
            label9.Text = "label9";
           
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(359, 68);
            label10.Name = "label10";
            label10.Size = new Size(55, 20);
            label10.TabIndex = 11;
            label10.Text = "Cajero:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(439, 69);
            label11.Name = "label11";
            label11.Size = new Size(58, 20);
            label11.TabIndex = 12;
            label11.Text = "label11";
            // 
            // FormDeFactura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 590);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormDeFactura";
            Text = "FormDeFactura";
            Load += FormDeFactura_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView1;
        private Label label4;
        private Label label5;
        private Button button1;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
    }
}