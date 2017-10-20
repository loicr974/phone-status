using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public partial class Client : IJsonable, IClient
    {
        public dynamic ToJson()
        {
            return new
            {
                this.Id,
                this.Nom,
                this.Prenom,
                this.Mail,
                this.Cp
            };
        }
    }
}
