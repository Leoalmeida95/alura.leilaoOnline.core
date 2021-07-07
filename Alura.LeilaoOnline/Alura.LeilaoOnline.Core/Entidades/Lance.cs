using System;

namespace Alura.LeilaoOnline.Core.Entidades
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            if (valor < 0) throw new ArgumentException("Valor deve ser positivo.");

            Cliente = cliente;
            Valor = valor;
        }
    }
}
