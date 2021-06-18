using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using CalculadoraDeBoliche;

namespace CalculadoraDeBolicheTeste._Builders
{
    public class JogadaBuilder
    {
        private static Faker faker = new Faker("pt_BR");

        private int Id = faker.Random.Number();
        private int NumeroDaRodada = faker.Random.Number(1, 10);
        private Jogador Jogador = JogadorBuilder.Novo().Criar();
        private Partida Partida = PartidaBuilder.Novo().Criar();
        private JogadorPartida JogadorPartida;

        public static JogadaBuilder Novo()
        {
            return new JogadaBuilder();
        }

        public Jogada Criar()
        {
            JogadorPartida = new JogadorPartida(1, Jogador, Partida);
            return new Jogada(Id, NumeroDaRodada, JogadorPartida);
        }

        public JogadaBuilder ComNumeroDaRodada(int numeroDaRodada)
        {
            NumeroDaRodada = numeroDaRodada;
            return this;
        }
    }
}
