using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculadoraDeBoliche
{
    public class JogadorPartida
    {
        public int Id { get; private set; }
        public Jogador Jogador { get; private set; }
        public Partida Partida { get; private set; }
        public List<Jogada> Jogadas { get; private set; }
        public int PontuacaoTotal => Jogadas.Sum(j => j.Pontuacao);

        public JogadorPartida(int id, Jogador jogador, Partida partida)
        {
            Id = id;
            Jogador = jogador;
            Partida = partida;
            Jogadas = new List<Jogada>();
        }

        public void AdicionaJogada(Jogada jogada)
        {
            ValidaJogadaAdicionada(jogada);
            Jogadas.Add(jogada);
        }

        private void ValidaJogadaAdicionada(Jogada jogada)
        {
            foreach(var _jogada in Jogadas)
            {
                if (jogada.Equals(_jogada))
                    throw new ArgumentException("Não deve ser adicionada a mesma jogada mais de uma vez para o jogador.");
            }
        }
    }
}
