using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneStatus.Models
{
    public class Fiche_Create
    {

        public Fiche_Create()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Date de prise en charge")]
        public DateTime Date { get; set; }

        [Required]
        public IEnumerable<SelectListItem> ListClient { get; set; }
        public int Id_Client { get; set; }
    }

}