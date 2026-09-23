// CRIATIVIDADE E RECURSOS ADICIONAIS:
// Para ir além dos requisitos básicos, o programa utiliza um arquivo CSV
// contendo uma biblioteca com várias escrituras do Livro de Mórmon.
// O programa lê as escrituras do arquivo e seleciona uma delas aleatoriamente
// a cada execução.
//
// Além disso, o programa seleciona para esconder apenas palavras que ainda
// estão visíveis, evitando escolher novamente palavras que já foram escondidas.
//
// Também foi adicionado um sistema de progresso que mostra ao usuário quantas
// palavras já foram escondidas e o total de palavras da escritura.
class Program
{
    static void Main(string[] args)
    {
        List<Escritura> escrituras = new List<Escritura>();

        string[] linhas = File.ReadAllLines("escrituras.csv");

        for (int i = 1; i < linhas.Length; i++)
        {

            if (string.IsNullOrWhiteSpace(linhas[i]))
            {
                continue;
            }

            string[] partes = linhas[i].Split(',');

            string livro = partes[0];
            int capitulo = int.Parse(partes[1]);
            int versiculoInicial = int.Parse(partes[2]);
            int versiculoFinal = int.Parse(partes[3]);
            string texto = partes[4];

            Referencia referencia;


            if (versiculoInicial == versiculoFinal)
            {
                referencia = new Referencia(
                    livro,
                    capitulo,
                    versiculoInicial
                );
            }
            else
            {
                referencia = new Referencia(
                    livro,
                    capitulo,
                    versiculoInicial,
                    versiculoFinal
                );
            }

            Escritura novaEscritura = new Escritura(
                referencia,
                texto
            );

            escrituras.Add(novaEscritura);
        }

        Random random = new Random();

        int indice = random.Next(escrituras.Count);

        Escritura escritura = escrituras[indice];

        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== MEMORIZADOR DE ESCRITURAS ===");
            Console.WriteLine();

            Console.WriteLine(escritura.ObterTextoExibicao());

            if (escritura.EstaCompletamenteEscondida())
            {
                Console.WriteLine();
                Console.WriteLine("Parabéns! Você completou a escritura!");
                break;
            }

            Console.WriteLine();

            Console.WriteLine(
                $"Progresso: {escritura.ObterQuantidadeEscondida()} de " +
                $"{escritura.ObterTotalPalavras()} palavras escondidas."
            );

            Console.WriteLine();
            Console.WriteLine("Pressione Enter para esconder palavras");
            Console.WriteLine("ou digite 'sair' para encerrar.");
            Console.Write("> ");

            string entrada = Console.ReadLine() ?? "";

            if (entrada.ToLower() == "sair")
            {
                break;
            }
            escritura.EsconderPalavrasAleatorias(3);
        }
    }
}