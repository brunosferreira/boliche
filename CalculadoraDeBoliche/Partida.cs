using System;
using System.Collections.Generic;

namespace CalculadoraDeBoliche
{
    public class Partida
    {
        public int Id { get; private set; }
        public int JogadaAtual { get; private set; }
        public List<Jogador> Jogadores { get; private set; }
        public Partida(int id)
        {
            Id = id;
            JogadaAtual = 1;
            Jogadores = new List<Jogador>();
        }

        public void AdicionaJogador(Jogador jogador)
        {
            if(Jogadores.Count > 0)
            {
                foreach (var _jogador in Jogadores)
                {
                    if (_jogador.Equals(jogador))
                        throw new ArgumentException("Não deve ser informado o mesmo jogador mais de uma vez.");
                }
            }

            Jogadores.Add(jogador);
        }
    }
}
