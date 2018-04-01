using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classGenerator
{   
    /**
     * 
     * Attribut of a class
     * 
     */
    class Attribut
    {
        //Name of the attribut
        private string name;

        //Type of the attribut
        private string type;

        /**
         * 
         * Constructor of the class
         * 2 params : 
         * string @nameSend
         * string @typeSend
         * 
         * set the name and the type of the attribut
         * 
         * return void
         */
        public Attribut(string nameSend, string typeSend)
        {
            this.setName(nameSend);
            this.setType(typeSend);
        }
        
        /**
         * Get the name of the attribut
         * return
         * string @this.name
         */
        public string getName()
        {
            return this.name;
        }

        /**
         * Get the type of the attribut
         * return
         * string @this.type
         */
        public string getType()
        {
            return this.type;
        }
        /**
         * Set the name of the attribut
         * param 
         * string @nameSend 
         */
        public void setName(string nameSend)
        {
            this.name = nameSend;
        }

        /**
         * Set the type of the attribut
         * param 
         * string @typeSend 
         */
        public void setType(string typeSend)
        {
            this.type = typeSend;
        }
    }
}
