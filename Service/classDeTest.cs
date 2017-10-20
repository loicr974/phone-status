using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class classDeTest: Iclassdetest
    {
        public int Id { get; set; }

        private string desc()
        {
            return "";
        }

        public string getDescription()
        {
            return desc();
        }
    }
}
