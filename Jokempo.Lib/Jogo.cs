using System.Collections.Generic;
using System.Linq;

namespace Jokempo.Lib
{
    public class Jogo
    {
        private List<Jogador> _jogadores = new();
        private Jogador _jogadorAtual;
        private Jogador _adversario;

        public IReadOnlyList<Jogador> Jogadores => _jogadores;
        public Jogador JogadorAtual => _jogadorAtual;
        public Jogador Adversario => _adversario;

        public Jogo(string nomeJogador1, bool contraCPU)
        {
            _jogadorAtual = new Jogador(nomeJogador1);
            _jogadores.Add(_jogadorAtual);

            if (contraCPU)
                _adversario = new Jogador("CPU");
            else
                throw new InvalidOperationException("Para dois jogadores humanos, use o construtor adequado.");
        }

        public Jogo(string nomeJogador1, string nomeJogador2)
        {
            _jogadorAtual = new Jogador(nomeJogador1);
            _adversario = new Jogador(nomeJogador2);
            _jogadores.AddRange(new[] { _jogadorAtual, _adversario });
        }

        public void AdicionarJogadorHumano(string nome)
        {
            if (_jogadores.Any(j => j.Nome.Equals(nome, System.StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Jogador já existe.");

            var novo = new Jogador(nome);
            _jogadores.Add(novo);
            // Se adversário era CPU, substitui
            if (_adversario.Nome == "CPU")
                _adversario = novo;
        }

        public bool TrocarJogador(string nome)
        {
            var jogador = _jogadores.FirstOrDefault(j => j.Nome.Equals(nome, System.StringComparison.OrdinalIgnoreCase) && j.Nome != "CPU");
            if (jogador == null || jogador == _jogadorAtual) return false;

            // Se for o adversário atual, apenas troca as referências
            if (jogador == _adversario)
            {
                (_jogadorAtual, _adversario) = (_adversario, _jogadorAtual);
            }
            else
            {
                _jogadorAtual = jogador;
                // adversário permanece o mesmo
            }
            return true;
        }

        public Rodada CriarRodada() => new(_jogadorAtual, _adversario);

        // Para CPU, gera jogada aleatória
        public Opcao JogadaCPU()
        {
            var random = new System.Random();
            return (Opcao)random.Next(1, 4);
        }
    }
}