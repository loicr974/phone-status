using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public interface IClient
    {
        int Id { get; set; }
        string Nom { get; set; }
        string Prenom { get; set; }
        string Mail { get; set; }
        int Cp { get; set; }
    }
}
