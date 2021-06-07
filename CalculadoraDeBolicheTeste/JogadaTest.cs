using Xunit;
using ExpectedObjects;
using CalculadoraDeBoliche;
using System;
using CalculadoraDeBolicheTeste._Builders;

namespace CalculadoraDeBolicheTeste
{
    public class JogadaTest
    {
        [Fact]
        public void DeveCriarUmaJogada()
        {
            var jogadaEsperada = new
            {
                Id = 1,
                NumeroDaRodada = 1
            };
            
            var jogada = new Jogada(jogadaEsperada.Id, jogadaEsperada.NumeroDaRodada);
            
            jogadaEsperada.ToExpectedObject().ShouldMatch(jogada);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveCriarUmaJogadaComNumeroDaRodadaInvalida(int numeroDaRodada)
        {
            Assert.Throws<ArgumentException>(() => new Jogada(1, numeroDaRodada));
        }

        [Fact]
        public void DeveAdicionarUmaBola()
        {
            var jogada = JogadaBuilder.Novo().Criar();
            var bola = new Bola(1, 1, 1);
            jogada.AdicionaBola(bola);
            bola.ToExpectedObject().ShouldMatch(jogada.Bolas[0]);
        }

        [Fact]
        public void NaoDeveAdicionarUmaBolaComNumeracaoDuplicada()
        {
            var jogada = JogadaBuilder.Novo().Criar();
            var bola1 = new Bola(1, 1, 1);
            var bola2 = new Bola(2, 1, 10);

            jogada.AdicionaBola(bola1);

            Assert.Throws<ArgumentException>(() => jogada.AdicionaBola(bola2));
        }

        [Fact]
        public void NaoDeveASomaDosPinosDasBolasAdicionadasSomarMaisDeDezPinos()
        {
            var jogada = JogadaBuilder.Novo().Criar();
            var bola1 = BolaBuilder.Novo().ComNumero(1).ComPinos(5).Criar();
            var bola2 = BolaBuilder.Novo().ComNumero(2).ComPinos(6).Criar();
            jogada.AdicionaBola(bola1);
            Assert.Throws<ArgumentException>(() => jogada.AdicionaBola(bola2));
        }

        [Fact]
        public void NaoDeveSerAdicionadaAMesmaBolaMaisDeUmaVez()
        {
            var jogada = JogadaBuilder.Novo().Criar();
            var bola = BolaBuilder.Novo().Criar();
            jogada.AdicionaBola(bola);
            Assert.Throws<ArgumentException>(() => jogada.AdicionaBola(bola));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(21)]
        public void NaoDeveSerAdicionaUmaJogadaComNumeroDeRodadaMenorQueUmOuMaiorQueVinte(int numero)
        {
            Assert.Throws<ArgumentException>(() => JogadaBuilder.Novo().ComNumeroDaRodada(numero).Criar());
        }
    }
}
