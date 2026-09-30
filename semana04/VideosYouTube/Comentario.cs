public class Comentario
{
    public string _nome;
    public string _texto;

    public Comentario(string nome, string texto)
    {
        _nome = nome;
        _texto = texto;
    }

    public void ExibirComentario()
    {
        Console.WriteLine($"{_nome}: {_texto}");
    }
}