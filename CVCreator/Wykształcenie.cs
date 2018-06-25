using System;
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
    public partial class Wykształcenie : UserControl
    {
        public Wykształcenie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var school = new School();
            school.Name = textBox1.Text;
            school.Value = textBox2.Text;
            school.From = maskedTextBox1.Text;
            school.To = maskedTextBox2.Text;
            Program.schooling.AddSchool(school);
            ClearAll();
            MessageBox.Show("Dodano element");
        }
        private void ClearAll()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
        }
    }
}
