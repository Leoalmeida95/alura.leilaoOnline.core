using System.ComponentModel.DataAnnotations;

namespace Alura.LeilaoOnline.Core
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public Interessada Interessada { get; set; }
    }
}
