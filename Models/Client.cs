using System.ComponentModel.DataAnnotations;

namespace SalaApp.Models
{
    public class Client
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele trebuie sa inceapa cu majuscula.")]
        public string Nume { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula")]
        public string Prenume { get; set; }
        [Display(Name = "Nume Client")]
        public string NumeClient
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public string Email { get; set; }
        [RegularExpression(@"^0[0-9]{2}[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie să înceapă cu 0 și să fie de forma '072-123-123' sau '072.123.123' sau '072 123 123'")]
        public string Telefon { get; set; }
        public ICollection<Programare>? Programari { get; set; }
        public ICollection<Abonament>? Abonamente { get; set; } 
    }
}
