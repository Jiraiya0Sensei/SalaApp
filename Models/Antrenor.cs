using System.ComponentModel.DataAnnotations;

namespace SalaApp.Models
{
    public class Antrenor
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele trebuie sa inceapa cu majuscula.")]
        [Display(Name = "Antrenor")]
        public string? Nume { get; set; }

        [RegularExpression(@"^0[0-9]{2}[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie să înceapă cu 0 și să fie de forma '072-123-123' sau '072.123.123' sau '072 123 123'")]
        public string? Telefon { get; set; }
        public string? Email { get; set; }
        public int? SportID { get; set; }
        public Sport? Sport { get; set; }
        public ICollection<Programare>? Programari { get; set; } //navigation property
    }
}
