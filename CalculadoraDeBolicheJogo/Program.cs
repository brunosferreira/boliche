using System;
using CalculadoraDeBoliche;
using Bogus;

namespace CalculadoraDeBolicheJogo
{
    class Program
    {
        static void Main(string[] args)
        {
            var partida = new Partida(1);
            var faker = new Faker("pt_BR");
            var jogador1 = new Jogador(1, faker.Person.FirstName);
            faker = new Faker("pt_BR");
            var jogador2 = new Jogador(2, faker.Person.FirstName);

            partida.AdicionaJogador(jogador1);
            partida.AdicionaJogador(jogador2);

            var rodada = 1;
            var bolaId = 1;
            var pontuacaoAnterior = -1;
            for (var i = 1; i <= 10; i++)
            {
                foreach(var jogador in partida.Jogadores)
                {
                    var jogada = new Jogada(i, rodada);
                    for (var j = 1; j <= 2; j++)
                    {
                        var pontuacao = faker.Random.Number(0, j == 2 ? 10 - pontuacaoAnterior : 10);
                        var bola = new Bola(bolaId, j, pontuacao, pontuacaoAnterior);
                        pontuacaoAnterior = j == 1 ? pontuacao : -1;
                        jogada.AdicionaBola(bola);
                    }
                    jogador.AdicionaJogada(jogada);
                }
                rodada++;
            }

            foreach (var jogador in partida.Jogadores)
            {
                Console.WriteLine(String.Format("resultado do jogador {0}", jogador.Nome));
                //Console.WriteLine(String.Format("|-------|-------|-------|-------|-------|-------|-------|-------|-----------|"));
                foreach (var jogada in jogador.Jogadas)
                {
                    foreach(var bola in jogada.Bolas)
                    {
                        Console.WriteLine(String.Format("a pontuação da bola {0} é de {1}", bola.Numero, bola.Pinos));
                    }
                    Console.WriteLine(String.Format("a pontuação da jogada {0} é {1}", jogada.NumeroDaRodada, jogada.Pontuacao));
                }
                Console.WriteLine(String.Format("a pontuação final do jogador é {0}", jogador.Pontuacao));
            }
            //Console.WriteLine(String.Format("|-------|-------|-------|-------|-------|-------|-------|-------|-----------|"));
        }
    }
}
