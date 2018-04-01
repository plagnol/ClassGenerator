﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classGenerator
{
    class ClassManager
    {
        //List of attribut of the class
        private List<Attribut> attributs;
        

        private string name;
        /**
         *Constructor of the class; 
         */
        public ClassManager()
        {
            this.attributs = new List<Attribut>();
        }

        /**
         * Get the list of attributs of the class
         * return 
         * List<Attribut> 
         */
        public List<Attribut> getListAttributs()
        {
            return this.attributs;
        }

        /**
         * Get the name of the class
         * return
         * string @nameSend 
         */
        public string getName()
        {
            return this.name;
        }

        /**
         * Set the name of the class
         * param 
         * string @nameSend 
         */
        public void setName(string nameSend)
        {
            this.name = nameSend;
        }

        /**
         * Set the header in the class file
         */
        public string[] setHeader()
        {
            DateTime thisDay = DateTime.Today;

            string[] line = new string[10];

            line[0] = "<?php";
            line[1] = "/**";
            line[2] = "  * Generated by ClassGenerator";
            line[3] = "  * Antoine Plagnol";
            line[4] = "  * More info : https://github.com/plagnol";
            line[5] = "  * Date : " + thisDay.ToString();
            line[6] = "  */";
            line[7] = " ";
            line[8] = "class " + this.getName();
            line[9] = "{";


            return line;
        }

        /**
         * Add attribut to the class
         * param
         * Attribut @att
         * 
         * return void
         */
        public void addAttribut(Attribut att)
        {
            this.attributs.Add(att);
        }


        public List<string> getAttribut(Attribut att)
        {
            List<string> line = new List<string>();

            line.Add(" ");
            line.Add( "    private " + att.getName() + " ;" );

            return line;
        }

        public List<string> setGetter(Attribut att)
        {
            List<string> line = new List<string>();
            string name = FirstCharToUpper(att.getName());
            line.Add(" ");
            line.Add("/**");
            line.Add("  *@return " + att.getType());
            line.Add("  */");
            line.Add("  *");
            line.Add("public function get" + name + "()");
            line.Add("{");
            line.Add("    return $this->" + att.getName() +";");
            line.Add("}");

            return line;
        }

        /**
         * Put the first carac of a string to upper
         * param
         * string @input
         * 
         * return 
         * string
         */
        private static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
