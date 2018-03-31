using System;
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

        private string[] lines;

        private string name;
        /**
         *Constructor of the class; 
         **/
        public ClassManager()
        {
            this.attributs = new List<Attribut>();
        }

        /**
         * Get the list of attributs of the class
         * return 
         * List<Attribut> 
         **/
        public List<Attribut> getListAttributs()
        {
            return this.attributs;
        }

        /**
         * Get the name of the class
         * return
         * string @nameSend 
         **/
        public string getName()
        {
            return this.name;
        }

        /**
         * Set the name of the class
         * param 
         * string @nameSend 
         **/
        public void setName(string nameSend)
        {
            this.name = nameSend;
        }

        
    }
}
