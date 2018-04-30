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
    public partial class zainteresowania : UserControl
    {
        public zainteresowania()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var interesting = new Interesting();
            interesting.Name = textBox1.Text;
            Program.interestings.AddInterest(interesting);
            ClearAll();
            MessageBox.Show("Dodano element");
        }
        private void ClearAll()
        {
            textBox1.Text = "";
        }
    }
}
