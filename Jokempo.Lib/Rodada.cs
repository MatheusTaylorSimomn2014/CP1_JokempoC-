namespace Jokempo.Lib
{
    public class Rodada
    {
        public Jogador Jogador1 { get; }
        public Jogador Jogador2 { get; }
        public Opcao EscolhaJogador1 { get; private set; }
        public Opcao EscolhaJogador2 { get; private set; }
        public Jogador? Vencedor { get; private set; }
        public bool Empate => Vencedor == null;

        public Rodada(Jogador j1, Jogador j2)
        {
            Jogador1 = j1;
            Jogador2 = j2;
        }

        public void Jogar(Opcao escolha1, Opcao escolha2)
        {
            EscolhaJogador1 = escolha1;
            EscolhaJogador2 = escolha2;

            if (escolha1 == escolha2)
            {
                Vencedor = null;
                Jogador1.RegistrarEmpate();
                Jogador2.RegistrarEmpate();
            }
            else if (Jogador1Vence(escolha1, escolha2))
            {
                Vencedor = Jogador1;
                Jogador1.RegistrarVitoria();
                Jogador2.RegistrarDerrota();
            }
            else
            {
                Vencedor = Jogador2;
                Jogador1.RegistrarDerrota();
                Jogador2.RegistrarVitoria();
            }
        }

        private static bool Jogador1Vence(Opcao j1, Opcao j2) =>
            (j1 == Opcao.Pedra && j2 == Opcao.Tesoura) ||
            (j1 == Opcao.Papel && j2 == Opcao.Pedra) ||
            (j1 == Opcao.Tesoura && j2 == Opcao.Papel);
    }
}