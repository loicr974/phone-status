using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public partial class Fiche : IJsonable, IFiche
    {
        public dynamic ToJson()
        {
            return new {
                this.Id,
                this.Date,
                this.Etat,
                Client = this.Client == null ? null : this.Client.ToJson()
            };
        }
    }
}
