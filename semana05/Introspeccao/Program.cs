using System;

class Program
{
    static void Main(string[] args)
    {
        string opcao = "";

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
            }
            else if (opcao == "2")
            {
                AtividadeReflexao atividade =
                    new AtividadeReflexao();

                atividade.Executar();
            }
            else if (opcao == "3")
            {
                AtividadeListagem atividade =
                    new AtividadeListagem();

                atividade.Executar();
            }
            else if (opcao == "4")
            {
                Console.WriteLine("\nObrigado por utilizar o programa!");
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