using CalculadoraDeBoliche;
using System;

namespace CalculadoraDeBolicheJogo
{
    public class Jogo
    {
        public static void JogarUmaPartida()
        {
            var partida = new Partida(1);
            var jogador = new Jogador(1, "João");
            var jogadorPartida = new JogadorPartida(1, jogador, partida);

            var jogada1 = new Jogada(1, 1, jogadorPartida);
            jogada1.AdicionaBola(new Bola(1, 1, 8));
            jogada1.AdicionaBola(new Bola(2, 2, 2, 8));
            jogadorPartida.AdicionaJogada(jogada1);

            var jogada2 = new Jogada(2, 2, jogadorPartida);
            jogada2.AdicionaBola(new Bola(3, 1, 5));
            jogada2.AdicionaBola(new Bola(4, 2, 2, 5));
            jogadorPartida.AdicionaJogada(jogada2);

            var jogada3 = new Jogada(3, 3, jogadorPartida);
            jogada3.AdicionaBola(new Bola(5, 1, 10));
            jogadorPartida.AdicionaJogada(jogada3);

            var jogada4 = new Jogada(4, 4, jogadorPartida);
            jogada4.AdicionaBola(new Bola(6, 1, 3));
            jogada4.AdicionaBola(new Bola(7, 2, 5, 3));
            jogadorPartida.AdicionaJogada(jogada4);

            var jogada5 = new Jogada(5, 5, jogadorPartida);
            jogada5.AdicionaBola(new Bola(8, 1, 2));
            jogada5.AdicionaBola(new Bola(9, 2, 6, 2));
            jogadorPartida.AdicionaJogada(jogada5);

            foreach (var jogada in jogadorPartida.Jogadas)
            {
                Console.WriteLine("pontuacao da jogada {0} {1} | {2} | {3} - {4}",
                    jogada.NumeroDaRodada,
                    jogada.PrimeiraBola != null ? jogada.PrimeiraBola.Pinos : 0,
                    jogada.SegundaBola != null ? jogada.SegundaBola.Pinos : 0,
                    jogada.PontuacaoExtra,
                    jogada.Pontuacao);
            }
        }

        public static void JogarUmaPartidaPerfeita()
        {
            var partida = new Partida(1);
            var jogador = new Jogador(1, "João");
            var jogadorPartida = new JogadorPartida(1, jogador, partida);
            
            for(var i = 1; i <= 10; i++)
            {
                var jogada = new Jogada(i, i, jogadorPartida);
                jogada.AdicionaBola(new Bola(i, 1, 10));
                
                if (jogada.NumeroDaRodada == 10)
                {
                    jogada.AdicionaBola(new Bola(i, 2, 10, 10));
                    jogada.AdicionaBola(new Bola(i, 3, 10, 10));
                }

                jogadorPartida.AdicionaJogada(jogada);
                Console.WriteLine("tipo jogada {0} - {1}", jogada.NumeroDaRodada, jogada.TipoJogada);
            }

            foreach(var jogada in jogadorPartida.Jogadas)
            {
                var numeroDaRodada = jogada.NumeroDaRodada;
                var pontuacao = jogada.Pontuacao;
                Console.WriteLine("rodada {0} | pontuacao {1}", numeroDaRodada, pontuacao);
            }

        }
    }
}
