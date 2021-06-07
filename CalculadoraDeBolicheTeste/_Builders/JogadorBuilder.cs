using Bogus;
using CalculadoraDeBoliche;

namespace CalculadoraDeBolicheTeste._Builders
{
    public class JogadorBuilder
    {
        private static Faker faker = new Faker("pt_BR");
        private int Id = faker.Random.Number();
        private string Nome = faker.Person.FirstName;

        public static JogadorBuilder Novo()
        {
            return new JogadorBuilder();
        }

        public JogadorBuilder ComNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public Jogador Criar()
        {
            return new Jogador(Id, Nome);
        }

    }
}
