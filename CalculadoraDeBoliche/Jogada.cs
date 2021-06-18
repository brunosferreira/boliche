using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculadoraDeBoliche
{
    public class Jogada
    {
        public int Id { get; private set; }
        public int NumeroDaRodada { get; private set; }
        public List<Bola> Bolas { get; private set; }
        public int Pontuacao => Bolas.Sum(b => b.Pinos) + PontuacaoExtra;
        public int PontuacaoExtra => CalcularPontuacaoExtra();
        public TipoJogada TipoJogada { get; private set; }
        public Bola PrimeiraBola => Bolas[0];
        public Bola SegundaBola => Bolas.Count >= 2 ? Bolas[1] : null;
        public Bola BolaExtra => Bolas.Count == 3 ? Bolas[2] : null;
        public Boolean PermiteBolaExtra => (NumeroDaRodada == 10 && (TipoJogada == TipoJogada.Spare || TipoJogada == TipoJogada.Strike));
        public JogadorPartida JogadorPartida { get; private set; }

        public Jogada(int id, int numeroDaRodada, JogadorPartida jogadorPartida)
        {
            ValidaCampos(numeroDaRodada);
            Id = id;
            NumeroDaRodada = numeroDaRodada;
            Bolas = new List<Bola>();
            JogadorPartida = jogadorPartida;
        }

        public void ValidaCampos(int numeroDaRodada)
        {
            if (numeroDaRodada <= 0 || numeroDaRodada > 10)
                throw new ArgumentException("Número da rodada informado é inválido.");
        }

        public void AdicionaBola(Bola bola)
        {
            ValidaBola(bola);
            Bolas.Add(bola);
            VerificaTipoDaJogada();
        }

        private void VerificaTipoDaJogada()
        {
            TipoJogada = Bolas.Sum(b => b.Pinos) >= 10 ? Bolas[0].Pinos == 10 ? TipoJogada.Strike : TipoJogada.Spare : TipoJogada.Normal;
        }

        private int CalcularPontuacaoExtra()
        {
            var indiceDaJogada = NumeroDaRodada + 1;
            
            if (TipoJogada == TipoJogada.Spare)
            {
                if (JogadorPartida.Jogadas.Count >= indiceDaJogada)
                    return JogadorPartida.Jogadas[indiceDaJogada - 1].PrimeiraBola.Pinos;
            }

            if (TipoJogada == TipoJogada.Strike)
            {
                if (JogadorPartida.Jogadas.Count >= indiceDaJogada)
                {
                    if (JogadorPartida.Jogadas[indiceDaJogada - 1].TipoJogada == TipoJogada.Strike)
                    {
                        if (JogadorPartida.Jogadas.Count >= indiceDaJogada + 1)
                            return JogadorPartida.Jogadas[indiceDaJogada - 1].PrimeiraBola.Pinos + JogadorPartida.Jogadas[indiceDaJogada].PrimeiraBola.Pinos;
                        if (indiceDaJogada == 10)
                        {
                            var primeiraBola = JogadorPartida.Jogadas[9].PrimeiraBola.Pinos;
                            var segundaBola = JogadorPartida.Jogadas[9].Bolas.Count >= 2 ? JogadorPartida.Jogadas[9].SegundaBola.Pinos : 0;
                            return primeiraBola + segundaBola;

                        }
                    }
                    var b1 = JogadorPartida.Jogadas[indiceDaJogada - 1].PrimeiraBola.Pinos;
                    var b2 = JogadorPartida.Jogadas[indiceDaJogada - 1].Bolas.Count >= 2 ? JogadorPartida.Jogadas[indiceDaJogada - 1].SegundaBola.Pinos : 0;
                    return b1 + b2;
                }
            }
            return 0;
        }

        private void ValidaBola(Bola bola)
        {
            if (Bolas.Count > 0)
            {
                if (Bolas[0].Equals(bola))
                    throw new ArgumentException("Esta bola já foi adicionada nesta jogada.");

                if (Bolas[0].Numero == bola.Numero)
                    throw new ArgumentException("Uma bola com esse número já foi informada na jogada.");

                if (Bolas[0].Pinos + bola.Pinos > 10 && NumeroDaRodada < 10)
                    throw new ArgumentException("A soma dos pinos das bolas na jogada é superior a 10");
            }
        }
    }
}
