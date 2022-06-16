using System.ComponentModel.DataAnnotations;

namespace BackEndPortafolioTarjeta.Models
{
    public class CredictCardModel
    {
        public int id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(20)]
        public string numeroTarjeta { get; set; }

        [Required]
        [MaxLength(10)]
        public string fechaExp { get; set; }

        [Required]
        [MaxLength(3)]
        public string cvv { get; set; }

    }
}
