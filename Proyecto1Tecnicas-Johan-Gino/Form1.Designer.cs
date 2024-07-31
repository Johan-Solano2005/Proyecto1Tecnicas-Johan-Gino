namespace Proyecto1Tecnicas_Johan_Gino
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label4 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            button5 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 197);
            button1.Name = "button1";
            button1.Size = new Size(189, 111);
            button1.TabIndex = 0;
            button1.Text = "Gestión de inventarios";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(239, 197);
            button2.Name = "button2";
            button2.Size = new Size(189, 111);
            button2.TabIndex = 1;
            button2.Text = "Generar ventas";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(462, 197);
            button3.Name = "button3";
            button3.Size = new Size(189, 111);
            button3.TabIndex = 2;
            button3.Text = "Gestión de clientes";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(690, 197);
            button4.Name = "button4";
            button4.Size = new Size(189, 111);
            button4.TabIndex = 3;
            button4.Text = "Reportes y Análisis";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(302, 9);
            label4.Name = "label4";
            label4.Size = new Size(165, 20);
            label4.TabIndex = 15;
            label4.Text = "Ferretería los 3 tornillos";
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(867, 137);
            panel1.TabIndex = 17;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 13);
            label1.Name = "label1";
            label1.Size = new Size(1632, 20);
            label1.TabIndex = 0;
            label1.Text = resources.GetString("label1.Text");
            label1.Click += label1_Click_1;
            // 
            // button5
            // 
            button5.Location = new Point(14, 409);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 18;
            button5.Text = "Salir";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 450);
            Controls.Add(button5);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label4;
        private Panel panel1;
        private Label label1;
        private Button button5;
    }
}
