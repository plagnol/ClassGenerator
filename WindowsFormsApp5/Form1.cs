﻿using classGenerator;
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
            this.classManager = new ClassManager();
        }

        /**
         * Generate Button
         * Launch the function which generate file class.php 
         **/
        private void button1_Click(object sender, EventArgs e)
        {

        }
        /**
         * Generate function
         * generate file in php
         * 
         **/
        public void generate()
        {
            string fileName = "test.php";

            string pathString = System.IO.Path.Combine(this.selectedPath, fileName);

            
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
    }
}
