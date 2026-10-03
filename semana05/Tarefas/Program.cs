using System;

class Program
{
    static void Main(string[] args)
    {
        // Tarefa simples
        Tarefa tarefa = new Tarefa(
            "Tiago dos Anjos",
            "Multiplicação"
        );

        Console.WriteLine(tarefa.ObterResumo());

        Console.WriteLine();

        // Tarefa de Matemática
        TarefaDeMatematica matematica = new TarefaDeMatematica(
            "Tiago dos Anjos",
            "Frações",
            "7.3",
            "8-19"
        );

        Console.WriteLine(matematica.ObterResumo());
        Console.WriteLine(matematica.ObterListaDeTarefas());

        Console.WriteLine();

        // Tarefa de Redação
        TarefaDeRedacao redacao = new TarefaDeRedacao(
            "Maria Vitória dos Anjos",
            "História da Europa",
            "As Causas da Segunda Guerra Mundial"
        );

        Console.WriteLine(redacao.ObterResumo());
        Console.WriteLine(redacao.ObterInformacoesDaRedacao());
    }
}