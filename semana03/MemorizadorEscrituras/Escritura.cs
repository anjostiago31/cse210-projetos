public class Escritura
{
    private Referencia _referencia;
    private List<Palavra> _palavras;

    public Escritura(Referencia referencia, string texto)
    {
        _referencia = referencia;
        _palavras = new List<Palavra>();

        string[] palavras = texto.Split(' ');

        foreach (string palavra in palavras)
        {
            _palavras.Add(new Palavra(palavra));
        }
    }

    public void EsconderPalavrasAleatorias(int quantidade)
    {
        Random random = new Random();

        List<Palavra> palavrasVisiveis = new List<Palavra>();

        foreach (Palavra palavra in _palavras)
        {
            if (!palavra.EstaEscondida())
            {
                palavrasVisiveis.Add(palavra);
            }
        }

        int quantidadeParaEsconder =
            Math.Min(quantidade, palavrasVisiveis.Count);

        for (int i = 0; i < quantidadeParaEsconder; i++)
        {
            int indice = random.Next(palavrasVisiveis.Count);

            palavrasVisiveis[indice].Esconder();

            palavrasVisiveis.RemoveAt(indice);
        }
    }

    public string ObterTextoExibicao()
    {
        string texto = _referencia.ObterTextoExibicao() + " ";

        foreach (Palavra palavra in _palavras)
        {
            texto += palavra.ObterTextoExibicao() + " ";
        }

        return texto.Trim();
    }

    public bool EstaCompletamenteEscondida()
    {
        foreach (Palavra palavra in _palavras)
        {
            if (!palavra.EstaEscondida())
            {
                return false;
            }
        }

        return true;
    }

    public int ObterTotalPalavras()
    {
        return _palavras.Count;
    }

    public int ObterQuantidadeEscondida()
    {
        int quantidade = 0;

        foreach (Palavra palavra in _palavras)
        {
            if (palavra.EstaEscondida())
            {
                quantidade++;
            }
        }

        return quantidade;
    }
}