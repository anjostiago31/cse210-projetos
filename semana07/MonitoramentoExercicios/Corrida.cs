
using System;

public class Corrida : Atividade
{
    private double _distancia;

    public Corrida(DateTime data, int duracao, double distancia)
        : base(data, duracao)
    {
        _distancia = distancia;
    }

    public override double ObterDistancia()
    {
        return _distancia;
    }

    public override double ObterVelocidade()
    {
        return (_distancia / ObterDuracao()) * 60;
    }

    public override double ObterRitmo()
    {
        return ObterDuracao() / _distancia;
    }
}
