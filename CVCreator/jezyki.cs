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
    public partial class jezyki : UserControl
    {
        public jezyki()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var language = new Language();
            language.Name = textBox1.Text;
            language.Level = textBox2.Text;
            Program.languages.AddLanguage(language);
            ClearAll();
            MessageBox.Show("Dodano element");
        }
        private void ClearAll()
        {
            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void jezyki_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if(e.KeyChar==(char)13)
            //button1.PerformClick();
        }
    }
}
