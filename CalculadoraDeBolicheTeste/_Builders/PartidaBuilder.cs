using System.Collections.Generic;
using Bogus;
using CalculadoraDeBoliche;

namespace CalculadoraDeBolicheTeste._Builders
{
    public class PartidaBuilder
    {
        private static Faker faker = new Faker("pt_BR");

        private int Id = faker.Random.Number();
        private List<Jogador> Jogadores = new List<Jogador>();
        
        public static PartidaBuilder Novo()
        {
            return new PartidaBuilder();
        }

        public PartidaBuilder ComJogador(Jogador jogador)
        {
            Jogadores.Add(jogador);
            return this;
        }

        public Partida Criar()
        {
            var partida = new Partida(Id);
            foreach (var jogador in Jogadores)
                partida.AdicionaJogador(jogador);
            return partida;
        }

    }
}
