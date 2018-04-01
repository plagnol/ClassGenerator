using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classGenerator
{
    class AttributManager:Attribut
    {
        private string nameInDb;

        private Boolean isPrimary;


        public AttributManager(string nameSend, string typeSend, string nameInDbSend, Boolean primary) : base(nameSend, typeSend)
        {
            this.nameInDb = nameInDbSend;

            this.isPrimary = primary;
        }

        public string getNameInDb()
        {
            return this.nameInDb;
        }

        public Boolean getIsPrimary()
        {
            return this.isPrimary;
        }

        public void setNameInDb(string name)
        {
            this.nameInDb = name;
        }

        public void setPrimaryKey(Boolean primary)
        {
            this.isPrimary = primary;
        }
    }
}
