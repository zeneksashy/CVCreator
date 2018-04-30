namespace CVCreator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.zawod1 = new CVCreator.Zawod();
            this.zainteresowania1 = new CVCreator.zainteresowania();
            this.wykształcenie1 = new CVCreator.Wykształcenie();
            this.umiejetnosci1 = new CVCreator.umiejetnosci();
            this.szkolenia1 = new CVCreator.szkolenia();
            this.dane1 = new CVCreator.dane();
            this.jezyki1 = new CVCreator.jezyki();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(129, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dodaj zdjęcie";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.button1.Location = new System.Drawing.Point(12, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Dodaj zdjęcie";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Dane Osobowe",
            "Doświadczenie zawodowe",
            "Wykształcenie",
            "Języki",
            "Zainteresowania",
            "Szkolenia/Certyfikaty",
            "Umiejętności",
            "Klauzula"});
            this.comboBox1.Location = new System.Drawing.Point(12, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(155, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "Dodaj do CV";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 111);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 28);
            this.button2.TabIndex = 9;
            this.button2.Text = "Generuj PDF";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // zawod1
            // 
            this.zawod1.Location = new System.Drawing.Point(343, 21);
            this.zawod1.Name = "zawod1";
            this.zawod1.Size = new System.Drawing.Size(319, 229);
            this.zawod1.TabIndex = 8;
            this.zawod1.Visible = false;
            // 
            // zainteresowania1
            // 
            this.zainteresowania1.Location = new System.Drawing.Point(343, 21);
            this.zainteresowania1.Name = "zainteresowania1";
            this.zainteresowania1.Size = new System.Drawing.Size(270, 150);
            this.zainteresowania1.TabIndex = 7;
            this.zainteresowania1.Visible = false;
            // 
            // wykształcenie1
            // 
            this.wykształcenie1.Location = new System.Drawing.Point(333, 21);
            this.wykształcenie1.Name = "wykształcenie1";
            this.wykształcenie1.Size = new System.Drawing.Size(319, 229);
            this.wykształcenie1.TabIndex = 6;
            this.wykształcenie1.Visible = false;
            // 
            // umiejetnosci1
            // 
            this.umiejetnosci1.Location = new System.Drawing.Point(333, 21);
            this.umiejetnosci1.Name = "umiejetnosci1";
            this.umiejetnosci1.Size = new System.Drawing.Size(291, 196);
            this.umiejetnosci1.TabIndex = 5;
            this.umiejetnosci1.Visible = false;
            // 
            // szkolenia1
            // 
            this.szkolenia1.Location = new System.Drawing.Point(333, 21);
            this.szkolenia1.Name = "szkolenia1";
            this.szkolenia1.Size = new System.Drawing.Size(280, 150);
            this.szkolenia1.TabIndex = 4;
            this.szkolenia1.Visible = false;
            // 
            // dane1
            // 
            this.dane1.Location = new System.Drawing.Point(333, 21);
            this.dane1.Name = "dane1";
            this.dane1.Size = new System.Drawing.Size(403, 398);
            this.dane1.TabIndex = 3;
            // 
            // jezyki1
            // 
            this.jezyki1.Location = new System.Drawing.Point(343, 31);
            this.jezyki1.Name = "jezyki1";
            this.jezyki1.Size = new System.Drawing.Size(338, 201);
            this.jezyki1.TabIndex = 10;
            this.jezyki1.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 342);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(373, 96);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(22, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Klauzula:";
            this.label2.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(391, 403);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 35);
            this.button3.TabIndex = 13;
            this.button3.Text = "Dodaj klauzule";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.jezyki1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.zawod1);
            this.Controls.Add(this.zainteresowania1);
            this.Controls.Add(this.wykształcenie1);
            this.Controls.Add(this.umiejetnosci1);
            this.Controls.Add(this.szkolenia1);
            this.Controls.Add(this.dane1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private dane dane1;
        private szkolenia szkolenia1;
        private umiejetnosci umiejetnosci1;
        private Wykształcenie wykształcenie1;
        private zainteresowania zainteresowania1;
        private Zawod zawod1;
        private System.Windows.Forms.Button button2;
        private jezyki jezyki1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
    }
}

