using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numeros = new List<int>();

        int numero = -1;

        while (numero != 0)
        {
            Console.Write("Digite um número (ou 0 para sair): ");

            string entrada = Console.ReadLine();
            numero = int.Parse(entrada);

            if (numero != 0)
            {
                numeros.Add(numero);
            }
        }

        if (numeros.Count > 0)
        {
            int soma = 0;

            foreach (int n in numeros)
            {
                soma += n;
            }

            Console.WriteLine($"A soma dos números é: {soma}");

            float media = (float)soma / numeros.Count;
            Console.WriteLine($"A média dos números é: {media}");

            int maior = numeros[0];

            foreach (int n in numeros)
            {
                if (n > maior)
                {
                    maior = n;
                }
            }

            Console.WriteLine($"O maior número é: {maior}");

            int menorPositivo = int.MaxValue;

            foreach (int n in numeros)
            {
                if (n > 0 && n < menorPositivo)
                {
                    menorPositivo = n;
                }
            }

            if (menorPositivo != int.MaxValue)
            {
                Console.WriteLine("O menor número positivo é: " + menorPositivo);
            }
            else
            {
                Console.WriteLine("Nenhum número positivo foi digitado.");
            }

            numeros.Sort();

            Console.WriteLine("A lista reordenada é:");

            foreach (int n in numeros)
            {
                Console.WriteLine(n);
            }
        }
        else
        {
            Console.WriteLine("Nenhum número foi digitado.");
        }
    }
}