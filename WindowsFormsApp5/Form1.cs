using classGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {

        private ClassManager classManager;

        private string selectedPath;

        public Form1()
        {
            
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
            this.classManager = new ClassManager();
        }

        /**
         * Generate Button
         * Launch the function which generate file class.php 
         **/
        private void button1_Click(object sender, EventArgs e)
        {
            this.generate();
        }
        /**
         * Generate function
         * generate file in php
         * 
         **/
        public void generate()
        {
            string fileName = this.classManager.getName() + ".class.php";

            string pathString = System.IO.Path.Combine(this.selectedPath, fileName);

            string[] test = { "test", "lol" };

            System.IO.File.WriteAllLines(@pathString, test );

            MessageBox.Show("File generated");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
     
        /**
        * Choose the folder to save the file on click
        * this.selectedPath become the save folder
        **/
        private void button2_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            this.selectedPath = folderBrowserDialog1.SelectedPath;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                this.classManager.setName(this.textBox2.Text);
            }
        }
    }
}
