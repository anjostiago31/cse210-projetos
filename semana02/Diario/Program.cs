using System;
using System.IO;
using System.Text;
using System.Text.Json;
public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Diario diario = new Diario();
        GeradorPerguntas gerador = new GeradorPerguntas();

        bool executando = true;

        while (executando)
        {
            Console.WriteLine();
            Console.WriteLine("Bem-vindo ao Diário!");
            Console.WriteLine("1. Escrever um novo registro");
            Console.WriteLine("2. Exibir o diário");
            Console.WriteLine("3. Salvar o diário");
            Console.WriteLine("4. Carregar o diário");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine() ?? "5";
            Console.WriteLine();

            try
            {
                switch (opcao)
                {
                    case "1":
                    {
                        string pergunta = gerador.ObterPerguntaAleatoria();

                        Console.WriteLine(pergunta);
                        Console.Write("> ");
                        string resposta = Console.ReadLine() ?? "";

                        if (string.IsNullOrWhiteSpace(resposta))
                        {
                            Console.WriteLine(
                                "Resposta vazia. O registro não foi adicionado.");
                            break;
                        }

                        Registro registro = new Registro
                        {
                            Data = DateTime.Now.ToString("dd/MM/yyyy"),
                            Pergunta = pergunta,
                            Resposta = resposta
                        };

                        diario.AdicionarRegistro(registro);

                        Console.WriteLine(
                            "Registro adicionado! Use a opção 3 para salvar em arquivo.");
                        break;
                    }

                    case "2":
                    {
                        diario.Exibir();
                        break;
                    }

                    case "3":
                    {
                        Console.Write("Nome do arquivo (exemplo: diario.json): ");
                        string nomeArquivo = Console.ReadLine() ?? "";

                        if (string.IsNullOrWhiteSpace(nomeArquivo))
                        {
                            Console.WriteLine("Informe um nome de arquivo.");
                            break;
                        }

                        diario.Salvar(nomeArquivo);
                        Console.WriteLine("Diário salvo com sucesso!");
                        break;
                    }

                    case "4":
                    {
                        Console.Write("Nome do arquivo para carregar: ");
                        string nomeArquivo = Console.ReadLine() ?? "";

                        if (string.IsNullOrWhiteSpace(nomeArquivo))
                        {
                            Console.WriteLine("Informe um nome de arquivo.");
                            break;
                        }

                        diario.Carregar(nomeArquivo);
                        Console.WriteLine("Diário carregado com sucesso!");
                        break;
                    }

                    case "5":
                    {
                        executando = false;
                        Console.WriteLine("Até a próxima!");
                        break;
                    }

                    default:
                    {
                        Console.WriteLine("Opção inválida. Escolha de 1 a 5.");
                        break;
                    }
                }
            }
            catch (JsonException)
            {
                Console.WriteLine(
                    "O arquivo não contém um diário JSON válido. " +
                    "Os registros atuais foram mantidos.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Você não tem permissão para acessar esse arquivo.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Não foi possível acessar o arquivo: {ex.Message}");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("O nome ou caminho do arquivo é inválido.");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("O formato do caminho informado não é suportado.");
            }
        }
    }
}