using System;
using System.Collections.Generic;

public class AtividadeReflexao : Atividade
{
    private List<string> _mensagens;
    private List<string> _perguntas;

    private Random _random = new Random();

    public AtividadeReflexao()
        : base(
            "Atividade de Reflexão",
            "Esta atividade ajudará você a refletir sobre momentos da sua vida " +
            "em que você demonstrou força e resiliência. Isso ajudará você a " +
            "reconhecer o poder que você tem e como pode usá-lo em outros aspectos da sua vida."
        )
    {
        _mensagens = new List<string>()
        {
            "Pense em uma ocasião em que você defendeu outra pessoa.",
            "Pense em uma ocasião em que você fez algo realmente difícil.",
            "Pense em uma ocasião em que você ajudou alguém necessitado.",
            "Pense em uma ocasião em que você fez algo verdadeiramente altruísta."
        };

        _perguntas = new List<string>()
        {
            "Por que essa experiência foi significativa para você?",
            "Você já fez algo assim antes?",
            "Como você começou?",
            "Como você se sentiu quando terminou?",
            "O que tornou esse momento diferente de outras vezes em que você não teve tanto sucesso?",
            "Qual é a sua coisa favorita sobre essa experiência?",
            "O que você pode aprender com essa experiência que se aplica a outras situações?",
            "O que você aprendeu sobre si mesmo por meio dessa experiência?",
            "Como você pode manter essa experiência em mente no futuro?"
        };
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        Console.WriteLine("\nConsidere a seguinte mensagem:\n");

        string mensagem =
            _mensagens[_random.Next(_mensagens.Count)];

        Console.WriteLine($"--- {mensagem} ---");

        Console.WriteLine(
            "\nQuando tiver algo em mente, pressione Enter para continuar."
        );

        Console.ReadLine();

        Console.WriteLine(
            "Agora reflita sobre cada uma das seguintes perguntas."
        );

        Console.Write("Você pode começar em: ");

        MostrarContagemRegressiva(5);

        Console.Clear();

        DateTime tempoFinal =
            DateTime.Now.AddSeconds(ObterDuracao());

        while (DateTime.Now < tempoFinal)
        {
            string pergunta =
                _perguntas[_random.Next(_perguntas.Count)];

            Console.Write($"> {pergunta} ");

            MostrarSpinner(5);

            Console.WriteLine();
        }

        ExibirMensagemFinal();
    }
}