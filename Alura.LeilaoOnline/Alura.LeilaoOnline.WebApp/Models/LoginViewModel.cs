using System.ComponentModel.DataAnnotations;

namespace Alura.LeilaoOnline.WebApp.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuário")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
