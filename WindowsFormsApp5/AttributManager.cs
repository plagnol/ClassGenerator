using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classGenerator
{
    class AttributManager
    {
        private List<Attribut> attributs;

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
         * param 
         * List<Attribut> 
         */
        public void setListAttributs(List<Attribut> att)
        {
            this.attributs = att;
        }


    }
}
