using System;
using System.Collections.Generic;
using System.Linq;

namespace Jokempo
{
    public enum Opcao
    {
        Pedra = 1,
        Papel = 2,
        Tesoura = 3,
    }

    public class Jogo
    {
        private List<Jogador> jogadores = new List<Jogador>();
        private Jogador? _jogadorAtual;
        private Jogador? _jogador2;

        private Jogador jogadorAtual => _jogadorAtual!;
        private Jogador jogador2 => _jogador2!;

        public void Iniciar()
        {
            MostrarBoasVindas();

           
            string nome1 = LerNomeJogador(1);
            _jogadorAtual = new Jogador(nome1);
            jogadores.Add(_jogadorAtual);

         
            bool jogandoContraCpu = ConsoleHelper.LerSimNao("\nDeseja jogar contra CPU? (S/N): ");

            if (jogandoContraCpu)
            {
                _jogador2 = new Jogador("CPU");
            }
            else
            {
                string nome2 = LerNomeJogador(2, new[] { nome1 }); 
                _jogador2 = new Jogador(nome2);
                jogadores.Add(_jogador2);
            }

            
            bool continuando = true;
            while (continuando)
            {
                MostrarMenuPrincipal();
                int opcao = ConsoleHelper.LerInteiro("Escolha uma opção: ", 0, 5);

                switch (opcao)
                {
                    case 1:
                        JogarRodada();
                        break;
                    case 2:
                        MostrarEstatisticas();
                        break;
                    case 3:
                        AdicionarSegundoJogador();
                        break;
                    case 4:
                        TrocarJogador();
                        break;
                    case 5:
                        MostrarEstatisticasGlobais();
                        break;
                    case 0:
                        continuando = false;
                        MostrarDespedida();
                        break;
                }
            }
        }

        private void MostrarBoasVindas()
        {
            Console.Clear();
            ConsoleHelper.EscreverLinha(@"
    ╔══════════════════════════════════════════════════════════════╗
    ║                                                              ║
    ║     █████╗  ██████╗ ██████╗███████╗███████╗███████╗         ║
    ║    ██╔══██╗██╔════╝██╔════╝██╔════╝██╔════╝██╔════╝         ║
    ║    ███████║██║     ██║     █████╗  ███████╗███████╗         ║
    ║    ██╔══██║██║     ██║     ██╔══╝  ╚════██║╚════██║         ║
    ║    ██║  ██║╚██████╗╚██████╗███████╗███████║███████║         ║
    ║    ╚═╝  ╚═╝ ╚═════╝ ╚═════╝╚══════╝╚══════╝╚══════╝         ║
    ║                                                              ║
    ║                    BEM-VINDO AO JOKEMPÔ!                     ║
    ║                                                              ║
    ╚══════════════════════════════════════════════════════════════╝
            ", ConsoleColor.Yellow);
            ConsoleHelper.Pausar();
        }

        private string LerNomeJogador(int numero, string[] nomesExistentes = null)
        {
            string nome;
            bool valido;
            do
            {
                valido = true;
                nome = ConsoleHelper.LerString($"\nDigite o nome do Jogador {numero}: ", ConsoleColor.Green);

                if (string.IsNullOrEmpty(nome))
                {
                    ConsoleHelper.EscreverLinha("Nome não pode ser vazio! Tente novamente.", ConsoleColor.Red);
                    valido = false;
                }
                else if (nome.Length < 2)
                {
                    ConsoleHelper.EscreverLinha("Nome deve ter pelo menos 2 caracteres!", ConsoleColor.Red);
                    valido = false;
                }
                else if (nome.Length > 20)
                {
                    ConsoleHelper.EscreverLinha("Nome deve ter no máximo 20 caracteres!", ConsoleColor.Red);
                    valido = false;
                }
                else if (nomesExistentes != null && nomesExistentes.Contains(nome, StringComparer.OrdinalIgnoreCase))
                {
                    ConsoleHelper.EscreverLinha("Já existe um jogador com esse nome! Escolha outro.", ConsoleColor.Red);
                    valido = false;
                }
            } while (!valido);

            return nome;
        }

        private void MostrarMenuPrincipal()
        {
            Console.Clear();
            ConsoleHelper.EscreverLinha($"┌────────────────────────────────────────┐", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"│           MENU PRINCIPAL               │", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"├────────────────────────────────────────┤", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"│  Jogador atual: {jogadorAtual.Nome.PadRight(22)}│", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"│  Adversário:     {jogador2.Nome.PadRight(22)}│", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"├────────────────────────────────────────┤", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"│  1 - Jogar uma rodada                  │", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"│  2 - Minhas estatísticas               │", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"│  3 - Adicionar segundo jogador         │", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"│  4 - Trocar de jogador                 │", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"│  5 - Estatísticas globais              │", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"│  0 - Sair do jogo                      │", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"└────────────────────────────────────────┘", ConsoleColor.Magenta);
        }

        private void AdicionarSegundoJogador()
        {
            if (_jogador2 != null && _jogador2.Nome != "CPU")
            {
                ConsoleHelper.EscreverLinha("\nJá existe um segundo jogador cadastrado!", ConsoleColor.Yellow);
                ConsoleHelper.Pausar();
                return;
            }

            string nome2 = LerNomeJogador(2, jogadores.Select(j => j.Nome).ToArray());
            var novoJogador = new Jogador(nome2);
            _jogador2 = novoJogador;

            
            bool cpuJaExistia = jogadores.Count > 1 && jogadores[1].Nome == "CPU";
            if (cpuJaExistia)
            {
                jogadores[1] = novoJogador;
            }
            else
            {
                jogadores.Add(novoJogador);
            }

            ConsoleHelper.EscreverLinha($"\nJogador {nome2} adicionado com sucesso!", ConsoleColor.Green);
            ConsoleHelper.Pausar();
        }

        private void JogarRodada()
        {
            Console.Clear();
            ConsoleHelper.EscreverLinha("\n═══════════════════════════════════════════════════", ConsoleColor.Yellow);
            ConsoleHelper.EscreverLinha("              NOVA RODADA - JOKEMPÔ", ConsoleColor.Yellow);
            ConsoleHelper.EscreverLinha("═══════════════════════════════════════════════════\n", ConsoleColor.Yellow);

            
            ConsoleHelper.EscreverLinha("Escolha sua jogada:", ConsoleColor.Cyan);
            ConsoleHelper.EscreverLinha("  1 - ✊ PEDRA", ConsoleColor.Cyan);
            ConsoleHelper.EscreverLinha("  2 - ✋ PAPEL", ConsoleColor.Cyan);
            ConsoleHelper.EscreverLinha("  3 - ✌ TESOURA", ConsoleColor.Cyan);

            Opcao jogadaJogador = LerJogadaValida(jogadorAtual.Nome);
            ConsoleHelper.EscreverLinha($"\n{jogadorAtual.Nome} escolheu: {ObterEmoji(jogadaJogador)} {jogadaJogador}", ConsoleColor.Green);

            
            Opcao jogadaAdversario;
            if (jogador2.Nome == "CPU")
            {
                Random random = new Random();
                jogadaAdversario = (Opcao)random.Next(1, 4);
                ConsoleHelper.EscreverLinha($"CPU escolheu: {ObterEmoji(jogadaAdversario)} {jogadaAdversario}", ConsoleColor.Red);
            }
            else
            {
                ConsoleHelper.EscreverLinha($"\nAgora é a vez do {jogador2.Nome}!", ConsoleColor.Yellow);
                jogadaAdversario = LerJogadaValida(jogador2.Nome);
                ConsoleHelper.EscreverLinha($"\n{jogador2.Nome} escolheu: {ObterEmoji(jogadaAdversario)} {jogadaAdversario}", ConsoleColor.Green);
            }

            
            ConsoleHelper.EscreverLinha("\n───────────────────────────────────────────", ConsoleColor.DarkGray);
            DeterminarResultado(jogadaJogador, jogadaAdversario);
            ConsoleHelper.EscreverLinha("───────────────────────────────────────────\n", ConsoleColor.DarkGray);

            ConsoleHelper.Pausar();
        }

        private Opcao LerJogadaValida(string nomeJogador)
        {
            int escolha = ConsoleHelper.LerInteiro($"\n{nomeJogador}, digite sua escolha (1-3): ", 1, 3);
            return (Opcao)escolha;
        }

        private string ObterEmoji(Opcao opcao)
        {
            return opcao switch
            {
                Opcao.Pedra => "✊",
                Opcao.Papel => "✋",
                Opcao.Tesoura => "✌",
                _ => "❓"
            };
        }

        private void DeterminarResultado(Opcao jogada1, Opcao jogada2)
        {
            bool empate = jogada1 == jogada2;
            bool jogador1Venceu = !empate && (
                (jogada1 == Opcao.Pedra && jogada2 == Opcao.Tesoura) ||
                (jogada1 == Opcao.Papel && jogada2 == Opcao.Pedra) ||
                (jogada1 == Opcao.Tesoura && jogada2 == Opcao.Papel));

            if (empate)
            {
                ConsoleHelper.EscreverLinha("              🤝 EMPATE! 🤝", ConsoleColor.Yellow);
                ConsoleHelper.EscreverLinha("         As duas jogadas são iguais!", ConsoleColor.Yellow);
                jogadorAtual.RegistrarEmpate();
                jogador2.RegistrarEmpate();
            }
            else if (jogador1Venceu)
            {
                ConsoleHelper.EscreverLinha($"        🎉 {jogadorAtual.Nome} VENCEU! 🎉", ConsoleColor.Green);
                ConsoleHelper.EscreverLinha($"    {ObterEmoji(jogada1)} {jogada1} vence {ObterEmoji(jogada2)} {jogada2}", ConsoleColor.Green);
                jogadorAtual.RegistrarVitoria();
                jogador2.RegistrarDerrota();
            }
            else
            {
                ConsoleHelper.EscreverLinha($"        💀 {jogador2.Nome} VENCEU! 💀", ConsoleColor.Red);
                ConsoleHelper.EscreverLinha($"    {ObterEmoji(jogada2)} {jogada2} vence {ObterEmoji(jogada1)} {jogada1}", ConsoleColor.Red);
                jogadorAtual.RegistrarDerrota();
                jogador2.RegistrarVitoria();
            }
        }

        private void MostrarEstatisticas()
        {
            Console.Clear();
            ConsoleHelper.EscreverLinha("\n╔══════════════════════════════════════════════════════════╗", ConsoleColor.Cyan);
            ConsoleHelper.EscreverLinha("║              📊 ESTATÍSTICAS DO JOGADOR 📊                 ║", ConsoleColor.Cyan);
            ConsoleHelper.EscreverLinha("╚══════════════════════════════════════════════════════════╝", ConsoleColor.Cyan);

            ConsoleHelper.EscreverLinha($"\nEstatísticas de: {jogadorAtual.Nome}");
            jogadorAtual.ExibirEstatisticas();

            ConsoleHelper.Pausar();
        }

        private void TrocarJogador()
        {
           
            var humanos = jogadores.Where(j => j.Nome != "CPU").ToList();
            if (humanos.Count < 2)
            {
                ConsoleHelper.EscreverLinha("\nÉ necessário pelo menos dois jogadores humanos para trocar.", ConsoleColor.Red);
                ConsoleHelper.Pausar();
                return;
            }

            ConsoleHelper.EscreverLinha("\n--- Jogadores disponíveis ---", ConsoleColor.Cyan);
            for (int i = 0; i < humanos.Count; i++)
            {
                string indicador = (humanos[i] == jogadorAtual) ? " (atual)" : (humanos[i] == jogador2 ? " (adversário)" : "");
                ConsoleHelper.EscreverLinha($"{i + 1} - {humanos[i].Nome}{indicador}", ConsoleColor.Yellow);
            }

            int escolha = ConsoleHelper.LerInteiro("Escolha o número do jogador que deseja controlar agora: ", 1, humanos.Count);
            Jogador novoAtual = humanos[escolha - 1];

            if (novoAtual == jogadorAtual)
            {
                ConsoleHelper.EscreverLinha("Você já é este jogador!", ConsoleColor.Yellow);
                ConsoleHelper.Pausar();
                return;
            }

            if (novoAtual == jogador2)
            {
                Jogador temp = _jogadorAtual;
                _jogadorAtual = _jogador2;
                _jogador2 = temp; 
                ConsoleHelper.EscreverLinha($"\nAgora você é {jogadorAtual.Nome} e o adversário é {jogador2.Nome}.", ConsoleColor.Green);
            }
            else
            {

                _jogadorAtual = novoAtual;

                ConsoleHelper.EscreverLinha($"\nAgora você é {jogadorAtual.Nome}. O adversário continua sendo {jogador2.Nome}.", ConsoleColor.Green);
            }
            ConsoleHelper.Pausar();
        }

        private void MostrarEstatisticasGlobais()
        {
            Console.Clear();
            ConsoleHelper.EscreverLinha("\n╔══════════════════════════════════════════════════════════╗", ConsoleColor.Yellow);
            ConsoleHelper.EscreverLinha("║           📈 ESTATÍSTICAS GLOBAIS DO JOGO 📈              ║", ConsoleColor.Yellow);
            ConsoleHelper.EscreverLinha("╚══════════════════════════════════════════════════════════╝", ConsoleColor.Yellow);

            foreach (var jogador in jogadores)
            {
                jogador.ExibirEstatisticas();
            }

            int totalVitorias = jogadores.Sum(j => j.Vitorias);
            int totalDerrotas = jogadores.Sum(j => j.Derrotas);
            int totalEmpates = jogadores.Sum(j => j.Empates);
            int totalPartidas = jogadores.Sum(j => j.Partidas);

            ConsoleHelper.EscreverLinha($"\n╔══════════════════════════════════════════╗", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"║           RESUMO DO JOGO                 ║", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"╠══════════════════════════════════════════╣", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"║  Total de Partidas: {totalPartidas.ToString().PadRight(22)}║", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"║  Total de Vitórias: {totalVitorias.ToString().PadRight(22)}║", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"║  Total de Derrotas: {totalDerrotas.ToString().PadRight(22)}║", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"║  Total de Empates:  {totalEmpates.ToString().PadRight(22)}║", ConsoleColor.Magenta);
            ConsoleHelper.EscreverLinha($"╚══════════════════════════════════════════╝", ConsoleColor.Magenta);

            ConsoleHelper.Pausar();
        }

        private void MostrarDespedida()
        {
            Console.Clear();
            ConsoleHelper.EscreverLinha(@"
    ╔══════════════════════════════════════════════════════════════╗
    ║                                                              ║
    ║           OBRIGADO POR JOGAR NOSSO JOKEMPÔ!                ║
    ║                                                              ║
    ║                       ATÉ LOGO! 👋                           ║
    ║                                                              ║
    ╚══════════════════════════════════════════════════════════════╝
            ", ConsoleColor.Yellow);
        }
    }
}
