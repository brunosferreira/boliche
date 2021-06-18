using CalculadoraDeBoliche;
using CalculadoraDeBolicheTeste._Builders;
using System;
using System.Collections.Generic;
using Xunit;
using ExpectedObjects;

namespace CalculadoraDeBolicheTeste
{
    public class JogadorPartidaTest
    {
        [Fact]
        public void DeveCriarUmJogadorPartida()
        {
            var jogador = JogadorBuilder.Novo().Criar();
            var partida = PartidaBuilder.Novo().Criar();
            
            var jogadorPartidaEsperado = new
            {
                Id = 1,
                Jogador = jogador,
                Partida = partida,
                Jogadas = new List<Jogada>()
            };

            var jogadorPartida = new JogadorPartida(jogadorPartidaEsperado.Id, jogadorPartidaEsperado.Jogador, jogadorPartidaEsperado.Partida);

            jogadorPartidaEsperado.ToExpectedObject().ShouldMatch(jogadorPartida);
        }

        [Fact]
        public void NaoDeveAdicionarDuasVezesAMesmaJogadaNaPartida()
        {
            var jogador = JogadorBuilder.Novo().Criar();
            var partida = PartidaBuilder.Novo().Criar();
            var jogadorPartida = new JogadorPartida(1, jogador, partida);
            var jogada = JogadaBuilder.Novo().Criar();

            jogadorPartida.AdicionaJogada(jogada);

            Assert.Throws<ArgumentException>(() => jogadorPartida.AdicionaJogada(jogada));
        }
    }
}
