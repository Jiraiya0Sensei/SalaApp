using System.ComponentModel.DataAnnotations;

namespace SalaApp.Models
{
    public class Programare
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Clientul este obligatoriu.")]
        [Display(Name = "Client")]
        public int? ClientID { get; set; }

        [Required(ErrorMessage = "Antrenorul este obligatoriu.")]
        [Display(Name = "Antrenor")]
        public int? AntrenorID { get; set; }

        [Required(ErrorMessage = "Data programării este obligatorie.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Programării")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Ora programării este obligatorie.")]
        [RegularExpression(@"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Ora introdusă nu este validă.")]
        public string Ora_inceput { get; set; }

        [Required(ErrorMessage = "Ora programării este obligatorie.")]
        [RegularExpression(@"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Ora introdusă nu este validă.")]
        public string Ora_sfarsit { get; set; }

        public Client? Client { get; set; }
        public Antrenor? Antrenor { get; set; }
    }
}
