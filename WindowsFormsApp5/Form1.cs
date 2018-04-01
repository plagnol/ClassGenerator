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

        private Boolean folderIsSelected = false;

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

            this.folderIsSelected = false;
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
            this.folderIsSelected = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                this.classManager.setName(this.textBox2.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.folderIsSelected)
            {
                //Generate asset folder
                string pathAssets = System.IO.Path.Combine(this.selectedPath, "assets");
                System.IO.Directory.CreateDirectory(pathAssets);
                //Folder in asset folder
                //Css folder
                string pathAssetsCss = System.IO.Path.Combine(pathAssets, "css");
                System.IO.Directory.CreateDirectory(pathAssetsCss);
                //Font folder
                string pathAssetsFont = System.IO.Path.Combine(pathAssets, "fonts");
                System.IO.Directory.CreateDirectory(pathAssetsFont);
                //Ico folder
                string pathAssetsIco = System.IO.Path.Combine(pathAssets, "ico");
                System.IO.Directory.CreateDirectory(pathAssetsIco);
                //Img folder
                string pathAssetsImg = System.IO.Path.Combine(pathAssets, "img");
                System.IO.Directory.CreateDirectory(pathAssetsImg);
                //Js folder
                string pathAssetsJs = System.IO.Path.Combine(pathAssets, "js");
                System.IO.Directory.CreateDirectory(pathAssetsJs);

                //Generate cache folder
                string pathCache = System.IO.Path.Combine(this.selectedPath, "cache");
                System.IO.Directory.CreateDirectory(pathCache);
                //Folder in cache folder
                //Generate database folder
                string pathDatabase = System.IO.Path.Combine(pathCache, "database");
                System.IO.Directory.CreateDirectory(pathDatabase);

                //Generate ressources folder
                string pathRessource = System.IO.Path.Combine(this.selectedPath, "ressources");
                System.IO.Directory.CreateDirectory(pathRessource);

                //Generate src folder
                string pathSrc = System.IO.Path.Combine(this.selectedPath, "src");
                System.IO.Directory.CreateDirectory(pathSrc);
                //Folder in src folder
                //Generate controler folder
                string pathController = System.IO.Path.Combine(pathSrc, "controler");
                System.IO.Directory.CreateDirectory(pathController);
                //Generate model folder
                string pathModel = System.IO.Path.Combine(pathSrc, "model");
                System.IO.Directory.CreateDirectory(pathModel);
                //Generate views folder
                string pathView = System.IO.Path.Combine(pathSrc, "view");
                System.IO.Directory.CreateDirectory(pathView);

                //Generate vendor folder
                string pathVendor = System.IO.Path.Combine(this.selectedPath, "vendor");
                System.IO.Directory.CreateDirectory(pathVendor);
            }
            else
            {
                MessageBox.Show("You have to choose a folder before generate MVC model");
            }
        }
    }
}
