using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video(
            "Aprendendo C# do Zero",
            "Tiago Programação",
            620
        );

        video1.AdicionarComentario(
            new Comentario("Maria", "Ótima explicação!")
        );

        video1.AdicionarComentario(
            new Comentario("João", "Esse vídeo me ajudou muito.")
        );

        video1.AdicionarComentario(
            new Comentario("Carlos", "Estou começando a aprender C#.")
        );

        videos.Add(video1);


        Video video2 = new Video(
            "Programação Orientada a Objetos",
            "Canal Tecnologia",
            850
        );

        video2.AdicionarComentario(
            new Comentario("Ana", "Muito fácil de entender.")
        );

        video2.AdicionarComentario(
            new Comentario("Pedro", "Gostei dos exemplos.")
        );

        video2.AdicionarComentario(
            new Comentario("Lucas", "Agora entendi abstração!")
        );

        videos.Add(video2);


        Video video3 = new Video(
            "Como criar classes em C#",
            "Mundo CSharp",
            480
        );

        video3.AdicionarComentario(
            new Comentario("Gabriel", "Excelente conteúdo.")
        );

        video3.AdicionarComentario(
            new Comentario("Juliana", "Muito bem explicado.")
        );

        video3.AdicionarComentario(
            new Comentario("Rafael", "Vou usar isso no meu projeto.")
        );

        videos.Add(video3);


        Video video4 = new Video(
            "Abstração em C#",
            "Estudando Programação",
            540
        );

        video4.AdicionarComentario(
            new Comentario("Marcos", "Agora ficou fácil entender abstração.")
        );

        video4.AdicionarComentario(
            new Comentario("Fernanda", "Gostei muito da aula.")
        );

        video4.AdicionarComentario(
            new Comentario("Bruno", "Obrigado pelo conteúdo!")
        );

        videos.Add(video4);


        foreach (Video video in videos)
        {
            video.ExibirInformacoes();
        }
    }
}