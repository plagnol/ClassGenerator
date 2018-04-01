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

        private List<AttributManager> attributsDb;


        private string name;

        private string nameUpdater;
        /**
         *Constructor of the class; 
         */
        public ClassManager()
        {
            this.attributs = new List<Attribut>();
            this.attributsDb = new List<AttributManager>();
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
         * Get the list of attributs of the class
         * return 
         * List<Attribut> 
         */
        public List<AttributManager> getListAttributsDb()
        {
            return this.attributsDb;
        }

        /**
         * Get the name of the class
         * return
         * string @name 
         */
        public string getName()
        {
            return this.name;
        }


        /**
         * Get the name of the classUpdater
         * return
         * string @nameUpdater 
         */
        public string getNameUpdater()
        {
            return this.nameUpdater;
        }

        /**
         * Set the name of the class
         * param 
         * string @nameSend 
         */
        public void setName(string nameSend)
        {
            this.name = nameSend;
            this.setNameUpdater(nameSend);
        }

        /**
        * Set the name of the classUpdater
        * param 
        * string @nameSend 
        */
        private void setNameUpdater(string nameSend)
        {
            this.nameUpdater = nameSend + "Updater";
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
         * Set the header in the classUpdater file
         */
        public string[] setHeaderDb()
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
            line[8] = "class " + this.getName() + "Updater";
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


        /**
         * Add attribut to the classUpdater
         * param
         * Attribut @att
         * 
         * return void
         */
        public void addAttributDb(AttributManager att)
        {
            this.attributsDb.Add(att);
        }

        public List<string> getAttribut(Attribut att)
        {
            List<string> line = new List<string>();

            line.Add(" ");
            line.Add( "    private $" + att.getName() + ";" );

            return line;
        }

        public List<string> getAttributManager()
        {
            List<string> line = new List<string>();
            string name = FirstCharToUpper(this.name);
            line.Add(" ");
            line.Add("    //Connection PDO");
            line.Add("    private $db ;");
            line.Add(" ");
            line.Add("    /**");
            line.Add("     * " + name  +"Updater constructor");
            line.Add("     * @param $db : database");
            line.Add("     */");
            line.Add("      public function __construct($db)");
            line.Add("      {");
            line.Add("          $this->setDb($db);");
            line.Add("      }");

            return line;
        }


        public List<string> setGetter(Attribut att)
        {
            List<string> line = new List<string>();
            string name = FirstCharToUpper(att.getName());
            line.Add(" ");
            line.Add("    /**");
            line.Add("    *@return " + att.getType());
            line.Add("    */");
            line.Add("    ");
            line.Add("     public function get" + name + "()");
            line.Add("     {");
            line.Add("          return $this->" + att.getName() +";");
            line.Add("     }");

            return line;
        }


        public List<string> setSetter(Attribut att)
        {
            List<string> line = new List<string>();
            string name = FirstCharToUpper(att.getName());

            line.Add(" ");
            line.Add("     /**");
            line.Add("     *@param " + att.getType() + " $" + att.getName());
            line.Add("     */");
            line.Add("     ");
            line.Add("      public function set" + name + "( $" + att.getName() + " )");
            line.Add("      {");
            line.Add("           $this->" + att.getName() + " = $" + att.getName() + ";");
            line.Add("      }");

            return line;
        }

        public List<string> setSetterManager()
        {
            List<string> line = new List<string>();            

            line.Add(" ");
            line.Add("    /**");
            line.Add("     * set the database");
            line.Add("     * @param PDO $db database");
            line.Add("     */");
            line.Add(" ");
            line.Add("      public function setDb(PDO $bdd)");
            line.Add("      {");
            line.Add("          $this->db = $bdd;");
            line.Add("      }");

            return line;
        }

        public List<string> setFunctionManager(string principalTable, List<AttributManager> attibutMan)
        {
            List<string> line = new List<string>();
            string name = FirstCharToUpper(this.name);

            line.Add(" ");
            line.Add("    /**");
            line.Add("     * Insert into the database");
            line.Add("     */");
            line.Add(" ");
            line.Add("      public function insert" + name + "ToDatabase($" + this.name +")");
            line.Add("      {");
            line.Add("          $insertDb = $this->db->prepare('" + insertSql(principalTable, attibutMan) + "');");
            line.Add("          $insertDb->execute();");
            line.Add("      }");
            line.Add(" ");
            line.Add("    /**");
            line.Add("     * Delete " + name + " from database with an Id");
            line.Add("     */");
            line.Add(" ");
            line.Add("      public function delete" + name + "FromId($id)");
            line.Add("      {");
            line.Add("          $deleteDb = $this->db->prepare('" + deleteSql(principalTable, attibutMan) + ");");
            line.Add("          $deleteDb->execute();");
            line.Add("      }");
            line.Add(" ");
            line.Add("    /**");
            line.Add("     * Select " + name + " from database with an Id");
            line.Add("     */");
            line.Add(" ");
            line.Add("      public function select" + name + "FromId($id)");
            line.Add("      {");
            line.Add("          $selectDb = $this->db->prepare('" + selectSql(principalTable, attibutMan) + ");");
            line.Add("          $selectDb->execute();");
            line.Add("          $check = $selectDb->rowCount();");
            line.Add("          if($check == 1)");
            line.Add("          {");
            line = this.fillDataSelect(principalTable, attibutMan, line);
            line.Add("              return $" + this.name + " ;");
            line.Add("          }");
            line.Add("      }");

            return line;
        }

        private string insertSql(string principalTable, List<AttributManager> attibutMan)
        {
            string request = "INSERT INTO `" + principalTable + "`(";
            AttributManager last = attibutMan.Last();
            foreach (AttributManager result in attibutMan)
            {
                if (!result.getIsPrimary())
                {
                    if (!result.Equals(last))
                    {
                        request += " `" + result.getNameInDb() + "`,";
                }
                    else
                    {
                        request += " `" + result.getNameInDb() + "`)";
                    }
                }
                
            }

            request += " VALUES (";

            foreach (AttributManager result in this.attributsDb)
            {
                if (!result.getIsPrimary())
                {
                    if (!result.Equals(last))
                    {
                        request += " ' . $" + this.name + "->get" + result.getName() + "() . ',";
                    }
                    else
                    {
                        request += " ' . $" + this.name + "->get" + result.getName() + "() . ')";
                    }
                }

            }
            
            return request;
        }

        private string deleteSql(string principalTable, List<AttributManager> attibutMan)
        {
            string request = "DELETE FROM "+ principalTable +" WHERE ";

            foreach (AttributManager result in this.attributsDb)
            {
                if (result.getIsPrimary())
                {
                    request += result.getNameInDb() + " = ' . $id";
                }

            }

            return request;
        }

        private string selectSql(string principalTable, List<AttributManager> attibutMan)
        {
            string request = "SELECT * FROM " + principalTable + " WHERE ";

            foreach (AttributManager result in this.attributsDb)
            {
                if (result.getIsPrimary())
                {
                    request += result.getNameInDb() + " = ' . $id";
                }

            }

            return request;
        }

        private List<string> fillDataSelect(string principalTable, List<AttributManager> attibutMan, List<string> line)
        {
            line.Add("              $" + this.name +" = new " + this.name +"();");
            line.Add("              $info = $selectDb->fetch(PDO::FETCH_ASSOC);");
            foreach (AttributManager result in this.attributsDb)
            {

                 line.Add("              $" + this.name + "->set" + result.getName() + " ( $info['" + result.getNameInDb()  + "'] ); ");
            }

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
