using System;

namespace CalculadoraDeBoliche
{
    public class Bola
    {
        public int Id { get; private set; }
        public int Numero { get; private set; }
        public int Pinos { get; private set; }
        public TipoJogada TipoJogada { get; private set; }
        private int PontuacaoAnterior { get; set; }

        public Bola(int id, int numero, int pinos, int pontuacaoAnterior = -1)
        {
            ValidaBola(numero, pinos, pontuacaoAnterior);
            Id = id;
            Numero = numero;
            Pinos = pinos;
            PontuacaoAnterior = pontuacaoAnterior;
            TipoJogada = CalculaTipoDaJogada();
        }

        private void ValidaBola(int numero, int pinos, int pontuacaoAnterior)
        {
            if(numero < 1 || numero > 3)
                throw new ArgumentException("O número da bola informado não deve ser menor que 1 ou maior que 3.");

            if (pinos < 0 || pinos > 10)
                throw new ArgumentException("A quantidade de pinos informada não deve ser menor que 0 ou maior que 10.");

            if (numero == 2 && pontuacaoAnterior == -1)
                throw new ArgumentException("Para a bola número 2 deve ser informada a pontuação da bola anterior.");
        }

        private TipoJogada CalculaTipoDaJogada()
        {
            if (Pinos == 10)
                return TipoJogada.Strike;

            if (Pinos + PontuacaoAnterior == 10)
                return TipoJogada.Spare;

            return TipoJogada.Normal;
        }
    }
}
