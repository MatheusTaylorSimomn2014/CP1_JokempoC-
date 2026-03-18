using Jokempo.Lib;

namespace Jokempo.WinForms
{
    public partial class Form1 : Form
    {
        private Jogo _jogo;
        private Rodada? _rodadaAtual;

        public Form1()
        {
            InitializeComponent();
            InicializarJogo();
        }

        private void InicializarJogo()
        {

            string nome = Microsoft.VisualBasic.Interaction.InputBox("Nome do jogador:", "Novo Jogo", "Jogador1");
            if (string.IsNullOrWhiteSpace(nome)) nome = "Jogador1";

            var contraCPU = MessageBox.Show("Jogar contra CPU?", "Modo", MessageBoxButtons.YesNo) == DialogResult.Yes;

            if (contraCPU)
                _jogo = new Jogo(nome, contraCPU: true);
            else
            {
                string nome2 = Microsoft.VisualBasic.Interaction.InputBox("Nome do segundo jogador:", "Novo Jogo", "Jogador2");
                _jogo = new Jogo(nome, nome2 ?? "Jogador2");
            }

            AtualizarInterface();
        }

        private void AtualizarInterface()
        {
            lblJogadorAtual.Text = $"Jogador: {_jogo.JogadorAtual.Nome}";
            lblAdversario.Text = $"Adversário: {_jogo.Adversario.Nome}";

        }

        private void btnPedra_Click(object sender, EventArgs e) => Jogar(Opcao.Pedra);
        private void btnPapel_Click(object sender, EventArgs e) => Jogar(Opcao.Papel);
        private void btnTesoura_Click(object sender, EventArgs e) => Jogar(Opcao.Tesoura);

        private void Jogar(Opcao escolhaJogador)
        {
            _rodadaAtual = _jogo.CriarRodada();
            Opcao escolhaAdversario;

            if (_jogo.Adversario.Nome == "CPU")
                escolhaAdversario = _jogo.JogadaCPU();
            else
            {
                escolhaAdversario = (Opcao)new Random().Next(1, 4);
                MessageBox.Show($"Vez do {_jogo.Adversario.Nome} – jogada simulada: {escolhaAdversario}");
            }

            _rodadaAtual.Jogar(escolhaJogador, escolhaAdversario);

            // Exibe resultado
            string resultado;
            if (_rodadaAtual.Empate)
                resultado = "🤝 Empate!";
            else
                resultado = $"🏆 Vencedor: {_rodadaAtual.Vencedor!.Nome}";

            lblResultado.Text = resultado;
            AtualizarEstatisticas();
        }

        private void AtualizarEstatisticas()
        {
            listBoxEstatisticas.Items.Clear();
            foreach (var j in _jogo.Jogadores)
                listBoxEstatisticas.Items.Add(EstatisticasHelper.ResumoJogador(j));
        }

        private void btnTrocarJogador_Click(object sender, EventArgs e)
        {
            var humanos = _jogo.Jogadores.Where(j => j.Nome != "CPU").ToList();
            if (humanos.Count < 2)
            {
                MessageBox.Show("É necessário pelo menos dois humanos para trocar.");
                return;
            }

            using var form = new Form();
            form.Text = "Selecione o jogador";
            var listBox = new ListBox { Dock = DockStyle.Fill };
            listBox.Items.AddRange(humanos.Select(j => j.Nome).ToArray());
            listBox.SelectedIndexChanged += (s, ev) =>
            {
                if (listBox.SelectedItem is string nome)
                {
                    _jogo.TrocarJogador(nome);
                    AtualizarInterface();
                    form.Close();
                }
            };
            form.Controls.Add(listBox);
            form.ShowDialog();
        }

        private void btnAdicionarHumano_Click(object sender, EventArgs e)
        {
            string nome = Microsoft.VisualBasic.Interaction.InputBox("Nome do novo jogador:", "Adicionar");
            if (!string.IsNullOrWhiteSpace(nome))
            {
                try
                {
                    _jogo.AdicionarJogadorHumano(nome);
                    AtualizarEstatisticas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void InitializeComponent()
        {

        }
    }
}