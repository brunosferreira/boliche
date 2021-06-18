using System;

namespace CalculadoraDeBoliche
{
    public class Jogador
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Jogador(int id, string nome)
        {
            ValidarCamposObrigatorios(nome);
            Id = id;
            Nome = nome;
        }

        public void ValidarCamposObrigatorios(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("O nome informado é inválido.");
        }
    }
}
