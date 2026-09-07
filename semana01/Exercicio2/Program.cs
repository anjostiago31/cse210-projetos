using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Qual a sua nota? ");
        string nota = Console.ReadLine();

        float notaFloat = float.Parse(nota);

        string letra;

        if (notaFloat >= 90)
        {
            letra = "A";
        }
        else if (notaFloat >= 80)
        {
            letra = "B";
        }
        else if (notaFloat >= 70)
        {
            letra = "C";
        }
        else if (notaFloat >= 60)
        {
            letra = "D";
        }
        else
        {
            letra = "F";
        }

        string sinal = "";
        int ultimoDigito = (int)notaFloat % 10;

        if (ultimoDigito >= 7)
        {
            sinal = "+";
        }
        else if (ultimoDigito < 3)
        {
            sinal = "-";
        }

        if (letra == "A" && sinal == "+")
        {
            sinal = "";
        }

        if (letra == "F")
        {
            sinal = "";
        }

        Console.WriteLine($"Sua nota é {letra}{sinal}");

        if (notaFloat >= 70)
        {
            Console.WriteLine("Parabéns, você passou!");
        }
        else
        {
            Console.WriteLine("Infelizmente você não passou.");
        }
    }
}