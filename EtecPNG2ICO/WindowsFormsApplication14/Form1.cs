using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace WindowsFormsApplication14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { textBox1.Text = openFileDialog1.FileName; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String png = "\"" + textBox1.Text + "\"";
            String ico = "\"" + System.IO.Path.GetFileNameWithoutExtension(textBox1.Text) + ".ico\"";

            ProcessStartInfo converter = new ProcessStartInfo();
            converter.FileName = "data/png2ico.exe";
            converter.Arguments = ico + " " + png;
            Process.Start(converter);
            MessageBox.Show("Feito!");
        }
    }
}
