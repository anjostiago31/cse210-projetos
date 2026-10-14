
public class MetaChecklist : Meta
{
    private int _quantidadeAtual;
    private int _quantidadeNecessaria;
    private int _bonus;

    public MetaChecklist(string nome, string descricao, int pontos,
        int quantidadeNecessaria, int bonus)
        : base(nome, descricao, pontos)
    {
        _quantidadeAtual = 0;
        _quantidadeNecessaria = quantidadeNecessaria;
        _bonus = bonus;
    }

    public override int RegistrarEvento()
    {
        if (EstaConcluida())
        {
            return 0;
        }

        _quantidadeAtual++;
        int pontosGanhos = ObterPontos();

        if (EstaConcluida())
        {
            pontosGanhos += _bonus;
        }

        return pontosGanhos;
    }

    public override bool EstaConcluida()
    {
        return _quantidadeAtual >= _quantidadeNecessaria;
    }

    public override string ObterDetalhes()
    {
        string status = EstaConcluida() ? "[X]" : "[ ]";

        return $"{status} {ObterNome()} - {ObterDescricao()} " +
               $"(Concluida {_quantidadeAtual}/{_quantidadeNecessaria} vezes)";
    }

    public override string ObterDadosParaSalvar()
    {
        return $"Checklist|{ObterNome()}|{ObterDescricao()}|" +
               $"{ObterPontos()}|{_quantidadeNecessaria}|" +
               $"{_bonus}|{_quantidadeAtual}";
    }

    public void DefinirProgresso(int quantidade)
    {
        if (quantidade >= 0 && quantidade <= _quantidadeNecessaria)
        {
            _quantidadeAtual = quantidade;
        }
    }
}
