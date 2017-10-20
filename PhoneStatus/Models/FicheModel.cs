using System;

namespace PhoneStatus.Models
{
    public class FicheModel
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Status status { get; set; }
        public DateTime Date{get; set;}
        public int Etat { get; set; }
    }
}