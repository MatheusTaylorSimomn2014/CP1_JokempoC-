namespace Jokempo.Lib
{
    public class Jogador
    {
        public string Nome { get; set; }
        public int Vitorias { get; private set; }
        public int Derrotas { get; private set; }
        public int Empates { get; private set; }
        public int Partidas => Vitorias + Derrotas + Empates;

        public Jogador(string nome) => Nome = nome;

        public void RegistrarVitoria() => Vitorias++;
        public void RegistrarDerrota() => Derrotas++;
        public void RegistrarEmpate() => Empates++;

        public double PercentualVitorias =>
            Partidas == 0 ? 0 : (double)Vitorias / Partidas * 100;
    }
}