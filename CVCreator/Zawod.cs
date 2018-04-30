﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVCreator
{
    public partial class Zawod : UserControl
    {
        public Zawod()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var experience = new Experience();
            experience.Name = textBox1.Text;
            experience.Value = textBox2.Text;
            experience.From = textBox3.Text;
            experience.To = textBox4.Text;
            Program.experiences.AddExperience(experience);
            ClearAll();
            MessageBox.Show("Dodano element");
        }
        private void ClearAll()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
