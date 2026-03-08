using System;

namespace Jokempo
{
    public class Jogador
    {
        public string Nome { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int Empates { get; set; }
        public int Partidas { get; set; }

        public Jogador(string nome)
        {
            Nome = nome;
            Vitorias = 0;
            Derrotas = 0;
            Empates = 0;
            Partidas = 0;
        }

        public void RegistrarVitoria()
        {
            Vitorias++;
            Partidas++;
        }

        public void RegistrarDerrota()
        {
            Derrotas++;
            Partidas++;
        }

        public void RegistrarEmpate()
        {
            Empates++;
            Partidas++;
        }

        public double CalcularPorcentagemVitorias()
        {
            if (Partidas == 0) return 0;
            return (double)Vitorias / Partidas * 100;
        }

        public void ExibirEstatisticas()
        {
            ConsoleHelper.EscreverLinha($"\n╔══════════════════════════════════════════╗", ConsoleColor.Cyan);
            ConsoleHelper.EscreverLinha($"║     ESTATÍSTICAS DE {Nome.ToUpper().PadRight(20)}║", ConsoleColor.Cyan);
            ConsoleHelper.EscreverLinha($"╠══════════════════════════════════════════╣", ConsoleColor.Cyan);
            ConsoleHelper.EscreverLinha($"║  Partidas Jogadas: {Partidas.ToString().PadRight(22)}║", ConsoleColor.Cyan);
            ConsoleHelper.EscreverLinha($"║  Vitórias:         {Vitorias.ToString().PadRight(22)}║", ConsoleColor.Cyan);
            ConsoleHelper.EscreverLinha($"║  Derrotas:         {Derrotas.ToString().PadRight(22)}║", ConsoleColor.Cyan);
            ConsoleHelper.EscreverLinha($"║  Empates:          {Empates.ToString().PadRight(22)}║", ConsoleColor.Cyan);
            ConsoleHelper.EscreverLinha($"║  % de Vitórias:    {CalcularPorcentagemVitorias():F1}%".PadRight(24) + "║", ConsoleColor.Cyan);
            ConsoleHelper.EscreverLinha($"╚══════════════════════════════════════════╝", ConsoleColor.Cyan);
        }
    }
}