using System;

class Program
{
    static void Main(string[] args)
    {
    Random geradorRandomico = new Random();
    int numeroMagico = geradorRandomico.Next(1, 101);    
    
    int palpite = 0;
    int quantidadePalpites = 0;

    while (palpite != numeroMagico)
    {
        Console.Write("Qual o seu palpite? ");
         palpite = int.Parse(Console.ReadLine());

        quantidadePalpites++;

        if (palpite < numeroMagico)
        {
            Console.WriteLine("Muito baixo! Tente novamente.");
        }
        else if (palpite > numeroMagico)
        {
            Console.WriteLine("Muito alto! Tente novamente.");
        }
    }
    Console.WriteLine("Parabéns! Você acertou o número mágico!");
    Console.WriteLine($"Você precisou de {quantidadePalpites} palpites.");
    Console.WriteLine("Você quer jogar novamente? (s/n)");
    string resposta = Console.ReadLine().ToLower();

    if (resposta == "s")
    {
        Main(args);
    }
    else
    {
        Console.WriteLine("Obrigado por jogar! Até a próxima!");
    }
    

    
  }
}