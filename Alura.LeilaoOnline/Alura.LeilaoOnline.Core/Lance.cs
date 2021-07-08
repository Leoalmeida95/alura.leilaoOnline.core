using System.ComponentModel.DataAnnotations;

namespace Alura.LeilaoOnline.Core
{
    public class Lance
    {
        public int Id { get; set; }
        public double Valor { get; private set; }
        [Required]
        public Interessada Cliente { get; set; }
        [Required]
        public Leilao Leilao { get; set; }

        private void ValidaValorLance(double valor)
        {
            if (valor < 0)
            {
                throw new System.ArgumentException("Valor do lance deve ser igual ou maior que zero.");
            }
        }

        public Lance(double valor)
        {
            ValidaValorLance(valor);
            Valor = valor;
        }

        public Lance(Interessada cliente, double valor)
        {
            ValidaValorLance(valor);
            Cliente = cliente;
            Valor = valor;
        }
    }
}
