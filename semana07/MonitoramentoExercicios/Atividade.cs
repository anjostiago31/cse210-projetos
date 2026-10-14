
using System;

public abstract class Atividade
{
    private DateTime _data;
    private int _duracao;

    public Atividade(DateTime data, int duracao)
    {
        _data = data;
        _duracao = duracao;
    }

    public int ObterDuracao()
    {
        return _duracao;
    }

    public abstract double ObterDistancia();

    public abstract double ObterVelocidade();

    public abstract double ObterRitmo();

    public virtual string ObterResumo()
    {
        return $"{_data:dd MMM yyyy} {GetType().Name} " +
               $"({_duracao} min) - " +
               $"Distância: {ObterDistancia():F2} km, " +
               $"Velocidade: {ObterVelocidade():F2} km/h, " +
               $"Ritmo: {ObterRitmo():F2} min por km";
    }
}
