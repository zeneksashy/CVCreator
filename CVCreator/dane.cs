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
    public partial class dane : UserControl
    {
        public dane()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var personal = new PersonalData();
            personal.Name = textBox1.Text;
            personal.Surrname = textBox2.Text;
            personal.DateofBirth = textBox3.Text;
            personal.Adress = richTextBox2.Text;
            personal.PhoneNumber = textBox4.Text;
            personal.Email = textBox5.Text;
            personal.Website = textBox6.Text;
            Program.page.AddComponent(personal,0);
           // ClearAll();
            MessageBox.Show("Dodano element");
        }
        private void ClearAll()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            richTextBox2.Text = "";

        }
    }
}