using System;
using System.Threading;

public class Atividade
{
    private string _nome;
    private string _descricao;
    private int _duracao;

    public Atividade(string nome, string descricao)
    {
        _nome = nome;
        _descricao = descricao;
    }

    public void ExibirMensagemInicial()
    {
        Console.Clear();

        Console.WriteLine($"Bem-vindo à {_nome}.\n");

        Console.WriteLine(_descricao);

        Console.Write("\nQuanto tempo, em segundos, você gostaria para sua sessão? ");
        _duracao = int.Parse(Console.ReadLine());

        Console.Clear();

        Console.WriteLine("Prepare-se para começar...");
        MostrarSpinner(3);
    }

    public void ExibirMensagemFinal()
    {
        Console.WriteLine("\nMuito bem!");
        MostrarSpinner(2);

        Console.WriteLine(
            $"\nVocê concluiu {_duracao} segundos da {_nome}."
        );

        MostrarSpinner(3);
    }

    public void MostrarSpinner(int segundos)
    {
        DateTime tempoFinal = DateTime.Now.AddSeconds(segundos);

        string[] spinner =
        {
            "|", "/", "-", "\\"
        };

        int i = 0;

        while (DateTime.Now < tempoFinal)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;

            if (i >= spinner.Length)
            {
                i = 0;
            }
        }
    }

    public void MostrarContagemRegressiva(int segundos)
    {
        for (int i = segundos; i > 0; i--)
        {
            Console.Write(i);

            Thread.Sleep(1000);

            Console.Write("\b \b");
        }
    }

    public int ObterDuracao()
    {
        return _duracao;
    }

    public string ObterNome()
    {
        return _nome;
    }
}