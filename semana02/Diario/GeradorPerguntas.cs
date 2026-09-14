using System;
using System.Collections.Generic;

public class GeradorPerguntas
{
    private readonly List<string> _perguntas = new List<string>
    {
        "Quem foi a pessoa mais interessante com quem interagi hoje?",
        "Qual foi a melhor parte do meu dia?",
        "Como vi a mão do Senhor em minha vida hoje?",
        "Qual foi a emoção mais forte que senti hoje?",
        "O que eu faria diferente se pudesse repetir este dia?",
        "Que pequena conquista tive hoje?",
        "O que aprendi hoje que quero levar para amanhã?"
    };

    private readonly Random _aleatorio = new Random();

    public string ObterPerguntaAleatoria()
    {
        int indice = _aleatorio.Next(_perguntas.Count);
        return _perguntas[indice];
    }
}