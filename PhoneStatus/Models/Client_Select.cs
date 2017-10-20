using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneStatus.Models
{
    public class Client_Select
    {
        public int Id_Client { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }

    }
}