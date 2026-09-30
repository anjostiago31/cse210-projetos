public class Video
{
    public string _titulo;
    public string _autor;
    public int _duracao;
    public List<Comentario> _comentarios = new List<Comentario>();

    public Video(string titulo, string autor, int duracao)
    {
        _titulo = titulo;
        _autor = autor;
        _duracao = duracao;
    }

    public void AdicionarComentario(Comentario comentario)
    {
        _comentarios.Add(comentario);
    }

    public int ObterNumeroComentarios()
    {
        return _comentarios.Count;
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Título: {_titulo}");
        Console.WriteLine($"Autor: {_autor}");
        Console.WriteLine($"Duração: {_duracao} segundos");
        Console.WriteLine($"Número de comentários: {ObterNumeroComentarios()}");
        Console.WriteLine("Comentários:");

        foreach (Comentario comentario in _comentarios)
        {
            comentario.ExibirComentario();
        }

        Console.WriteLine();
    }
}