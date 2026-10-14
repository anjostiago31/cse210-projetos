
public class MetaSimples : Meta
{
    private bool _concluida;

    public MetaSimples(string nome, string descricao, int pontos)
        : base(nome, descricao, pontos)
    {
        _concluida = false;
    }

    public override int RegistrarEvento()
    {
        if (!_concluida)
        {
            _concluida = true;
            return ObterPontos();
        }

        return 0;
    }

    public override bool EstaConcluida()
    {
        return _concluida;
    }

    public override string ObterDetalhes()
    {
        string status = _concluida ? "[X]" : "[ ]";

        return $"{status} {ObterNome()} - {ObterDescricao()}";
    }

    public override string ObterDadosParaSalvar()
    {
        return $"Simples|{ObterNome()}|{ObterDescricao()}|{ObterPontos()}|{_concluida}";
    }

    public void DefinirConclusao(bool concluida)
    {
        _concluida = concluida;
    }
}
