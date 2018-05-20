using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string photopath= @"C:\Users\Zenek\Desktop\kszczicny welona\DSC_0498";

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory= Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                photopath = openFileDialog1.FileName;
            }
        }
//        Doświadczenie zawodowe
//Wykształcenie
//Umiejętności
//Zainteresowania
//Szkolenia/Certyfikaty
//Dane Osobowe
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Wykształcenie":
                    {
                        ClearAll();
                        wykształcenie1.Visible = true;
                    }
                    break;
                case "Umiejętności":
                    {
                        ClearAll();
                        umiejetnosci1.Visible = true;
                    }
                    break;
                case "Zainteresowania":
                    {
                        ClearAll();
                        zainteresowania1.Visible = true;
                    }
                    break;
                case "Szkolenia/Certyfikaty":
                    {
                        ClearAll();
                        szkolenia1.Visible = true;
                    }
                    break;
                case "Dane Osobowe":
                    {
                        ClearAll();
                        dane1.Visible = true;
                    }
                    break;
                case "Doświadczenie zawodowe":
                    {
                        ClearAll();
                        zawod1.Visible = true;
                    }
                    break;
                case "Języki":
                    {
                        ClearAll();
                        jezyki1.Visible = true;
                    }
                    break;
                case "Klauzula":
                    {
                        ClearAll();
                        label2.Visible = true;
                        richTextBox1.Visible = true;
                        button3.Visible = true;
                    }
                    break;

                    // default:
                    //   break;
            }
        }
        private void ClearAll()
        {
            dane1.Visible = false;
            zawod1.Visible = false;
            szkolenia1.Visible = false;
            zainteresowania1.Visible = false;
            umiejetnosci1.Visible = false;
            wykształcenie1.Visible = false;
            jezyki1.Visible = false;
            label2.Visible = false;
            richTextBox1.Visible = false;
            button3.Visible = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.AddToPage();
            //Program.page.Save();
            Program.page.Print();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.klauzula.Value = richTextBox1.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.page.Open("cv.xml");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "xml file(*.xml)|*.xml";
            var result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
            }
            Program.AddToPage();
            Program.page.Save(path);

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }
            Program.page.Open(path);
        }
    }
}
