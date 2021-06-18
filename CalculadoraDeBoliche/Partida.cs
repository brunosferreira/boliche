
namespace CalculadoraDeBoliche
{
    public class Partida
    {
        public int Id { get; private set; }
        public int JogadaAtual { get; private set; }
        public Partida(int id)
        {
            Id = id;
            JogadaAtual = 1;
        }
    }
}
