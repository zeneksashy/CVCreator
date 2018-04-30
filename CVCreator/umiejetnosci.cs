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
    public partial class umiejetnosci : UserControl
    {
        public umiejetnosci()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var skill = new Skill();
            skill.Name = textBox1.Text;
            Program.skills.AddSkill(skill);
            ClearAll();
            MessageBox.Show("Dodano element");
        }
        private void ClearAll()
        {
            textBox1.Text = "";
        }
    }

}
