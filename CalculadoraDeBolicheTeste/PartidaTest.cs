using System;
using Xunit;
using ExpectedObjects;
using CalculadoraDeBolicheTeste._Builders;
using CalculadoraDeBoliche;


namespace CalculadoraDeBolicheTeste
{
    public class PartidaTest
    {
        [Fact]
        public void DeveCriarUmaPartida()
        {
            var partidaEsperada = PartidaBuilder.Novo().Criar();
            var partida = new Partida(partidaEsperada.Id);
            partidaEsperada.ToExpectedObject().ShouldMatch(partida);
        }

        [Fact]
        public void NaoDeveCriarPartidaComOMesmoJogadorMaisDeUmaVez()
        {
            var jogador = JogadorBuilder.Novo().Criar();
            var partida = PartidaBuilder.Novo().ComJogador(jogador).Criar();
            Assert.Throws<ArgumentException>(() => partida.AdicionaJogador(jogador));
        }
    }
}
