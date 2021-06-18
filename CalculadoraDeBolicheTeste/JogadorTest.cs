using System;
using Xunit;
using CalculadoraDeBoliche;
using ExpectedObjects;
using CalculadoraDeBolicheTeste._Builders;

namespace CalculadoraDeBolicheTeste
{
    public class JogadorTest
    {
        [Fact]
        public void DeveCriarUmJogador()
        {
            var jogadorEsperado = JogadorBuilder.Novo().Criar();
            var jogador = new Jogador(jogadorEsperado.Id, jogadorEsperado.Nome);
            jogadorEsperado.ToExpectedObject().ShouldMatch(jogador);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarUmJogadorSemNome(string nome)
        {
            Assert.Throws<ArgumentException>(() => JogadorBuilder.Novo().ComNome(nome).Criar());
        }
    }
}
