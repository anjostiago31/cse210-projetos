
using System;
using System.Collections.Generic;
using System.IO;

public class GerenciadorDeMetas
{
    private List<Meta> _metas;
    private int _pontuacao;

    public GerenciadorDeMetas()
    {
        _metas = new List<Meta>();
        _pontuacao = 0;
    }

    public void AdicionarMeta(Meta meta)
    {
        _metas.Add(meta);
        Console.WriteLine("Meta adicionada com sucesso!");
    }

    public void MostrarPontuacao()
    {
        Console.WriteLine($"\nPontuação atual: {_pontuacao}");
        Console.WriteLine($"Nível: {ObterNivel()}");
    }

    // CRIATIVIDADE - REQUISITOS ADICIONAIS:
    // Foi implementado um sistema de níveis baseado na
    // pontuação acumulada pelo usuário.
    //
    // Conforme o usuário realiza suas metas e ganha pontos,
    // ele pode avançar pelos níveis:
    // Iniciante, Aprendiz, Discípulo, Perseverante
    // e Mestre das Metas.
    //
    // O programa também exibe uma mensagem de parabéns
    // quando o usuário alcança um novo nível.
    //
    // Esse recurso de gamificação vai além dos requisitos
    // básicos e incentiva o usuário a continuar realizando
    // suas metas pessoais.

    private string ObterNivel()
    {
        if (_pontuacao >= 4000)
            return "Mestre das Metas";
        else if (_pontuacao >= 2000)
            return "Perseverante";
        else if (_pontuacao >= 1000)
            return "Discípulo";
        else if (_pontuacao >= 500)
            return "Aprendiz";
        else
            return "Iniciante";
    }

    public void ListarMetas()
    {
        Console.WriteLine("\n=== MINHAS METAS ===");

        if (_metas.Count == 0)
        {
            Console.WriteLine("Nenhuma meta cadastrada.");
            return;
        }

        for (int i = 0; i < _metas.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_metas[i].ObterDetalhes()}"
            );
        }
    }

    public void RegistrarMeta(int indice)
    {
        if (indice < 0 || indice >= _metas.Count)
        {
            Console.WriteLine("Meta inválida!");
            return;
        }

        string nivelAnterior = ObterNivel();

        int pontosGanhos = _metas[indice].RegistrarEvento();

        _pontuacao += pontosGanhos;

        Console.WriteLine(
            $"Você ganhou {pontosGanhos} pontos!"
        );

        if (nivelAnterior != ObterNivel())
        {
            Console.WriteLine(
                $"Parabéns! Seu novo nível é: {ObterNivel()}!"
            );
        }
    }

    
public void CriarMeta()
{
    Console.WriteLine("\n=== CRIAR NOVA META ===");
    Console.WriteLine("1. Meta Simples");
    Console.WriteLine("2. Meta Eterna");
    Console.WriteLine("3. Meta Checklist");

    Console.Write("\nEscolha o tipo de meta: ");

    if (!int.TryParse(Console.ReadLine(), out int tipo)
        || tipo < 1 || tipo > 3)
    {
        Console.WriteLine("Tipo de meta inválido!");
        return;
    }

    Console.Write("Nome da meta: ");
    string nome = Console.ReadLine() ?? "";

    Console.Write("Descrição da meta: ");
    string descricao = Console.ReadLine() ?? "";

    Console.Write("Quantos pontos vale cada realização? ");

    if (!int.TryParse(Console.ReadLine(), out int pontos)
        || pontos <= 0)
    {
        Console.WriteLine("Digite uma pontuação positiva!");
        return;
    }

    Meta novaMeta;

    switch (tipo)
    {
        case 1:
            novaMeta = new MetaSimples(nome, descricao, pontos);
            break;

        case 2:
            novaMeta = new MetaEterna(nome, descricao, pontos);
            break;

        case 3:
            Console.Write("Quantas vezes deve ser realizada? ");

            if (!int.TryParse(Console.ReadLine(), out int quantidade)
                || quantidade <= 0)
            {
                Console.WriteLine("Quantidade inválida!");
                return;
            }

            Console.Write("Quantos pontos de bônus ao concluir? ");

            if (!int.TryParse(Console.ReadLine(), out int bonus)
                || bonus < 0)
            {
                Console.WriteLine("Bônus inválido!");
                return;
            }

            novaMeta = new MetaChecklist(
                nome, descricao, pontos, quantidade, bonus);
            break;

        default:
            return;
    }

    AdicionarMeta(novaMeta);
}


public void SalvarMetas()
{
    Console.Write("\nDigite o nome do arquivo para salvar: ");
    string arquivo = Console.ReadLine() ?? "";

    if (string.IsNullOrWhiteSpace(arquivo))
    {
        Console.WriteLine("Nome do arquivo inválido!");
        return;
    }

    try
    {
        using (StreamWriter writer = new StreamWriter(arquivo))
        {
            // Salva a pontuação atual
            writer.WriteLine(_pontuacao);

            // Salva todas as metas
            foreach (Meta meta in _metas)
            {
                writer.WriteLine(meta.ObterDadosParaSalvar());
            }
        }

        Console.WriteLine("Metas salvas com sucesso!");
    }
    catch (IOException)
    {
        Console.WriteLine("Erro ao salvar o arquivo.");
    }
    catch (UnauthorizedAccessException)
    {
        Console.WriteLine("Sem permissão para salvar o arquivo.");
    }
}


public void CarregarMetas()
{
    Console.Write("\nDigite o nome do arquivo para carregar: ");
    string arquivo = Console.ReadLine() ?? "";

    if (!File.Exists(arquivo))
    {
        Console.WriteLine("Arquivo não encontrado!");
        return;
    }

    try
    {
        string[] linhas = File.ReadAllLines(arquivo);

        if (linhas.Length == 0)
        {
            Console.WriteLine("O arquivo está vazio!");
            return;
        }

        int pontuacaoCarregada = int.Parse(linhas[0]);
        List<Meta> metasCarregadas = new List<Meta>();

        for (int i = 1; i < linhas.Length; i++)
        {
            string[] dados = linhas[i].Split('|');

            Meta meta;

            switch (dados[0])
            {
                case "Simples":
                    MetaSimples simples = new MetaSimples(
                        dados[1],
                        dados[2],
                        int.Parse(dados[3])
                    );

                    simples.DefinirConclusao(
                        bool.Parse(dados[4])
                    );

                    meta = simples;
                    break;

                case "Eterna":
                    meta = new MetaEterna(
                        dados[1],
                        dados[2],
                        int.Parse(dados[3])
                    );
                    break;

                case "Checklist":
                    MetaChecklist checklist = new MetaChecklist(
                        dados[1],
                        dados[2],
                        int.Parse(dados[3]),
                        int.Parse(dados[4]),
                        int.Parse(dados[5])
                    );

                    checklist.DefinirProgresso(
                        int.Parse(dados[6])
                    );

                    meta = checklist;
                    break;

                default:
                    throw new FormatException(
                        "Tipo de meta desconhecido."
                    );
            }

            metasCarregadas.Add(meta);
        }

        _pontuacao = pontuacaoCarregada;
        _metas = metasCarregadas;

        Console.WriteLine("Metas carregadas com sucesso!");
    }
    catch (Exception ex) when (
        ex is IOException ||
        ex is UnauthorizedAccessException ||
        ex is FormatException ||
        ex is IndexOutOfRangeException ||
        ex is OverflowException ||
        ex is ArgumentException)
    {
        Console.WriteLine(
            $"Não foi possível carregar as metas: {ex.Message}"
        );
    }
}

}
