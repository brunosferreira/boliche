using System;
using System.Collections.Generic;
using System.Text;
using CalculadoraDeBoliche;
using Bogus;

namespace CalculadoraDeBolicheTeste._Builders
{
    public class BolaBuilder
    {
        private static Faker faker = new Faker("pt_BR");
        private int Id = faker.Random.Number();
        private int Numero = faker.Random.Number(1, 2);
        private int Pinos = faker.Random.Number(0, 10);
        private int PontuacaoAnterior = faker.Random.Number(0, 9);

        public static BolaBuilder Novo()
        {
            return new BolaBuilder();
        }

        public Bola Criar()
        {
            return new Bola(Id, Numero, Pinos, PontuacaoAnterior);
        }

        public BolaBuilder ComNumero(int numero)
        {
            Numero = numero;
            return this;
        }

        public BolaBuilder ComPinos(int pinos)
        {
            Pinos = pinos;
            return this;
        }

        public BolaBuilder ComPontuacaoAnterior(int pontuacaoAnterior)
        {
            PontuacaoAnterior = pontuacaoAnterior;
            return this;
        }

    }
}
