using System;
using System.Collections.Generic;
using System.Text;
using CalculadoraDeBoliche;

namespace CalculadoraDeBolicheJogo
{
    public class Jogo
    {
        public Partida Partida { get; private set; }
        private int Rodada = 1;

        public Jogo()
        {
            Partida = new Partida(1);
        }

        public void EfetuaJogada()
        {
            var jogada = new Jogada(Rodada, Rodada);
            var random = new Random();
            var pinos = random.Next(0, 10);
        }
    }
}
