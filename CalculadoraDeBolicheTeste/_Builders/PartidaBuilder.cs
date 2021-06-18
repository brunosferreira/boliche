using System.Collections.Generic;
using Bogus;
using CalculadoraDeBoliche;

namespace CalculadoraDeBolicheTeste._Builders
{
    public class PartidaBuilder
    {
        private static Faker faker = new Faker("pt_BR");

        private int Id = faker.Random.Number();
        
        public static PartidaBuilder Novo()
        {
            return new PartidaBuilder();
        }

        public Partida Criar()
        {
            return new Partida(Id);
        }
    }
}
