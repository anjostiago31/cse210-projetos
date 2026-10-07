using System;

class Program
{
    static void Main(string[] args)
    {
        // Para superar os requisitos básicos, o programa mantém um registro
        // de quantas vezes cada tipo de atividade foi realizado durante a sessão.
        // Ao sair, o usuário recebe um resumo mostrando a quantidade de atividades
        // de respiração, reflexão e listagem concluídas, além do total realizado.

        string opcao = "";

        int totalRespiracao = 0;
        int totalReflexao = 0;
        int totalListagem = 0;

        while (opcao != "4")
        {
            Console.Clear();

            Console.WriteLine("Menu de Opções:");
            Console.WriteLine("  1. Iniciar atividade de respiração");
            Console.WriteLine("  2. Iniciar atividade de reflexão");
            Console.WriteLine("  3. Iniciar atividade de listagem");
            Console.WriteLine("  4. Sair");

            Console.Write("Selecione uma opção do menu: ");

            opcao = Console.ReadLine();

            if (opcao == "1")
            {
                AtividadeRespiracao atividade =
                    new AtividadeRespiracao();

                atividade.Executar();

                totalRespiracao++;
            }
            else if (opcao == "2")
            {
                AtividadeReflexao atividade =
                    new AtividadeReflexao();

                atividade.Executar();

                totalReflexao++;
            }
            else if (opcao == "3")
            {
                AtividadeListagem atividade =
                    new AtividadeListagem();

                atividade.Executar();

                totalListagem++;
            }
            else if (opcao == "4")
            {
                int totalAtividades =
                    totalRespiracao + totalReflexao + totalListagem;

                Console.WriteLine("\nResumo da sua sessão:\n");

                Console.WriteLine(
                    $"Atividade de Respiração: {totalRespiracao} vez(es)"
                );

                Console.WriteLine(
                    $"Atividade de Reflexão: {totalReflexao} vez(es)"
                );

                Console.WriteLine(
                    $"Atividade de Listagem: {totalListagem} vez(es)"
                );

                Console.WriteLine(
                    $"\nTotal de atividades realizadas: {totalAtividades}"
                );

                Console.WriteLine(
                    "\nObrigado por utilizar o programa!"
                );
            }
            else
            {
                Console.WriteLine("\nOpção inválida.");
                Console.WriteLine("Pressione Enter para continuar.");
                Console.ReadLine();
            }
        }
    }
}