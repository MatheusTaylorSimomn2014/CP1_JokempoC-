using Jokempo.Lib;

namespace Jokempo.ConsoleApp
{
    class JogoConsole
    {
        private Jogo _jogo;
        // ...
        public void Iniciar()
        {
            // cria _jogo via library
            _jogo = new Jogo(nome1, contraCPU);
            // ...
        }

        private void JogarRodada()
        {
            var rodada = _jogo.CriarRodada();
            Opcao jogada1 = LerJogada(_jogo.JogadorAtual.Nome);
            Opcao jogada2 = _jogo.Adversario.Nome == "CPU" ? _jogo.JogadaCPU() : LerJogada(_jogo.Adversario.Nome);
            rodada.Jogar(jogada1, jogada2);
            // exibe resultado usando dados da rodada
        }
    }
}