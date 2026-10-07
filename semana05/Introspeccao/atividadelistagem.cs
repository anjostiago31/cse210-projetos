using System;
using System.Collections.Generic;

public class AtividadeListagem : Atividade
{
    private List<string> _mensagens;
    private Random _random = new Random();

    public AtividadeListagem()
        : base(
            "Atividade de Listagem",
            "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, " +
            "fazendo com que você liste o máximo de coisas que puder em uma determinada área."
        )
    {
        _mensagens = new List<string>()
        {
            "Quem são as pessoas que você aprecia?",
            "Quais são seus pontos fortes pessoais?",
            "Quem são as pessoas que você ajudou esta semana?",
            "Quando você sentiu o Espírito Santo neste mês?",
            "Quem são alguns dos seus heróis pessoais?"
        };
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        Console.WriteLine("\nListe quantas respostas você puder para a seguinte pergunta:\n");

        string mensagem =
            _mensagens[_random.Next(_mensagens.Count)];

        Console.WriteLine($"--- {mensagem} ---");

        Console.Write("\nVocê pode começar em: ");

        MostrarContagemRegressiva(5);

        Console.WriteLine();

        int quantidade = 0;

        DateTime tempoFinal =
            DateTime.Now.AddSeconds(ObterDuracao());

        while (DateTime.Now < tempoFinal)
        {
            Console.Write("> ");

            Console.ReadLine();

            quantidade++;
        }

        Console.WriteLine(
            $"\nVocê listou {quantidade} itens!"
        );

        ExibirMensagemFinal();
    }
}