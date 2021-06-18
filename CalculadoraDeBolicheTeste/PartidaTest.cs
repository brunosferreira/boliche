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
    }
}
