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

        [Fact]
        public void DeveAdicionarUmaJogada()
        {
            var jogador = JogadorBuilder.Novo().Criar();
            var jogadaEsperada = new Jogada(1, 1);

            jogador.AdicionaJogada(jogadaEsperada);

            jogadaEsperada.ToExpectedObject().ShouldMatch(jogador.Jogadas[0]);
        }

        [Fact]
        public void NaoDeveAdicionarUmaJogadaJaAdicionada()
        {
            var jogador = JogadorBuilder.Novo().Criar();
            var jogada = new Jogada(1, 1);
            
            jogador.AdicionaJogada(jogada);

            Assert.Throws<ArgumentException>(() => jogador.AdicionaJogada(jogada));
        }
    }
}
