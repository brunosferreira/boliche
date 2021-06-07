using System;
using System.Collections.Generic;

namespace CalculadoraDeBoliche
{
    public class Jogada
    {
        public int Id { get; private set; }
        public int NumeroDaRodada { get; private set; }
        public List<Bola> Bolas { get; private set; }
        public int Pontuacao { get; private set; }
        public TipoJogada TipoJogada { get; private set; }

        public Jogada(int id, int numeroDaRodada)
        {
            ValidaCampos(numeroDaRodada);
            Id = id;
            NumeroDaRodada = numeroDaRodada;
            Bolas = new List<Bola>();
            Pontuacao = 0;
        }

        public void ValidaCampos(int numeroDaRodada)
        {
            if (numeroDaRodada <= 0 || numeroDaRodada > 10)
                throw new ArgumentException("Número da rodada informado é inválido.");
        }

        public TipoJogada AdicionaBola(Bola bola)
        {
            ValidaBola(bola);
            Pontuacao += bola.Pinos;
            Bolas.Add(bola);
            return bola.TipoJogada;
        }

        private void ValidaBola(Bola bola)
        {
            if (Bolas.Count > 0)
            {
                if (Bolas[0].Equals(bola))
                    throw new ArgumentException("Esta bola já foi adicionada nesta jogada.");

                if (Bolas[0].Numero == bola.Numero)
                    throw new ArgumentException("Uma bola com esse número já foi informada na jogada.");

                if (Bolas[0].Pinos + bola.Pinos > 10)
                    throw new ArgumentException("A soma dos pinos das bolas na jogada é superior a 10");
            }
        }
    }
}
