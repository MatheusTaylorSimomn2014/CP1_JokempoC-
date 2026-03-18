namespace Jokempo.WinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {

            this.Text = "Jokempo";
            this.Size = new System.Drawing.Size(800, 450);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.lblJogadorAtual = new System.Windows.Forms.Label();
            this.lblAdversario = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();

            this.btnPedra = new System.Windows.Forms.Button();
            this.btnPapel = new System.Windows.Forms.Button();
            this.btnTesoura = new System.Windows.Forms.Button();
            this.btnTrocar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnEstatisticas = new System.Windows.Forms.Button();

            this.listBoxEstatisticas = new System.Windows.Forms.ListBox();

            this.SuspendLayout();

            this.lblJogadorAtual.AutoSize = true;
            this.lblJogadorAtual.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblJogadorAtual.Location = new System.Drawing.Point(30, 30);
            this.lblJogadorAtual.Name = "lblJogadorAtual";
            this.lblJogadorAtual.Size = new System.Drawing.Size(150, 28);
            this.lblJogadorAtual.Text = "Jogador: ...";

            this.lblAdversario.AutoSize = true;
            this.lblAdversario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAdversario.Location = new System.Drawing.Point(30, 70);
            this.lblAdversario.Name = "lblAdversario";
            this.lblAdversario.Size = new System.Drawing.Size(150, 28);
            this.lblAdversario.Text = "Adversário: ...";

            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblResultado.ForeColor = System.Drawing.Color.Blue;
            this.lblResultado.Location = new System.Drawing.Point(30, 120);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(200, 32);
            this.lblResultado.Text = "Resultado: ...";

            this.btnPedra.Text = "✊ Pedra";
            this.btnPedra.Location = new System.Drawing.Point(30, 180);
            this.btnPedra.Size = new System.Drawing.Size(100, 50);
            this.btnPedra.UseVisualStyleBackColor = true;
            this.btnPedra.Click += new System.EventHandler(this.btnPedra_Click);

            this.btnPapel.Text = "✋ Papel";
            this.btnPapel.Location = new System.Drawing.Point(140, 180);
            this.btnPapel.Size = new System.Drawing.Size(100, 50);
            this.btnPapel.UseVisualStyleBackColor = true;
            this.btnPapel.Click += new System.EventHandler(this.btnPapel_Click);

            this.btnTesoura.Text = "✌ Tesoura";
            this.btnTesoura.Location = new System.Drawing.Point(250, 180);
            this.btnTesoura.Size = new System.Drawing.Size(100, 50);
            this.btnTesoura.UseVisualStyleBackColor = true;
            this.btnTesoura.Click += new System.EventHandler(this.btnTesoura_Click);

            this.btnTrocar.Text = "🔄 Trocar Jogador";
            this.btnTrocar.Location = new System.Drawing.Point(30, 250);
            this.btnTrocar.Size = new System.Drawing.Size(150, 40);
            this.btnTrocar.UseVisualStyleBackColor = true;
            this.btnTrocar.Click += new System.EventHandler(this.btnTrocarJogador_Click);

            this.btnAdicionar.Text = "➕ Adicionar Humano";
            this.btnAdicionar.Location = new System.Drawing.Point(200, 250);
            this.btnAdicionar.Size = new System.Drawing.Size(150, 40);
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionarHumano_Click);

            this.btnEstatisticas.Text = "📊 Estatísticas Globais";
            this.btnEstatisticas.Location = new System.Drawing.Point(370, 250);
            this.btnEstatisticas.Size = new System.Drawing.Size(150, 40);
            this.btnEstatisticas.UseVisualStyleBackColor = true;
            this.btnEstatisticas.Click += new System.EventHandler(this.btnEstatisticas_Click);

            this.listBoxEstatisticas.Location = new System.Drawing.Point(30, 310);
            this.listBoxEstatisticas.Size = new System.Drawing.Size(490, 100);
            this.listBoxEstatisticas.TabIndex = 0;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Controls.Add(this.listBoxEstatisticas);
            this.Controls.Add(this.btnEstatisticas);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnTrocar);
            this.Controls.Add(this.btnTesoura);
            this.Controls.Add(this.btnPapel);
            this.Controls.Add(this.btnPedra);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.lblAdversario);
            this.Controls.Add(this.lblJogadorAtual);
            this.Name = "Form1";
            this.Text = "Jokempo";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblJogadorAtual;
        private System.Windows.Forms.Label lblAdversario;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button btnPedra;
        private System.Windows.Forms.Button btnPapel;
        private System.Windows.Forms.Button btnTesoura;
        private System.Windows.Forms.Button btnTrocar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnEstatisticas;
        private System.Windows.Forms.ListBox listBoxEstatisticas;
    }
}