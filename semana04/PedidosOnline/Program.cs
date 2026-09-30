using System;

class Program
{
    static void Main(string[] args)
    {
        // PEDIDO 1 - Cliente dos Estados Unidos

        Endereco endereco1 = new Endereco(
            "777 Broadway",
            "New York",
            "NY",
            "USA"
        );

        Cliente cliente1 = new Cliente(
            "Tiago dos Anjos",
            endereco1
        );

        Pedido pedido1 = new Pedido(cliente1);

        pedido1.AdicionarProduto(
            new Produto("Notebook", "P001", 850.00, 1)
        );

        pedido1.AdicionarProduto(
            new Produto("Mouse", "P002", 25.00, 2)
        );

        pedido1.AdicionarProduto(
            new Produto("Teclado", "P003", 45.00, 1)
        );


        // PEDIDO 2 - Cliente do Brasil

        Endereco endereco2 = new Endereco(
            "Rua das Flores, 150",
            "Garça",
            "São Paulo",
            "Brasil"
        );

        Cliente cliente2 = new Cliente(
            "Maria Vitória dos Anjos",
            endereco2
        );

        Pedido pedido2 = new Pedido(cliente2);

        pedido2.AdicionarProduto(
            new Produto("Monitor", "P004", 300.00, 1)
        );

        pedido2.AdicionarProduto(
            new Produto("Webcam", "P005", 75.00, 2)
        );

        pedido2.AdicionarProduto(
            new Produto("Headset", "P006", 90.00, 1)
        );


        // EXIBIR PEDIDO 1

        Console.WriteLine("===== PEDIDO 1 =====");
        Console.WriteLine();

        Console.WriteLine("ETIQUETA DE EMBALAGEM:");
        Console.WriteLine(pedido1.ObterEtiquetaEmbalagem());

        Console.WriteLine("ETIQUETA DE ENVIO:");
        Console.WriteLine(pedido1.ObterEtiquetaEnvio());

        Console.WriteLine();
        Console.WriteLine($"PREÇO TOTAL: ${pedido1.CalcularPrecoTotal():F2}");


        Console.WriteLine();
        Console.WriteLine("------------------------------");
        Console.WriteLine();


        // EXIBIR PEDIDO 2

        Console.WriteLine("===== PEDIDO 2 =====");
        Console.WriteLine();

        Console.WriteLine("ETIQUETA DE EMBALAGEM:");
        Console.WriteLine(pedido2.ObterEtiquetaEmbalagem());

        Console.WriteLine("ETIQUETA DE ENVIO:");
        Console.WriteLine(pedido2.ObterEtiquetaEnvio());

        Console.WriteLine();
        Console.WriteLine($"PREÇO TOTAL: ${pedido2.CalcularPrecoTotal():F2}");
    }
}