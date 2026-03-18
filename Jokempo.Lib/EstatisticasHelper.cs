using System.Text;

namespace Jokempo.Lib
{
    public static class EstatisticasHelper
    {
        public static string ResumoJogador(Jogador j) =>
            $"{j.Nome}: {j.Vitorias}V {j.Derrotas}D {j.Empates}E ({j.PercentualVitorias:F1}%)";
    }
}