
using System;

class Program
{
    static void Main(string[] args)
    {
        GerenciadorDeMetas gerenciador = new GerenciadorDeMetas();

        int opcao = 0;

        while (opcao != 7)
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("     PROGRAMA DE METAS ETERNAS");
            Console.WriteLine("==================================");

            // Mostra a pontuação e o nível do usuário
            gerenciador.MostrarPontuacao();

            Console.WriteLine("\nMenu de opções:");
            Console.WriteLine("1. Criar uma nova meta");
            Console.WriteLine("2. Listar minhas metas");
            Console.WriteLine("3. Registrar uma meta realizada");
            Console.WriteLine("4. Mostrar minha pontuação");
            Console.WriteLine("5. Salvar metas");
            Console.WriteLine("6. Carregar metas");
            Console.WriteLine("7. Sair");

            Console.Write("\nEscolha uma opção: ");

            // Verifica se o usuário digitou um número válido
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Digite um número válido!");

                Console.WriteLine(
                    "\nPressione Enter para continuar..."
                );
                Console.ReadLine();

                continue;
            }

            switch (opcao)
            {
                case 1:
                    // Criar uma nova meta
                    gerenciador.CriarMeta();
                    break;

                case 2:
                    // Mostrar todas as metas cadastradas
                    gerenciador.ListarMetas();
                    break;

                case 3:
                    // Registrar uma meta realizada
                    gerenciador.ListarMetas();

                    Console.Write("\nDigite o número da meta: ");

                    if (int.TryParse(Console.ReadLine(), out int numero))
                    {
                        gerenciador.RegistrarMeta(numero - 1);
                    }
                    else
                    {
                        Console.WriteLine("Número inválido!");
                    }
                    break;

                case 4:
                    // Mostrar pontuação e nível
                    gerenciador.MostrarPontuacao();
                    break;

                case 5:
                    // Salvar metas e pontuação
                    gerenciador.SalvarMetas();
                    break;

                case 6:
                     // Carregar metas e pontuação
                    gerenciador.CarregarMetas();
                    break;

                case 7:
                    // Encerrar o programa
                    Console.WriteLine(
                        "\nObrigado por utilizar o Programa de Metas Eternas!"
                    );
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            // Aguarda o usuário antes de voltar ao menu
            if (opcao != 7)
            {
                Console.WriteLine(
                    "\nPressione Enter para voltar ao menu..."
                );

                Console.ReadLine();
            }
        }
    }
}
