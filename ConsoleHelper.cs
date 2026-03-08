using System;

namespace Jokempo
{
    public static class ConsoleHelper
    {
        public static void EscreverLinha(string mensagem, ConsoleColor cor = ConsoleColor.Gray)
        { 
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.RestColor();
        }

        public static void Escrever(string mensagem, ConsoleColor cor = ConsoleColor.Gray)
        { 
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.RestColor();
        }

        public static void LerString(string prompt, ConsoleColor cor = ConsoleColor.Gray)
        { 
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.RestColor();
        }

        public static void LerString(string prompt, ConsoleColor cor = ConsoleColor.Green)
        { 
            Escrever(prompt, cor);
            return Console.ReadLine()?.Trim() ?? "";
        }

        public static int LerInteiro(string prompt, int min, int max, ConsoleColor cor = ConsoleColor.Green)
        {
            int valor;
            while (true)
            {
                Escrever(prompt, cor);
                string entrada = Console.ReadLine() ?? "";
                if (int.TryParse(entrada, out valor) && valor >= min && valor <= max)
                    return valor;

                EscreverLinha($"Entrada inválida! Digite um número entre {min} e {max}.", ConsoleColor.Red);
            }
        }

        public static bool LerSimNao(string prompt, ConsoleColor cor = ConsoleColor.Cyan)
        {
            while (true)
            {
                string resposta = LerString(prompt, cor).ToUpper();
                if (resposta == "S" || resposta == "SIM")
                    return true;
                if (resposta == "N" || resposta == "NÃO" || resposta == "NAO")
                    return false;

                EscreverLinha("Resposta inválida! Digite S (Sim) ou N (Não).", ConsoleColor.Red);
            }
        }

        public static void Pausar(string mensagem = "Pressione ENTER para continuar...")
        {
            EscreverLinha($"\n{mensagem}", ConsoleColor.DarkGray);
            Console.ReadLine();
        }
    }
}       