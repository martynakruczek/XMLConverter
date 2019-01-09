using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                textBox1.Text = file;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConvertService service = new ConvertService();
            string file = textBox1.Text;
            try
            {
                service.ConvertXML(file);
                MessageBox.Show("File succesfully converted!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog2.FileName;
                textBox2.Text = file;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConvertService service = new ConvertService();
            string file = textBox2.Text;
            try
            {
                service.ConvertPolishXML(file);
                MessageBox.Show("File succesfully converted!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
