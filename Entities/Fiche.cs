using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Fiche
    {
        public int Id { get; }
        public int IdClient { get; }
        public int IdStatus { get; }

        #region constructors

        private Fiche() { }
        public Fiche(int id, int idClient, int idStatus) {
            this.Id = id;
            this.IdClient = idClient;
            this.IdStatus = idStatus;
        }
        #endregion
        
    }
}
