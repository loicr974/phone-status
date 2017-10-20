using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public interface IFiche
    {
        int Id { get; set; }
        int Id_client { get; set; }
        System.DateTime Date { get; set; }
        int Etat { get; set; }
    }
}
