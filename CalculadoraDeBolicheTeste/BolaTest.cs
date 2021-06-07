using System;
using CalculadoraDeBoliche;
using Xunit;
using ExpectedObjects;

namespace CalculadoraDeBolicheTeste
{
    public class BolaTest
    {
        [Fact]
        public void DeveCriarUmaBola()
        {
            var bolaEsperada = new Bola(1, 1, 1);
            
            var bola = new Bola(bolaEsperada.Id, bolaEsperada.Numero, bolaEsperada.Pinos);

            bolaEsperada.ToExpectedObject().ShouldMatch(bola);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(3)]
        public void NaoDeveCriarUmaBolaComNumeroMenorQueUmOuMaiorQueDois(int numero)
        {
            Assert.Throws<ArgumentException>(() => new Bola(1, numero, 1));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        public void NaoDeveCriarUmaBolaComQuantidadeDePinosMenorQueZeroOuMaiorQueDez(int pinos)
        {
            Assert.Throws<ArgumentException>(() => new Bola(1, 1, pinos));
        }

        [Fact]
        public void NaoDeveCriarSegundaBolaSemInformarAPontuacaoAnterior()
        {
            Assert.Throws<ArgumentException>(() => new Bola(1, 2, 5));
        }
    }
}
