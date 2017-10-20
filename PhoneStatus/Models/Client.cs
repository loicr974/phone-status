using System.ComponentModel.DataAnnotations;

namespace PhoneStatus.Models
{
    public class Client
    {
        [Required]
        [Display(Name = "Le nom du client")]
        
        public string Nom { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Prenom { get; set; }

        [Required]
        public string CP { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }


    }
}