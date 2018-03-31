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

        
    }
}
