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
    public partial class szkolenia : UserControl
    {
        public szkolenia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var course = new Course();
            course.Name = textBox1.Text;
            Program.courses.AddCourse(course);
            ClearAll();
            MessageBox.Show("Dodano element");
        }
        private void ClearAll()
        {
            textBox1.Text = "";
        }

        private void szkolenia_Load(object sender, EventArgs e)
        {

        }
    }
}
