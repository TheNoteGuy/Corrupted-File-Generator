using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CFG_UI
{
    public partial class Form1 : Form
    {
        public static string[] uniReadArray;
        public static string uniRead;
        public static string[] path;
        public static string pathtest;
        public Form1()
        {
            InitializeComponent();
            uniReader();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        static void uniReader()
        {
            path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Split(':');
            //Console.WriteLine(path[1].Trim('\u005C') + ":" + path[2] + @"\utf8_sequence.txt");
            //Console.ReadLine();

            using (StreamReader sr = new StreamReader(path[1].Trim('\u005C') + ":" + path[2] + @"\utf8_sequence.txt"))
            {
                //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                uniRead = sr.ReadToEnd().ToString();
                uniReadArray = uniRead.Split();
                Console.WriteLine("Uni Loaded");
                
                //Console.ReadLine();
                //filemaker();
            }
        }
        static void filemaker(decimal fs, string fn, string ff, string ol)
        {
            Random rnd = new Random();
            Console.WriteLine(@"Insert Filesize in MB (use a , when using non round numbers) :");
            decimal fileSizeInt = fs;
            Console.WriteLine("Insert Filename (Filename.FileFormat) :");
            string fileName = fn + "." + ff;
            Console.WriteLine("Insert output location : ");
            string outputLocation = ol;
            Math.Round(fileSizeInt);

            using (StreamWriter sw = new StreamWriter(outputLocation + (@"\") + fileName))
            {
                for (int i = 0; i <= (fileSizeInt * 333333); i++)
                {
                    sw.Write(uniReadArray[Convert.ToInt32(rnd.Next(uniReadArray.Length - 1))]);
                }
                Console.WriteLine("Done!");
                Console.ReadLine();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void label7_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog file = new FolderBrowserDialog())
            {

                if (file.ShowDialog() == DialogResult.OK)
                {
                    pathtest = file.SelectedPath;
                    richTextBox3.Text = pathtest;
                }
            }
        }


        private void label9_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && richTextBox3.Text != "" && richTextBox4.Text != "")
            { 
                filemaker(Convert.ToDecimal(richTextBox4.Text), richTextBox1.Text, richTextBox6.Text, richTextBox3.Text);    
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
