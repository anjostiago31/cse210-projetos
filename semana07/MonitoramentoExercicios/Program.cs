
using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture =
            CultureInfo.GetCultureInfo("pt-BR");

        List<Atividade> atividades = new List<Atividade>();

        Corrida corrida = new Corrida(
            new DateTime(2026, 10, 11), 30, 5.0);

        Ciclismo ciclismo = new Ciclismo(
            new DateTime(2026, 10, 12), 45, 20.0);

        Natacao natacao = new Natacao(
            new DateTime(2026, 10, 13), 30, 20);

        atividades.Add(corrida);
        atividades.Add(ciclismo);
        atividades.Add(natacao);

        Console.WriteLine("MONITORAMENTO DE EXERCÍCIOS");
        Console.WriteLine("---------------------------");

        foreach (Atividade atividade in atividades)
        {
            Console.WriteLine(atividade.ObterResumo());
        }
    }
}
