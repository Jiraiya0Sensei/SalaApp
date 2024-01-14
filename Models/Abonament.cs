using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalaApp.Models
{
    public class Abonament
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Data incepere abonament este obligatorie.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data_inceput { get; set; }

        [Required(ErrorMessage = "Data incetare abonament este obligatorie.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data_expirare  { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 900)]
        public decimal Pret { get; set; }
        public int ClientID { get; set; }
        public Client? Client { get; set; }
        public int SportID { get; set; }
        public Sport? Sport { get; set; }

    }
}
