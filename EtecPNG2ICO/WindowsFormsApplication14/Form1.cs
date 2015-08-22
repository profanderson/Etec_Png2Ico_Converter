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

/*
    By Anderson Luiz de Oliveira [anderson.oliveira178@etec.sp.gov.br]
    using opensource png2ico.exe by Matthias Benkmann - http://www.winterdrache.de/
    Visit my blog: http://www.informaticaatibaia.com
    Visit my site School: http://www.etecarmine.com.br

    License: http://www.gnu.org/licenses/gpl-3.0.en.html
    Git: https://github.com/profanderson/Etec_Png2Ico_Converter
*/

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
            converter.FileName = "png2ico.exe"; //look: http://www.winterdrache.de/freeware/png2ico/index.html 
            converter.Arguments = " " + ico + " " + png;            
            converter.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(converter);

            
            // Waiting converter... 
            ProcessStartInfo Wait = new ProcessStartInfo();
            Wait.FileName = "cmd.exe";
            Wait.Arguments = "/c timeout 2";
            Wait.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(Wait);
            

            // Create dir output
            ProcessStartInfo CreatePasteOutput = new ProcessStartInfo();
            CreatePasteOutput.FileName = "cmd.exe";
            CreatePasteOutput.Arguments = "/c mkdir output";
            CreatePasteOutput.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(CreatePasteOutput);

            // Move file to 
            ProcessStartInfo MoveIco = new ProcessStartInfo();
            MoveIco.FileName = "cmd.exe";
            MoveIco.Arguments = "/c move *.ico output";
            MoveIco.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(MoveIco);
            
            // Open Explorer
            ProcessStartInfo OpenExplorer = new ProcessStartInfo();
            OpenExplorer.FileName = "explorer.exe";
            OpenExplorer.Arguments = "output";            
            Process.Start(OpenExplorer);

            //MessageBox.Show("Done!");
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frmAbout = new Form2();
            frmAbout.Show();
        }

        private void likeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://informaticaatibaia.com/LikeInFacebook.html");
        }
    }
}
