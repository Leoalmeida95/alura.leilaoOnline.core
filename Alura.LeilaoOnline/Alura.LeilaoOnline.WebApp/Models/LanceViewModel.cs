using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Models
{
    public class LanceViewModel
    {
        [Required]
        public int LeilaoId { get; set; }

        [Required]
        public int UsuarioLogadoId { get; set; }

        [Required]
        public double Valor { get; set; }
    }
}
