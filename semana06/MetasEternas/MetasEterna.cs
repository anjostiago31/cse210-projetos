
public class MetaEterna : Meta
{
    public MetaEterna(string nome, string descricao, int pontos)
        : base(nome, descricao, pontos)
    {
    }

    public override int RegistrarEvento()
    {
        return ObterPontos();
    }

    public override bool EstaConcluida()
    {
        return false;
    }

    public override string ObterDetalhes()
    {
        return $"[ ] {ObterNome()} - {ObterDescricao()}";
    }

    public override string ObterDadosParaSalvar()
    {
        return $"Eterna|{ObterNome()}|{ObterDescricao()}|{ObterPontos()}";
    }
}
