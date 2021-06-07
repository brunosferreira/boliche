using System;
using System.Collections.Generic;

namespace CalculadoraDeBoliche
{
    public class Jogador
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public List<Jogada> Jogadas { get; private set; }
        public int Pontuacao { get; private set; }

        public Jogador(int id, string nome)
        {
            ValidarCamposObrigatorios(nome);
            Id = id;
            Nome = nome;
            Jogadas = new List<Jogada>();
            Pontuacao = 0;
        }

        public void AdicionaJogada(Jogada jogada)
        {
            if(Jogadas.Count > 0)
            {
                foreach(var _jogada in Jogadas)
                {
                    if (jogada.Equals(_jogada))
                        throw new ArgumentException("Não deve ser adicionada a mesma jogada para o jogador");
                }
            }
            
            Jogadas.Add(jogada);

            Pontuacao += jogada.Pontuacao;
        }

        public void ValidarCamposObrigatorios(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("O nome informado é inválido.");
        }

        private void CalculaPontuacao()
        {
            Pontuacao = 0;
            foreach(var _jogada in Jogadas)
            {
                Pontuacao += _jogada.Pontuacao;
            }
        }
    }
}
