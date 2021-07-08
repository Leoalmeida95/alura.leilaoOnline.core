using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alura.LeilaoOnline.Core
{
    public class Interessada
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; private set; }
        public IEnumerable<Lance> Lances { get; set; }
        public IEnumerable<Favorito> Favoritos { get; set; }

        public Interessada(string nome)
        {
            Nome = nome;
        }
    }
}
